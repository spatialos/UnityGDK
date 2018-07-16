// Generated by SpatialOS codegen. DO NOT EDIT!
// source: ExhaustiveSingular in improbable/gdk/tests/exhaustive_test.schema.

namespace Improbable.Gdk.Tests
{

public static class ExhaustiveSingular_Extensions
{
  public static ExhaustiveSingular.Data Get(this global::Improbable.Worker.IComponentData<ExhaustiveSingular> data)
  {
    return (ExhaustiveSingular.Data) data;
  }

  public static ExhaustiveSingular.Update Get(this global::Improbable.Worker.IComponentUpdate<ExhaustiveSingular> update)
  {
    return (ExhaustiveSingular.Update) update;
  }
}

public partial class ExhaustiveSingular : global::Improbable.Worker.IComponentMetaclass
{
  public const uint ComponentId = 197715;

  uint global::Improbable.Worker.IComponentMetaclass.ComponentId
  {
    get { return ComponentId; }
  }

  /// <summary>
  /// Concrete data type for the ExhaustiveSingular component.
  /// </summary>
  public class Data : global::Improbable.Worker.IComponentData<ExhaustiveSingular>, global::Improbable.Collections.IDeepCopyable<Data>
  {
    public global::Improbable.Gdk.Tests.ExhaustiveSingularData Value;

    public Data(global::Improbable.Gdk.Tests.ExhaustiveSingularData value)
    {
      Value = value;
    }

    public Data(
        bool field1,
        float field2,
        int field4,
        long field5,
        double field6,
        string field7,
        uint field8,
        ulong field9,
        int field10,
        long field11,
        uint field12,
        ulong field13,
        int field14,
        long field15,
        global::Improbable.EntityId field16,
        global::Improbable.Gdk.Tests.SomeType field17)
    {
      Value = new global::Improbable.Gdk.Tests.ExhaustiveSingularData(
          field1,
          field2,
          field4,
          field5,
          field6,
          field7,
          field8,
          field9,
          field10,
          field11,
          field12,
          field13,
          field14,
          field15,
          field16,
          field17);
    }

    public Data DeepCopy()
    {
      return new Data(Value.DeepCopy());
    }

    public global::Improbable.Worker.IComponentUpdate<ExhaustiveSingular> ToUpdate()
    {
      var update = new Update();
      update.SetField1(Value.field1);
      update.SetField2(Value.field2);
      update.SetField4(Value.field4);
      update.SetField5(Value.field5);
      update.SetField6(Value.field6);
      update.SetField7(Value.field7);
      update.SetField8(Value.field8);
      update.SetField9(Value.field9);
      update.SetField10(Value.field10);
      update.SetField11(Value.field11);
      update.SetField12(Value.field12);
      update.SetField13(Value.field13);
      update.SetField14(Value.field14);
      update.SetField15(Value.field15);
      update.SetField16(Value.field16);
      update.SetField17(Value.field17);
      return update;
    }
  }

  /// <summary>
  /// Concrete update type for the ExhaustiveSingular component.
  /// </summary>
  public class Update : global::Improbable.Worker.IComponentUpdate<ExhaustiveSingular>, global::Improbable.Collections.IDeepCopyable<Update>
  {
    /// <summary>
    /// Field field1 = 1.
    /// </summary>
    public global::Improbable.Collections.Option<bool> field1;
    public Update SetField1(bool _value)
    {
      field1.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field2 = 2.
    /// </summary>
    public global::Improbable.Collections.Option<float> field2;
    public Update SetField2(float _value)
    {
      field2.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field4 = 4.
    /// </summary>
    public global::Improbable.Collections.Option<int> field4;
    public Update SetField4(int _value)
    {
      field4.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field5 = 5.
    /// </summary>
    public global::Improbable.Collections.Option<long> field5;
    public Update SetField5(long _value)
    {
      field5.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field6 = 6.
    /// </summary>
    public global::Improbable.Collections.Option<double> field6;
    public Update SetField6(double _value)
    {
      field6.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field7 = 7.
    /// </summary>
    public global::Improbable.Collections.Option<string> field7;
    public Update SetField7(string _value)
    {
      field7.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field8 = 8.
    /// </summary>
    public global::Improbable.Collections.Option<uint> field8;
    public Update SetField8(uint _value)
    {
      field8.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field9 = 9.
    /// </summary>
    public global::Improbable.Collections.Option<ulong> field9;
    public Update SetField9(ulong _value)
    {
      field9.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field10 = 10.
    /// </summary>
    public global::Improbable.Collections.Option<int> field10;
    public Update SetField10(int _value)
    {
      field10.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field11 = 11.
    /// </summary>
    public global::Improbable.Collections.Option<long> field11;
    public Update SetField11(long _value)
    {
      field11.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field12 = 12.
    /// </summary>
    public global::Improbable.Collections.Option<uint> field12;
    public Update SetField12(uint _value)
    {
      field12.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field13 = 13.
    /// </summary>
    public global::Improbable.Collections.Option<ulong> field13;
    public Update SetField13(ulong _value)
    {
      field13.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field14 = 14.
    /// </summary>
    public global::Improbable.Collections.Option<int> field14;
    public Update SetField14(int _value)
    {
      field14.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field15 = 15.
    /// </summary>
    public global::Improbable.Collections.Option<long> field15;
    public Update SetField15(long _value)
    {
      field15.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field16 = 16.
    /// </summary>
    public global::Improbable.Collections.Option<global::Improbable.EntityId> field16;
    public Update SetField16(global::Improbable.EntityId _value)
    {
      field16.Set(_value);
      return this;
    }

    /// <summary>
    /// Field field17 = 17.
    /// </summary>
    public global::Improbable.Collections.Option<global::Improbable.Gdk.Tests.SomeType> field17;
    public Update SetField17(global::Improbable.Gdk.Tests.SomeType _value)
    {
      field17.Set(_value);
      return this;
    }

    public Update DeepCopy()
    {
      var _result = new Update();
      if (field1.HasValue)
      {
        bool field;
        field = field1.Value;
        _result.field1.Set(field);
      }
      if (field2.HasValue)
      {
        float field;
        field = field2.Value;
        _result.field2.Set(field);
      }
      if (field4.HasValue)
      {
        int field;
        field = field4.Value;
        _result.field4.Set(field);
      }
      if (field5.HasValue)
      {
        long field;
        field = field5.Value;
        _result.field5.Set(field);
      }
      if (field6.HasValue)
      {
        double field;
        field = field6.Value;
        _result.field6.Set(field);
      }
      if (field7.HasValue)
      {
        string field;
        field = field7.Value;
        _result.field7.Set(field);
      }
      if (field8.HasValue)
      {
        uint field;
        field = field8.Value;
        _result.field8.Set(field);
      }
      if (field9.HasValue)
      {
        ulong field;
        field = field9.Value;
        _result.field9.Set(field);
      }
      if (field10.HasValue)
      {
        int field;
        field = field10.Value;
        _result.field10.Set(field);
      }
      if (field11.HasValue)
      {
        long field;
        field = field11.Value;
        _result.field11.Set(field);
      }
      if (field12.HasValue)
      {
        uint field;
        field = field12.Value;
        _result.field12.Set(field);
      }
      if (field13.HasValue)
      {
        ulong field;
        field = field13.Value;
        _result.field13.Set(field);
      }
      if (field14.HasValue)
      {
        int field;
        field = field14.Value;
        _result.field14.Set(field);
      }
      if (field15.HasValue)
      {
        long field;
        field = field15.Value;
        _result.field15.Set(field);
      }
      if (field16.HasValue)
      {
        global::Improbable.EntityId field;
        field = field16.Value;
        _result.field16.Set(field);
      }
      if (field17.HasValue)
      {
        global::Improbable.Gdk.Tests.SomeType field;
        field = field17.Value.DeepCopy();
        _result.field17.Set(field);
      }
      return _result;
    }

    public global::Improbable.Worker.IComponentData<ExhaustiveSingular> ToInitialData()
    {
      return new Data(new global::Improbable.Gdk.Tests.ExhaustiveSingularData(
          field1.Value,
          field2.Value,
          field4.Value,
          field5.Value,
          field6.Value,
          field7.Value,
          field8.Value,
          field9.Value,
          field10.Value,
          field11.Value,
          field12.Value,
          field13.Value,
          field14.Value,
          field15.Value,
          field16.Value,
          field17.Value));
    }

    public void ApplyTo(global::Improbable.Worker.IComponentData<ExhaustiveSingular> _data)
    {
      var _concrete = _data.Get();
      if (field1.HasValue)
      {
        _concrete.Value.field1 = field1.Value;
      }
      if (field2.HasValue)
      {
        _concrete.Value.field2 = field2.Value;
      }
      if (field4.HasValue)
      {
        _concrete.Value.field4 = field4.Value;
      }
      if (field5.HasValue)
      {
        _concrete.Value.field5 = field5.Value;
      }
      if (field6.HasValue)
      {
        _concrete.Value.field6 = field6.Value;
      }
      if (field7.HasValue)
      {
        _concrete.Value.field7 = field7.Value;
      }
      if (field8.HasValue)
      {
        _concrete.Value.field8 = field8.Value;
      }
      if (field9.HasValue)
      {
        _concrete.Value.field9 = field9.Value;
      }
      if (field10.HasValue)
      {
        _concrete.Value.field10 = field10.Value;
      }
      if (field11.HasValue)
      {
        _concrete.Value.field11 = field11.Value;
      }
      if (field12.HasValue)
      {
        _concrete.Value.field12 = field12.Value;
      }
      if (field13.HasValue)
      {
        _concrete.Value.field13 = field13.Value;
      }
      if (field14.HasValue)
      {
        _concrete.Value.field14 = field14.Value;
      }
      if (field15.HasValue)
      {
        _concrete.Value.field15 = field15.Value;
      }
      if (field16.HasValue)
      {
        _concrete.Value.field16 = field16.Value;
      }
      if (field17.HasValue)
      {
        _concrete.Value.field17 = field17.Value;
      }
    }
  }

  public partial class Commands
  {
  }

  // Implementation details below here.
  //----------------------------------------------------------------

  public global::Improbable.Worker.Internal.ComponentProtocol.ComponentVtable Vtable {
    get {
      global::Improbable.Worker.Internal.ComponentProtocol.ComponentVtable vtable;
      vtable.ComponentId = ComponentId;
      vtable.Free = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(global::Improbable.Worker.Internal.ClientHandles.ClientFree);
      vtable.Copy = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(global::Improbable.Worker.Internal.ClientHandles.ClientCopy);
      vtable.Deserialize = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(clientDeserialize);
      vtable.Serialize = global::System.Runtime.InteropServices.Marshal
          .GetFunctionPointerForDelegate(clientSerialize);
      return vtable;
    }
  }

  public void InvokeHandler(global::Improbable.Worker.Dynamic.Handler handler)
  {
    handler.Accept<ExhaustiveSingular>(this);
  }

  private static unsafe readonly global::Improbable.Worker.Internal.ComponentProtocol.ClientDeserialize
      clientDeserialize = ClientDeserialize;
  private static unsafe readonly global::Improbable.Worker.Internal.ComponentProtocol.ClientSerialize
      clientSerialize = ClientSerialize;

  [global::Improbable.Worker.Internal.MonoPInvokeCallback(typeof(global::Improbable.Worker.Internal.ComponentProtocol.ClientDeserialize))]
  private static unsafe global::System.Byte
  ClientDeserialize(global::System.UInt32 componentId,
                    global::System.Byte handleType,
                    global::Improbable.Worker.Internal.Pbio.Object* root,
                    global::Improbable.Worker.Internal.ComponentProtocol.ClientHandle** handleOut)
  {
    *handleOut = null;
    try
    {
      *handleOut = global::Improbable.Worker.Internal.ClientHandles.HandleAlloc();
      if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Update) {
        var data = new Update();
        var fieldsToClear = new global::System.Collections.Generic.HashSet<uint>();
        var fieldsToClearCount = global::Improbable.Worker.Internal.Pbio.GetUint32Count(root, /* fields to clear */ 1);
        for (uint i = 0; i < fieldsToClearCount; ++i)
        {
           fieldsToClear.Add(global::Improbable.Worker.Internal.Pbio.IndexUint32(root, /* fields to clear */ 1, i));
        }
        var stateObject = global::Improbable.Worker.Internal.Pbio.GetObject(
            global::Improbable.Worker.Internal.Pbio.GetObject(root, /* entity_state */ 2), 197715);
        if (global::Improbable.Worker.Internal.Pbio.GetBoolCount(stateObject, 1) > 0)
        {
          bool field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetBool(stateObject, 1) != 0;
          }
          data.field1.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetFloatCount(stateObject, 2) > 0)
        {
          float field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetFloat(stateObject, 2);
          }
          data.field2.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetInt32Count(stateObject, 4) > 0)
        {
          int field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetInt32(stateObject, 4);
          }
          data.field4.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetInt64Count(stateObject, 5) > 0)
        {
          long field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetInt64(stateObject, 5);
          }
          data.field5.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetDoubleCount(stateObject, 6) > 0)
        {
          double field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetDouble(stateObject, 6);
          }
          data.field6.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetBytesCount(stateObject, 7) > 0)
        {
          string field;
          {
            field = global::System.Text.Encoding.UTF8.GetString(global::Improbable.Worker.Bytes.CopyOf(global::Improbable.Worker.Internal.Pbio.GetBytes(stateObject, 7), global::Improbable.Worker.Internal.Pbio.GetBytesLength(stateObject, 7)).BackingArray);
          }
          data.field7.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetUint32Count(stateObject, 8) > 0)
        {
          uint field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetUint32(stateObject, 8);
          }
          data.field8.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetUint64Count(stateObject, 9) > 0)
        {
          ulong field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetUint64(stateObject, 9);
          }
          data.field9.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetSint32Count(stateObject, 10) > 0)
        {
          int field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetSint32(stateObject, 10);
          }
          data.field10.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetSint64Count(stateObject, 11) > 0)
        {
          long field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetSint64(stateObject, 11);
          }
          data.field11.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetFixed32Count(stateObject, 12) > 0)
        {
          uint field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetFixed32(stateObject, 12);
          }
          data.field12.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetFixed64Count(stateObject, 13) > 0)
        {
          ulong field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetFixed64(stateObject, 13);
          }
          data.field13.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetSfixed32Count(stateObject, 14) > 0)
        {
          int field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetSfixed32(stateObject, 14);
          }
          data.field14.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetSfixed64Count(stateObject, 15) > 0)
        {
          long field;
          {
            field = global::Improbable.Worker.Internal.Pbio.GetSfixed64(stateObject, 15);
          }
          data.field15.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetInt64Count(stateObject, 16) > 0)
        {
          global::Improbable.EntityId field;
          {
            field = new global::Improbable.EntityId(global::Improbable.Worker.Internal.Pbio.GetInt64(stateObject, 16));
          }
          data.field16.Set(field);
        }
        if (global::Improbable.Worker.Internal.Pbio.GetObjectCount(stateObject, 17) > 0)
        {
          global::Improbable.Gdk.Tests.SomeType field;
          {
            field = global::Improbable.Gdk.Tests.SomeType_Internal.Read(global::Improbable.Worker.Internal.Pbio.GetObject(stateObject, 17));
          }
          data.field17.Set(field);
        }
        **handleOut = global::Improbable.Worker.Internal.ClientHandles.Instance.CreateHandle(data);
      }
      else if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Snapshot)
      {
        var data = new Data(global::Improbable.Gdk.Tests.ExhaustiveSingularData_Internal.Read(
            global::Improbable.Worker.Internal.Pbio.GetObject(root, 197715)));
        **handleOut = global::Improbable.Worker.Internal.ClientHandles.Instance.CreateHandle(data);
      }
      else if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Request)
      {
        var data = new global::Improbable.Worker.Internal.GenericCommandObject();
        **handleOut = global::Improbable.Worker.Internal.ClientHandles.Instance.CreateHandle(data);
        return 0;
      }
      else if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Response)
      {
        var data = new global::Improbable.Worker.Internal.GenericCommandObject();
        **handleOut = global::Improbable.Worker.Internal.ClientHandles.Instance.CreateHandle(data);
        return 0;
      }
    }
    catch (global::System.Exception e)
    {
      global::Improbable.Worker.ClientError.LogClientException(e);
      return 0;
    }
    return 1;
  }

  [global::Improbable.Worker.Internal.MonoPInvokeCallback(typeof(global::Improbable.Worker.Internal.ComponentProtocol.ClientSerialize))]
  private static unsafe void
  ClientSerialize(global::System.UInt32 componentId,
                  global::System.Byte handleType,
                  global::Improbable.Worker.Internal.ComponentProtocol.ClientHandle* handle,
                  global::Improbable.Worker.Internal.Pbio.Object* root)
  {
    try
    {
      var _pool = global::Improbable.Worker.Internal.ClientHandles.Instance.GetGcHandlePool(*handle);
      if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Update) {
        var data = (Update) global::Improbable.Worker.Internal.ClientHandles.Instance.Dereference(*handle);
        var stateObject = global::Improbable.Worker.Internal.Pbio.AddObject(
            global::Improbable.Worker.Internal.Pbio.AddObject(root, /* entity_state */ 2), 197715);
        if (data.field1.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddBool(stateObject, 1, (byte) (data.field1.Value ? 1 : 0));
          }
        }
        if (data.field2.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddFloat(stateObject, 2, data.field2.Value);
          }
        }
        if (data.field4.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddInt32(stateObject, 4, data.field4.Value);
          }
        }
        if (data.field5.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddInt64(stateObject, 5, data.field5.Value);
          }
        }
        if (data.field6.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddDouble(stateObject, 6, data.field6.Value);
          }
        }
        if (data.field7.HasValue)
        {
          {
            if (data.field7.Value != null)
            {
              var _buffer = global::System.Text.Encoding.UTF8.GetBytes(data.field7.Value);
              global::Improbable.Worker.Internal.Pbio.AddBytes(stateObject, 7, (byte*) _pool.Pin(_buffer), (uint) _buffer.Length);
            }
            else{
              global::Improbable.Worker.Internal.Pbio.AddBytes(stateObject, 7, null, 0);
            }
          }
        }
        if (data.field8.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddUint32(stateObject, 8, data.field8.Value);
          }
        }
        if (data.field9.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddUint64(stateObject, 9, data.field9.Value);
          }
        }
        if (data.field10.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddSint32(stateObject, 10, data.field10.Value);
          }
        }
        if (data.field11.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddSint64(stateObject, 11, data.field11.Value);
          }
        }
        if (data.field12.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddFixed32(stateObject, 12, data.field12.Value);
          }
        }
        if (data.field13.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddFixed64(stateObject, 13, data.field13.Value);
          }
        }
        if (data.field14.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddSfixed32(stateObject, 14, data.field14.Value);
          }
        }
        if (data.field15.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddSfixed64(stateObject, 15, data.field15.Value);
          }
        }
        if (data.field16.HasValue)
        {
          {
            global::Improbable.Worker.Internal.Pbio.AddInt64(stateObject, 16, data.field16.Value.Id);
          }
        }
        if (data.field17.HasValue)
        {
          {
            global::Improbable.Gdk.Tests.SomeType_Internal.Write(_pool, data.field17.Value, global::Improbable.Worker.Internal.Pbio.AddObject(stateObject, 17));
          }
        }
      }
      else if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Snapshot) {
        var data = (Data) global::Improbable.Worker.Internal.ClientHandles.Instance.Dereference(*handle);
        global::Improbable.Gdk.Tests.ExhaustiveSingularData_Internal.Write(_pool, data.Value, global::Improbable.Worker.Internal.Pbio.AddObject(root, 197715));
      }
      else if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Request)
      {
        global::Improbable.Worker.Internal.Pbio.AddObject(root, 197715);
      }
      else if (handleType == (byte) global::Improbable.Worker.Internal.ComponentProtocol.ClientHandleType.Response)
      {
        global::Improbable.Worker.Internal.Pbio.AddObject(root, 197715);
      }
    }
    catch (global::System.Exception e)
    {
      global::Improbable.Worker.ClientError.LogClientException(e);
    }
  }
}

}
