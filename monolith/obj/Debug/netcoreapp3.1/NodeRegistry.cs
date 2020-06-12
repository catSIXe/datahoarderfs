// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/nodeRegistry.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace monolith {

  /// <summary>Holder for reflection information generated from Protos/nodeRegistry.proto</summary>
  public static partial class NodeRegistryReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/nodeRegistry.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NodeRegistryReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlQcm90b3Mvbm9kZVJlZ2lzdHJ5LnByb3RvEg1kYXRhaG9hcmRlcmZzIi8K",
            "GU5vZGVBdXRoZW50aWNhdGlvblJlcXVlc3QSEgoKaWRlbnRpZmllchgBIAEo",
            "CSJEChdOb2RlQXV0aGVudGljYXRpb25SZXBseRIOCgZzdGF0dXMYASABKAgS",
            "GQoRa2VlcEFsaXZlSW50ZXJ2YWwYAiABKAUiGQoXTm9kZVVwZGF0ZVN0cmVh",
            "bVJlcXVlc3QiJwoVTm9kZVVwZGF0ZVN0cmVhbVJlcGx5Eg4KBnN0YXR1cxgB",
            "IAEoCDLOAQoMTm9kZVJlZ2lzdHJ5EmAKDEF1dGhlbnRpY2F0ZRIoLmRhdGFo",
            "b2FyZGVyZnMuTm9kZUF1dGhlbnRpY2F0aW9uUmVxdWVzdBomLmRhdGFob2Fy",
            "ZGVyZnMuTm9kZUF1dGhlbnRpY2F0aW9uUmVwbHkSXAoMVXBkYXRlU3RyZWFt",
            "EiYuZGF0YWhvYXJkZXJmcy5Ob2RlVXBkYXRlU3RyZWFtUmVxdWVzdBokLmRh",
            "dGFob2FyZGVyZnMuTm9kZVVwZGF0ZVN0cmVhbVJlcGx5QguqAghtb25vbGl0",
            "aGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::monolith.NodeAuthenticationRequest), global::monolith.NodeAuthenticationRequest.Parser, new[]{ "Identifier" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::monolith.NodeAuthenticationReply), global::monolith.NodeAuthenticationReply.Parser, new[]{ "Status", "KeepAliveInterval" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::monolith.NodeUpdateStreamRequest), global::monolith.NodeUpdateStreamRequest.Parser, null, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::monolith.NodeUpdateStreamReply), global::monolith.NodeUpdateStreamReply.Parser, new[]{ "Status" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NodeAuthenticationRequest : pb::IMessage<NodeAuthenticationRequest> {
    private static readonly pb::MessageParser<NodeAuthenticationRequest> _parser = new pb::MessageParser<NodeAuthenticationRequest>(() => new NodeAuthenticationRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NodeAuthenticationRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::monolith.NodeRegistryReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeAuthenticationRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeAuthenticationRequest(NodeAuthenticationRequest other) : this() {
      identifier_ = other.identifier_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeAuthenticationRequest Clone() {
      return new NodeAuthenticationRequest(this);
    }

    /// <summary>Field number for the "identifier" field.</summary>
    public const int IdentifierFieldNumber = 1;
    private string identifier_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Identifier {
      get { return identifier_; }
      set {
        identifier_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NodeAuthenticationRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NodeAuthenticationRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Identifier != other.Identifier) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Identifier.Length != 0) hash ^= Identifier.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Identifier.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Identifier);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Identifier.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Identifier);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NodeAuthenticationRequest other) {
      if (other == null) {
        return;
      }
      if (other.Identifier.Length != 0) {
        Identifier = other.Identifier;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Identifier = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class NodeAuthenticationReply : pb::IMessage<NodeAuthenticationReply> {
    private static readonly pb::MessageParser<NodeAuthenticationReply> _parser = new pb::MessageParser<NodeAuthenticationReply>(() => new NodeAuthenticationReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NodeAuthenticationReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::monolith.NodeRegistryReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeAuthenticationReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeAuthenticationReply(NodeAuthenticationReply other) : this() {
      status_ = other.status_;
      keepAliveInterval_ = other.keepAliveInterval_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeAuthenticationReply Clone() {
      return new NodeAuthenticationReply(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private bool status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    /// <summary>Field number for the "keepAliveInterval" field.</summary>
    public const int KeepAliveIntervalFieldNumber = 2;
    private int keepAliveInterval_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int KeepAliveInterval {
      get { return keepAliveInterval_; }
      set {
        keepAliveInterval_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NodeAuthenticationReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NodeAuthenticationReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      if (KeepAliveInterval != other.KeepAliveInterval) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != false) hash ^= Status.GetHashCode();
      if (KeepAliveInterval != 0) hash ^= KeepAliveInterval.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Status != false) {
        output.WriteRawTag(8);
        output.WriteBool(Status);
      }
      if (KeepAliveInterval != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(KeepAliveInterval);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Status != false) {
        size += 1 + 1;
      }
      if (KeepAliveInterval != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(KeepAliveInterval);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NodeAuthenticationReply other) {
      if (other == null) {
        return;
      }
      if (other.Status != false) {
        Status = other.Status;
      }
      if (other.KeepAliveInterval != 0) {
        KeepAliveInterval = other.KeepAliveInterval;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Status = input.ReadBool();
            break;
          }
          case 16: {
            KeepAliveInterval = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class NodeUpdateStreamRequest : pb::IMessage<NodeUpdateStreamRequest> {
    private static readonly pb::MessageParser<NodeUpdateStreamRequest> _parser = new pb::MessageParser<NodeUpdateStreamRequest>(() => new NodeUpdateStreamRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NodeUpdateStreamRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::monolith.NodeRegistryReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeUpdateStreamRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeUpdateStreamRequest(NodeUpdateStreamRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeUpdateStreamRequest Clone() {
      return new NodeUpdateStreamRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NodeUpdateStreamRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NodeUpdateStreamRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NodeUpdateStreamRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class NodeUpdateStreamReply : pb::IMessage<NodeUpdateStreamReply> {
    private static readonly pb::MessageParser<NodeUpdateStreamReply> _parser = new pb::MessageParser<NodeUpdateStreamReply>(() => new NodeUpdateStreamReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NodeUpdateStreamReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::monolith.NodeRegistryReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeUpdateStreamReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeUpdateStreamReply(NodeUpdateStreamReply other) : this() {
      status_ = other.status_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NodeUpdateStreamReply Clone() {
      return new NodeUpdateStreamReply(this);
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 1;
    private bool status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NodeUpdateStreamReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NodeUpdateStreamReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != false) hash ^= Status.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Status != false) {
        output.WriteRawTag(8);
        output.WriteBool(Status);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Status != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NodeUpdateStreamReply other) {
      if (other == null) {
        return;
      }
      if (other.Status != false) {
        Status = other.Status;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Status = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
