﻿/**
 * Autogenerated by Thrift Compiler (0.12.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace ThriftDemo.Contract.Net
{
    public partial class EmotionAnalyzer
    {
        public interface ISync
        {
            void Stop(long key);
        }

        public interface Iface : ISync
        {
#if SILVERLIGHT
      IAsyncResult Begin_Stop(AsyncCallback callback, object state, long key);
      void End_Stop(IAsyncResult asyncResult);
#endif
        }

        public class Client : IDisposable, Iface
        {
            public Client(TProtocol prot) : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                iprot_ = iprot;
                oprot_ = oprot;
            }

            protected TProtocol iprot_;
            protected TProtocol oprot_;
            protected int seqid_;

            public TProtocol InputProtocol
            {
                get { return iprot_; }
            }
            public TProtocol OutputProtocol
            {
                get { return oprot_; }
            }


            #region " IDisposable Support "
            private bool _IsDisposed;

            // IDisposable
            public void Dispose()
            {
                Dispose(true);
            }


            protected virtual void Dispose(bool disposing)
            {
                if (!_IsDisposed)
                {
                    if (disposing)
                    {
                        if (iprot_ != null)
                        {
                            ((IDisposable)iprot_).Dispose();
                        }
                        if (oprot_ != null)
                        {
                            ((IDisposable)oprot_).Dispose();
                        }
                    }
                }
                _IsDisposed = true;
            }
            #endregion



#if SILVERLIGHT
      
      public IAsyncResult Begin_Stop(AsyncCallback callback, object state, long key)
      {
        return send_Stop(callback, state, key);
      }

      public void End_Stop(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_Stop();
      }

#endif

            public void Stop(long key)
            {
#if SILVERLIGHT
        var asyncResult = Begin_Stop(null, null, key);
        End_Stop(asyncResult);

#else
                send_Stop(key);
                recv_Stop();

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_Stop(AsyncCallback callback, object state, long key)
      {
        oprot_.WriteMessageBegin(new TMessage("Stop", TMessageType.Call, seqid_));
        Stop_args args = new Stop_args();
        args.Key = key;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        return oprot_.Transport.BeginFlush(callback, state);
      }

#else

            public void send_Stop(long key)
            {
                oprot_.WriteMessageBegin(new TMessage("Stop", TMessageType.Call, seqid_));
                Stop_args args = new Stop_args();
                args.Key = key;
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
                oprot_.Transport.Flush();
            }
#endif

            public void recv_Stop()
            {
                TMessage msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    TApplicationException x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                Stop_result result = new Stop_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                return;
            }

        }
        public class Processor : TProcessor
        {
            public Processor(ISync iface)
            {
                iface_ = iface;
                processMap_["Stop"] = Stop_Process;
            }

            protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
            private ISync iface_;
            protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

            public bool Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    TMessage msg = iprot.ReadMessageBegin();
                    ProcessFunction fn;
                    processMap_.TryGetValue(msg.Name, out fn);
                    if (fn == null)
                    {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        TApplicationException x = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                        x.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    fn(msg.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void Stop_Process(int seqid, TProtocol iprot, TProtocol oprot)
            {
                Stop_args args = new Stop_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                Stop_result result = new Stop_result();
                try
                {
                    iface_.Stop(args.Key);
                    oprot.WriteMessageBegin(new TMessage("Stop", TMessageType.Reply, seqid));
                    result.Write(oprot);
                }
                catch (TTransportException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error occurred in processor:");
                    Console.Error.WriteLine(ex.ToString());
                    TApplicationException x = new TApplicationException(TApplicationException.ExceptionType.InternalError, " Internal error.");
                    oprot.WriteMessageBegin(new TMessage("Stop", TMessageType.Exception, seqid));
                    x.Write(oprot);
                }
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class Stop_args : TBase
        {
            private long _key;

            public long Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    __isset.key = true;
                    this._key = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public bool key;
            }

            public Stop_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            case 1:
                                if (field.Type == TType.I64)
                                {
                                    Key = iprot.ReadI64();
                                }
                                else
                                {
                                    TProtocolUtil.Skip(iprot, field.Type);
                                }
                                break;
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("Stop_args");
                    oprot.WriteStructBegin(struc);
                    TField field = new TField();
                    if (__isset.key)
                    {
                        field.Name = "key";
                        field.Type = TType.I64;
                        field.ID = 1;
                        oprot.WriteFieldBegin(field);
                        oprot.WriteI64(Key);
                        oprot.WriteFieldEnd();
                    }
                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("Stop_args(");
                bool __first = true;
                if (__isset.key)
                {
                    if (!__first) { __sb.Append(", "); }
                    __first = false;
                    __sb.Append("Key: ");
                    __sb.Append(Key);
                }
                __sb.Append(")");
                return __sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class Stop_result : TBase
        {

            public Stop_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                iprot.IncrementRecursionDepth();
                try
                {
                    TField field;
                    iprot.ReadStructBegin();
                    while (true)
                    {
                        field = iprot.ReadFieldBegin();
                        if (field.Type == TType.Stop)
                        {
                            break;
                        }
                        switch (field.ID)
                        {
                            default:
                                TProtocolUtil.Skip(iprot, field.Type);
                                break;
                        }
                        iprot.ReadFieldEnd();
                    }
                    iprot.ReadStructEnd();
                }
                finally
                {
                    iprot.DecrementRecursionDepth();
                }
            }

            public void Write(TProtocol oprot)
            {
                oprot.IncrementRecursionDepth();
                try
                {
                    TStruct struc = new TStruct("Stop_result");
                    oprot.WriteStructBegin(struc);

                    oprot.WriteFieldStop();
                    oprot.WriteStructEnd();
                }
                finally
                {
                    oprot.DecrementRecursionDepth();
                }
            }

            public override string ToString()
            {
                StringBuilder __sb = new StringBuilder("Stop_result(");
                __sb.Append(")");
                return __sb.ToString();
            }

        }

    }
}
