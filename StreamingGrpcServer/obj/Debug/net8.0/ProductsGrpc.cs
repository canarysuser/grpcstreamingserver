// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: products.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ProductServices.Streaming.Demo {
  public static partial class ProductService
  {
    static readonly string __ServiceName = "ProductStreamingDemo.ProductService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductServices.Streaming.Demo.ProductListing> __Marshaller_ProductStreamingDemo_ProductListing = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductServices.Streaming.Demo.ProductListing.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductServices.Streaming.Demo.DetailsInput> __Marshaller_ProductStreamingDemo_DetailsInput = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductServices.Streaming.Demo.DetailsInput.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductServices.Streaming.Demo.Product> __Marshaller_ProductStreamingDemo_Product = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductServices.Streaming.Demo.Product.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ProductServices.Streaming.Demo.ProductListing> __Method_UnaryProductListing = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ProductServices.Streaming.Demo.ProductListing>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UnaryProductListing",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_ProductStreamingDemo_ProductListing);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.Product> __Method_UnaryGetProductDetails = new grpc::Method<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UnaryGetProductDetails",
        __Marshaller_ProductStreamingDemo_DetailsInput,
        __Marshaller_ProductStreamingDemo_Product);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ProductServices.Streaming.Demo.ProductListing> __Method_GetProductListSS = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::ProductServices.Streaming.Demo.ProductListing>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetProductListSS",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_ProductStreamingDemo_ProductListing);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.ProductListing> __Method_GetProductListCS = new grpc::Method<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.ProductListing>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "GetProductListCS",
        __Marshaller_ProductStreamingDemo_DetailsInput,
        __Marshaller_ProductStreamingDemo_ProductListing);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.Product> __Method_GetProductsBoth = new grpc::Method<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.Product>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "GetProductsBoth",
        __Marshaller_ProductStreamingDemo_DetailsInput,
        __Marshaller_ProductStreamingDemo_Product);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ProductServices.Streaming.Demo.ProductsReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ProductService</summary>
    [grpc::BindServiceMethod(typeof(ProductService), "BindService")]
    public abstract partial class ProductServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProductServices.Streaming.Demo.ProductListing> UnaryProductListing(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProductServices.Streaming.Demo.Product> UnaryGetProductDetails(global::ProductServices.Streaming.Demo.DetailsInput request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetProductListSS(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::IServerStreamWriter<global::ProductServices.Streaming.Demo.ProductListing> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProductServices.Streaming.Demo.ProductListing> GetProductListCS(grpc::IAsyncStreamReader<global::ProductServices.Streaming.Demo.DetailsInput> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetProductsBoth(grpc::IAsyncStreamReader<global::ProductServices.Streaming.Demo.DetailsInput> requestStream, grpc::IServerStreamWriter<global::ProductServices.Streaming.Demo.Product> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ProductServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_UnaryProductListing, serviceImpl.UnaryProductListing)
          .AddMethod(__Method_UnaryGetProductDetails, serviceImpl.UnaryGetProductDetails)
          .AddMethod(__Method_GetProductListSS, serviceImpl.GetProductListSS)
          .AddMethod(__Method_GetProductListCS, serviceImpl.GetProductListCS)
          .AddMethod(__Method_GetProductsBoth, serviceImpl.GetProductsBoth).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ProductServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_UnaryProductListing, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::ProductServices.Streaming.Demo.ProductListing>(serviceImpl.UnaryProductListing));
      serviceBinder.AddMethod(__Method_UnaryGetProductDetails, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.Product>(serviceImpl.UnaryGetProductDetails));
      serviceBinder.AddMethod(__Method_GetProductListSS, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::Google.Protobuf.WellKnownTypes.Empty, global::ProductServices.Streaming.Demo.ProductListing>(serviceImpl.GetProductListSS));
      serviceBinder.AddMethod(__Method_GetProductListCS, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.ProductListing>(serviceImpl.GetProductListCS));
      serviceBinder.AddMethod(__Method_GetProductsBoth, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::ProductServices.Streaming.Demo.DetailsInput, global::ProductServices.Streaming.Demo.Product>(serviceImpl.GetProductsBoth));
    }

  }
}
#endregion
