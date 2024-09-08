using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.IdentityModel.Tokens;
using ProductServices.Streaming.Demo;
using System.Security.Cryptography.Xml;
using System.Threading.Channels;

namespace StreamingGrpcServer.Services
{
    public class ProductDataService : ProductService.ProductServiceBase
    {
        ProductsDbContext _db;
        private ILogger<ProductDataService> _logger;
        public ProductDataService(ProductsDbContext ctx, ILogger<ProductDataService> logger) 
        {
            _db = ctx;
            _logger = logger;
        }

        public override Task<ProductListing> UnaryProductListing(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("{0} called.", nameof(UnaryProductListing));
            var list = _db.Products.ToList();
            var pl = new ProductListing(); 
            pl.Products.AddRange(list);
            return Task.FromResult(pl);
        }
        public override Task<Product> UnaryGetProductDetails(DetailsInput request, ServerCallContext context)
        {
            var id = request.ProductId; 
            var product = _db.Products.FirstOrDefault(c=>c.ProductId ==id);
            return Task.FromResult(product!);            
        }
        public override async Task GetProductListSS(Empty request, IServerStreamWriter<ProductListing> responseStream, ServerCallContext context)
        {
            _logger.LogInformation("{0} called.", nameof(GetProductListSS));
            var list =_db.Products.OrderBy(c=>c.ProductId).ToList();
            var count = (list.Count()/5)+1;
            var page = 0; 
            while (!context.CancellationToken.IsCancellationRequested && page<count)
            {
                _logger.LogInformation("{0} called.", nameof(GetProductListSS));
                var subList = list.Skip(page*5).Take(5);
                var pl = new ProductListing(); 
                pl.Products.AddRange(subList);
                await responseStream.WriteAsync(pl);
                page++;
                await Task.Delay(millisecondsDelay: 500);
            }
        }
        public override async Task<ProductListing> GetProductListCS(IAsyncStreamReader<DetailsInput> requestStream, ServerCallContext context)
        {
            _logger.LogInformation("{0} called.", nameof(GetProductListSS));
            var list = _db.Products.OrderBy(c => c.ProductId).ToList();
            var idList = new List<int>(); 
            await foreach(var request in requestStream.ReadAllAsync())
            {
                idList.Add(request.ProductId);
                _logger.LogInformation($"Getting product details for {request.ProductId}");
            }
            var response = new ProductListing();
            foreach (var id in idList)
            {
                var item = list.FindAll(c => c.ProductId == id);
                if (item is not null)
                    response.Products.Add(item);

            }
            return response;
        }
        public override async Task GetProductsBoth(IAsyncStreamReader<DetailsInput> requestStream, IServerStreamWriter<Product> responseStream, ServerCallContext context)
        {
            
            var channel = Channel.CreateUnbounded<Product>();
            _ = Task.Run(async () =>
            {
                await foreach (var product in channel.Reader.ReadAllAsync())
                {
                    await responseStream.WriteAsync(product);
                }
            });
            var getProductStreamRequestTasks = new List<Task>(); 
            try
            {
                await foreach (var request in requestStream.ReadAllAsync())
                {
                    _logger.LogInformation($"Getting product for product Id: {request.ProductId}");
                    getProductStreamRequestTasks.Add(GetProductAsync(request));
                }
                _logger.LogInformation("Client finished streaming"); 
            } catch (RpcException rpce) { _logger.LogError(rpce, "An exception occured"); }
            catch (Exception ex) { _logger.LogError(ex, "An exception occured"); }

            await Task.WhenAll(getProductStreamRequestTasks);
            channel.Writer.TryComplete(); 
            _logger.LogInformation("Completed streaming response");

            async Task GetProductAsync(DetailsInput input)
            {
                var item = _db.Products.Where(c => c.ProductId==input.ProductId).First();
                await channel.Writer.WriteAsync(item);
                await Task.Delay(500);
            }
        }
    }
}
