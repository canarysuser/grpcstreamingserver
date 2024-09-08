using Microsoft.EntityFrameworkCore;
using Serilog;
using StreamingGrpcServer.Services;
using Serilog.Extensions.Logging;

namespace StreamingGrpcServer
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Verbose()
                
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(options =>
            {
                //options.ListenLocalhost(5000, e => e.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
                
            });
            builder.Services.AddDbContext<ProductsDbContext>(options =>
            {
                //options.UseSqlServer("server=(local);database=northwind;integrated security=sspi;trustservercertificate=true");
                options.UseSqlServer("Server=tcp:grpcnorthwinddbserver.database.windows.net,1433;Initial Catalog=grpcnorthwindtradersDB;Persist Security Info=False;User ID=coreuser;Password=grpcDB@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            });
            // Add services to the container.
            
            builder.Services.AddGrpc();
            builder.Services.AddGrpcReflection(); 
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<ProductDataService>();
            app.MapGrpcReflectionService();

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}