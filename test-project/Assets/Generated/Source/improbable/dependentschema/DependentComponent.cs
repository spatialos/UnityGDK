// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable.DependentSchema
{
    public partial class DependentComponent
    {
        public const uint ComponentId = 198800;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            internal uint aHandle;

            public global::Improbable.TestSchema.ExhaustiveRepeatedData A
            {
                get => global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.AProvider.Get(aHandle);
                set
                {
                    MarkDataDirty(0);
                    global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.AProvider.Set(aHandle, value);
                }
            }

            private global::Improbable.TestSchema.SomeEnum b;

            public global::Improbable.TestSchema.SomeEnum B
            {
                get => b;
                set
                {
                    MarkDataDirty(1);
                    this.b = value;
                }
            }

            internal uint cHandle;

            public global::Improbable.TestSchema.SomeEnum? C
            {
                get => global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.CProvider.Get(cHandle);
                set
                {
                    MarkDataDirty(2);
                    global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.CProvider.Set(cHandle, value);
                }
            }

            internal uint dHandle;

            public global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType> D
            {
                get => global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.DProvider.Get(dHandle);
                set
                {
                    MarkDataDirty(3);
                    global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.DProvider.Set(dHandle, value);
                }
            }

            internal uint eHandle;

            public global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType> E
            {
                get => global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.EProvider.Get(eHandle);
                set
                {
                    MarkDataDirty(4);
                    global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.EProvider.Set(eHandle, value);
                }
            }

            public bool IsDataDirty()
            {
                var isDataDirty = false;

                isDataDirty |= (dirtyBits[0] != 0x0);

                return isDataDirty;
            }

            /*
            The propertyIndex argument counts up from 0 in the order defined in your schema component.
            It is not the schema field number itself. For example:
            component MyComponent
            {
                id = 1337;
                bool val_a = 1;
                bool val_b = 3;
            }
            In that case, val_a corresponds to propertyIndex 0 and val_b corresponds to propertyIndex 1 in this method.
            This method throws an InvalidOperationException in case your component doesn't contain properties.
            */

            public bool IsDataDirty(int propertyIndex)
            {
                ValidateFieldIndex(propertyIndex);

                // Retrieve the dirtyBits[0-n] field that tracks this property.
                var dirtyBitsByteIndex = propertyIndex >> 4;
                return (dirtyBits[dirtyBitsByteIndex] & (0x1 << (propertyIndex & 31))) != 0x0;
            }

            // Like the IsDataDirty() method above, the propertyIndex arguments starts counting from 0.
            // This method throws an InvalidOperationException in case your component doesn't contain properties.
            public void MarkDataDirty(int propertyIndex)
            {
                ValidateFieldIndex(propertyIndex);

                // Retrieve the dirtyBits[0-n] field that tracks this property.
                var dirtyBitsByteIndex = propertyIndex >> 4;
                dirtyBits[dirtyBitsByteIndex] |= (UInt32) (0x1 << (propertyIndex & 31));
            }

            public void MarkDataClean()
            {
                dirtyBits[0] = 0x0;
            }

            [Conditional("DEBUG")]
            private void ValidateFieldIndex(int propertyIndex)
            {
                if (propertyIndex < 0 || propertyIndex >= 5)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 4]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(198800, SchemaComponentData.Create());
                Serialization.SerializeComponent(this, componentDataSchema.SchemaData.Value.GetFields(), world);
                var snapshot = Serialization.DeserializeSnapshot(componentDataSchema.SchemaData.Value.GetFields());

                componentDataSchema.SchemaData?.Destroy();
                componentDataSchema.SchemaData = null;

                return snapshot;
            }
        }

        public struct ComponentAuthority : ISharedComponentData, IEquatable<ComponentAuthority>
        {
            public bool HasAuthority;

            public ComponentAuthority(bool hasAuthority)
            {
                HasAuthority = hasAuthority;
            }

            // todo think about whether any of this is necessary
            // Unity does a bitwise equality check so this is just for users reading the struct
            public static readonly ComponentAuthority NotAuthoritative = new ComponentAuthority(false);
            public static readonly ComponentAuthority Authoritative = new ComponentAuthority(true);

            public bool Equals(ComponentAuthority other)
            {
                return this == other;
            }

            public override bool Equals(object obj)
            {
                return obj is ComponentAuthority auth && this == auth;
            }

            public override int GetHashCode()
            {
                return HasAuthority.GetHashCode();
            }

            public static bool operator ==(ComponentAuthority a, ComponentAuthority b)
            {
                return a.HasAuthority == b.HasAuthority;
            }

            public static bool operator !=(ComponentAuthority a, ComponentAuthority b)
            {
                return !(a == b);
            }
        }

        [global::System.Serializable]
        public struct Snapshot : ISpatialComponentSnapshot
        {
            public uint ComponentId => 198800;

            public global::Improbable.TestSchema.ExhaustiveRepeatedData A;
            public global::Improbable.TestSchema.SomeEnum B;
            public global::Improbable.TestSchema.SomeEnum? C;
            public global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType> D;
            public global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType> E;

            public Snapshot(global::Improbable.TestSchema.ExhaustiveRepeatedData a, global::Improbable.TestSchema.SomeEnum b, global::Improbable.TestSchema.SomeEnum? c, global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType> d, global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType> e)
            {
                A = a;
                B = b;
                C = c;
                D = d;
                E = e;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.DependentSchema.DependentComponent.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Serialize(component.A, obj.AddObject(1));

                obj.AddEnum(2, (uint) component.B);

                if (component.C.HasValue)
                {
                    obj.AddEnum(3, (uint) component.C.Value);
                }

                foreach (var value in component.D)
                {
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(value, obj.AddObject(4));
                }

                foreach (var keyValuePair in component.E)
                {
                    var mapObj = obj.AddObject(5);
                    mapObj.AddEnum(1, (uint) keyValuePair.Key);
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                }
            }

            public static void SerializeUpdate(global::Improbable.DependentSchema.DependentComponent.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Serialize(component.A, obj.AddObject(1));

                    
                }

                if (component.IsDataDirty(1))
                {
                    obj.AddEnum(2, (uint) component.B);

                    
                }

                if (component.IsDataDirty(2))
                {
                    if (component.C.HasValue)
                    {
                        obj.AddEnum(3, (uint) component.C.Value);
                    }

                    if (!component.C.HasValue)
                    {
                        updateObj.AddClearedField(3);
                    }
                }

                if (component.IsDataDirty(3))
                {
                    foreach (var value in component.D)
                    {
                        global::Improbable.TestSchema.SomeType.Serialization.Serialize(value, obj.AddObject(4));
                    }

                    if (component.D.Count == 0)
                    {
                        updateObj.AddClearedField(4);
                    }
                }

                if (component.IsDataDirty(4))
                {
                    foreach (var keyValuePair in component.E)
                    {
                        var mapObj = obj.AddObject(5);
                        mapObj.AddEnum(1, (uint) keyValuePair.Key);
                        global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                    }

                    if (component.E.Count == 0)
                    {
                        updateObj.AddClearedField(5);
                    }
                }
            }

            public static void SerializeUpdate(global::Improbable.DependentSchema.DependentComponent.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.A.HasValue)
                    {
                        var field = update.A.Value;

                        global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Serialize(field, obj.AddObject(1));

                        
                    }
                }

                {
                    if (update.B.HasValue)
                    {
                        var field = update.B.Value;

                        obj.AddEnum(2, (uint) field);

                        
                    }
                }

                {
                    if (update.C.HasValue)
                    {
                        var field = update.C.Value;

                        if (field.HasValue)
                        {
                            obj.AddEnum(3, (uint) field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(3);
                        }
                    }
                }

                {
                    if (update.D.HasValue)
                    {
                        var field = update.D.Value;

                        foreach (var value in field)
                        {
                            global::Improbable.TestSchema.SomeType.Serialization.Serialize(value, obj.AddObject(4));
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(4);
                        }
                    }
                }

                {
                    if (update.E.HasValue)
                    {
                        var field = update.E.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(5);
                            mapObj.AddEnum(1, (uint) keyValuePair.Key);
                            global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(5);
                        }
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.DependentSchema.DependentComponent.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Serialize(snapshot.A, obj.AddObject(1));

                obj.AddEnum(2, (uint) snapshot.B);

                if (snapshot.C.HasValue)
                {
                    obj.AddEnum(3, (uint) snapshot.C.Value);
                }

                foreach (var value in snapshot.D)
                {
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(value, obj.AddObject(4));
                }

                foreach (var keyValuePair in snapshot.E)
                {
                    var mapObj = obj.AddObject(5);
                    mapObj.AddEnum(1, (uint) keyValuePair.Key);
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                }
            }

            public static global::Improbable.DependentSchema.DependentComponent.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.DependentSchema.DependentComponent.Component();

                component.aHandle = global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.AProvider.Allocate(world);

                component.A = global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Deserialize(obj.GetObject(1));

                component.B = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(2);

                component.cHandle = global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.CProvider.Allocate(world);

                if (obj.GetEnumCount(3) == 1)
                {
                    component.C = new global::Improbable.TestSchema.SomeEnum?((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(3));
                }

                component.dHandle = global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.DProvider.Allocate(world);

                {
                    component.D = new global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>();
                    var list = component.D;
                    var listLength = obj.GetObjectCount(4);

                    for (var i = 0; i < listLength; i++)
                    {
                        list.Add(global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.IndexObject(4, (uint) i)));
                    }
                }

                component.eHandle = global::Improbable.DependentSchema.DependentComponent.ReferenceTypeProviders.EProvider.Allocate(world);

                {
                    var map = new global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType>();
                    var mapSize = obj.GetObjectCount(5);
                    component.E = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                return component;
            }

            public static global::Improbable.DependentSchema.DependentComponent.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.DependentSchema.DependentComponent.Update();
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    update.A = global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Deserialize(obj.GetObject(1));
                }

                if (obj.GetEnumCount(2) == 1)
                {
                    update.B = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(2);
                }

                {
                    var isCleared = updateObj.IsFieldCleared(3);

                    if (isCleared)
                    {
                        update.C = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeEnum?>(new global::Improbable.TestSchema.SomeEnum?());
                    }
                    else if (obj.GetEnumCount(3) == 1)
                    {
                        update.C = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeEnum?>((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(3));
                    }
                }

                {
                    var listSize = obj.GetObjectCount(4);

                    var isCleared = updateObj.IsFieldCleared(4);

                    if (listSize > 0 || isCleared)
                    {
                        update.D = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>>(new global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>());
                    }

                    for (var i = 0; i < listSize; i++)
                    {
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.IndexObject(4, (uint) i));
                        update.D.Value.Add(value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(5);

                    var isCleared = updateObj.IsFieldCleared(5);

                    if (mapSize > 0 || isCleared)
                    {
                        update.E = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType>>(new global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        update.E.Value.Add(key, value);
                    }
                }

                return update;
            }

            public static global::Improbable.DependentSchema.DependentComponent.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.DependentSchema.DependentComponent.Update();
                var obj = data.GetFields();

                update.A = global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Deserialize(obj.GetObject(1));

                update.B = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(2);

                if (obj.GetEnumCount(3) == 1)
                {
                    update.C = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeEnum?>((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(3));
                }

                {
                    var listSize = obj.GetObjectCount(4);
                    update.D = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>>(new global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>());

                    for (var i = 0; i < listSize; i++)
                    {
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.IndexObject(4, (uint) i));
                        update.D.Value.Add(value);
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType>();
                    var mapSize = obj.GetObjectCount(5);
                    update.E = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                return update;
            }

            public static global::Improbable.DependentSchema.DependentComponent.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.DependentSchema.DependentComponent.Snapshot();

                component.A = global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Deserialize(obj.GetObject(1));

                component.B = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(2);

                if (obj.GetEnumCount(3) == 1)
                {
                    component.C = new global::Improbable.TestSchema.SomeEnum?((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(3));
                }

                {
                    component.D = new global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>();
                    var list = component.D;
                    var listLength = obj.GetObjectCount(4);

                    for (var i = 0; i < listLength; i++)
                    {
                        list.Add(global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.IndexObject(4, (uint) i)));
                    }
                }

                {
                    var map = new global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType>();
                    var mapSize = obj.GetObjectCount(5);
                    component.E = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.DependentSchema.DependentComponent.Component component)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    component.A = global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Deserialize(obj.GetObject(1));
                }

                if (obj.GetEnumCount(2) == 1)
                {
                    component.B = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(2);
                }

                {
                    var isCleared = updateObj.IsFieldCleared(3);

                    if (isCleared)
                    {
                        component.C = new global::Improbable.TestSchema.SomeEnum?();
                    }
                    else if (obj.GetEnumCount(3) == 1)
                    {
                        var value = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(3);
                        component.C = new global::Improbable.TestSchema.SomeEnum?(value);
                    }
                }

                {
                    var listSize = obj.GetObjectCount(4);

                    var isCleared = updateObj.IsFieldCleared(4);

                    if (listSize > 0 || isCleared)
                    {
                        component.D.Clear();
                    }

                    for (var i = 0; i < listSize; i++)
                    {
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.IndexObject(4, (uint) i));
                        component.D.Add(value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(5);

                    var isCleared = updateObj.IsFieldCleared(5);

                    if (mapSize > 0 || isCleared)
                    {
                        component.E.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        component.E.Add(key, value);
                    }
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.DependentSchema.DependentComponent.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    snapshot.A = global::Improbable.TestSchema.ExhaustiveRepeatedData.Serialization.Deserialize(obj.GetObject(1));
                }

                if (obj.GetEnumCount(2) == 1)
                {
                    snapshot.B = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(2);
                }

                {
                    var isCleared = updateObj.IsFieldCleared(3);

                    if (isCleared)
                    {
                        snapshot.C = new global::Improbable.TestSchema.SomeEnum?();
                    }
                    else if (obj.GetEnumCount(3) == 1)
                    {
                        var value = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(3);
                        snapshot.C = new global::Improbable.TestSchema.SomeEnum?(value);
                    }
                }

                {
                    var listSize = obj.GetObjectCount(4);

                    var isCleared = updateObj.IsFieldCleared(4);

                    if (listSize > 0 || isCleared)
                    {
                        snapshot.D.Clear();
                    }

                    for (var i = 0; i < listSize; i++)
                    {
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.IndexObject(4, (uint) i));
                        snapshot.D.Add(value);
                    }
                }

                {
                    var mapSize = obj.GetObjectCount(5);

                    var isCleared = updateObj.IsFieldCleared(5);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.E.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(5, (uint) i);
                        var key = (global::Improbable.TestSchema.SomeEnum) mapObj.GetEnum(1);
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(mapObj.GetObject(2));
                        snapshot.E.Add(key, value);
                    }
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<global::Improbable.TestSchema.ExhaustiveRepeatedData> A;
            public Option<global::Improbable.TestSchema.SomeEnum> B;
            public Option<global::Improbable.TestSchema.SomeEnum?> C;
            public Option<global::System.Collections.Generic.List<global::Improbable.TestSchema.SomeType>> D;
            public Option<global::System.Collections.Generic.Dictionary<global::Improbable.TestSchema.SomeEnum, global::Improbable.TestSchema.SomeType>> E;
        }

        internal class DependentComponentDynamic : IDynamicInvokable
        {
            public uint ComponentId => DependentComponent.ComponentId;

            internal static Dynamic.VTable<Update, Snapshot> VTable = new Dynamic.VTable<Update, Snapshot>
            {
                DeserializeSnapshot = DeserializeSnapshot,
                SerializeSnapshot = SerializeSnapshot,
                DeserializeSnapshotRaw = Serialization.DeserializeSnapshot,
                SerializeSnapshotRaw = Serialization.SerializeSnapshot,
                ConvertSnapshotToUpdate = SnapshotToUpdate
            };

            private static Snapshot DeserializeSnapshot(ComponentData snapshot)
            {
                var schemaDataOpt = snapshot.SchemaData;
                if (!schemaDataOpt.HasValue)
                {
                    throw new ArgumentException($"Can not deserialize an empty {nameof(ComponentData)}");
                }

                return Serialization.DeserializeSnapshot(schemaDataOpt.Value.GetFields());
            }

            private static void SerializeSnapshot(Snapshot snapshot, ComponentData data)
            {
                var schemaDataOpt = data.SchemaData;
                if (!schemaDataOpt.HasValue)
                {
                    throw new ArgumentException($"Can not serialise an empty {nameof(ComponentData)}");
                }

                Serialization.SerializeSnapshot(snapshot, data.SchemaData.Value.GetFields());
            }

            private static Update SnapshotToUpdate(in Snapshot snapshot)
            {
                var update = new Update
                {
                    A = snapshot.A,
                    B = snapshot.B,
                    C = snapshot.C,
                    D = snapshot.D,
                    E = snapshot.E
                };

                return update;
            }

            public void InvokeHandler(Dynamic.IHandler handler)
            {
                handler.Accept<Update, Snapshot>(ComponentId, VTable);
            }
        }
    }
}
