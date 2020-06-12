// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/nodeRegistry.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace monolith {
  public static partial class NodeRegistry
  {
    static readonly string __ServiceName = "datahoarderfs.NodeRegistry";

    static readonly grpc::Marshaller<global::monolith.NodeAuthenticationRequest> __Marshaller_datahoarderfs_NodeAuthenticationRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::monolith.NodeAuthenticationRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::monolith.NodeAuthenticationReply> __Marshaller_datahoarderfs_NodeAuthenticationReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::monolith.NodeAuthenticationReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::monolith.NodeUpdateStreamRequest> __Marshaller_datahoarderfs_NodeUpdateStreamRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::monolith.NodeUpdateStreamRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::monolith.NodeUpdateStreamReply> __Marshaller_datahoarderfs_NodeUpdateStreamReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::monolith.NodeUpdateStreamReply.Parser.ParseFrom);

    static readonly grpc::Method<global::monolith.NodeAuthenticationRequest, global::monolith.NodeAuthenticationReply> __Method_Authenticate = new grpc::Method<global::monolith.NodeAuthenticationRequest, global::monolith.NodeAuthenticationReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Authenticate",
        __Marshaller_datahoarderfs_NodeAuthenticationRequest,
        __Marshaller_datahoarderfs_NodeAuthenticationReply);

    static readonly grpc::Method<global::monolith.NodeUpdateStreamRequest, global::monolith.NodeUpdateStreamReply> __Method_UpdateStream = new grpc::Method<global::monolith.NodeUpdateStreamRequest, global::monolith.NodeUpdateStreamReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateStream",
        __Marshaller_datahoarderfs_NodeUpdateStreamRequest,
        __Marshaller_datahoarderfs_NodeUpdateStreamReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::monolith.NodeRegistryReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of NodeRegistry</summary>
    [grpc::BindServiceMethod(typeof(NodeRegistry), "BindService")]
    public abstract partial class NodeRegistryBase
    {
      public virtual global::System.Threading.Tasks.Task<global::monolith.NodeAuthenticationReply> Authenticate(global::monolith.NodeAuthenticationRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::monolith.NodeUpdateStreamReply> UpdateStream(global::monolith.NodeUpdateStreamRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for NodeRegistry</summary>
    public partial class NodeRegistryClient : grpc::ClientBase<NodeRegistryClient>
    {
      /// <summary>Creates a new client for NodeRegistry</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public NodeRegistryClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for NodeRegistry that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public NodeRegistryClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected NodeRegistryClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected NodeRegistryClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::monolith.NodeAuthenticationReply Authenticate(global::monolith.NodeAuthenticationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Authenticate(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::monolith.NodeAuthenticationReply Authenticate(global::monolith.NodeAuthenticationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Authenticate, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::monolith.NodeAuthenticationReply> AuthenticateAsync(global::monolith.NodeAuthenticationRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AuthenticateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::monolith.NodeAuthenticationReply> AuthenticateAsync(global::monolith.NodeAuthenticationRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Authenticate, null, options, request);
      }
      public virtual global::monolith.NodeUpdateStreamReply UpdateStream(global::monolith.NodeUpdateStreamRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::monolith.NodeUpdateStreamReply UpdateStream(global::monolith.NodeUpdateStreamRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateStream, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::monolith.NodeUpdateStreamReply> UpdateStreamAsync(global::monolith.NodeUpdateStreamRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateStreamAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::monolith.NodeUpdateStreamReply> UpdateStreamAsync(global::monolith.NodeUpdateStreamRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateStream, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override NodeRegistryClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new NodeRegistryClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(NodeRegistryBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Authenticate, serviceImpl.Authenticate)
          .AddMethod(__Method_UpdateStream, serviceImpl.UpdateStream).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, NodeRegistryBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Authenticate, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::monolith.NodeAuthenticationRequest, global::monolith.NodeAuthenticationReply>(serviceImpl.Authenticate));
      serviceBinder.AddMethod(__Method_UpdateStream, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::monolith.NodeUpdateStreamRequest, global::monolith.NodeUpdateStreamReply>(serviceImpl.UpdateStream));
    }

  }
}
#endregion
