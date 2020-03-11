// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable.TestSchema
{
    public partial class ExhaustiveOptional
    {
        public const uint ComponentId = 197716;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            internal uint field1Handle;

            public bool? Field1
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field1Provider.Get(field1Handle);
                set
                {
                    MarkDataDirty(0);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field1Provider.Set(field1Handle, value);
                }
            }

            internal uint field2Handle;

            public float? Field2
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field2Provider.Get(field2Handle);
                set
                {
                    MarkDataDirty(1);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field2Provider.Set(field2Handle, value);
                }
            }

            internal uint field3Handle;

            public global::Improbable.Gdk.Core.Option<byte[]> Field3
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field3Provider.Get(field3Handle);
                set
                {
                    MarkDataDirty(2);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field3Provider.Set(field3Handle, value);
                }
            }

            internal uint field4Handle;

            public int? Field4
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field4Provider.Get(field4Handle);
                set
                {
                    MarkDataDirty(3);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field4Provider.Set(field4Handle, value);
                }
            }

            internal uint field5Handle;

            public long? Field5
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field5Provider.Get(field5Handle);
                set
                {
                    MarkDataDirty(4);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field5Provider.Set(field5Handle, value);
                }
            }

            internal uint field6Handle;

            public double? Field6
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field6Provider.Get(field6Handle);
                set
                {
                    MarkDataDirty(5);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field6Provider.Set(field6Handle, value);
                }
            }

            internal uint field7Handle;

            public global::Improbable.Gdk.Core.Option<string> Field7
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field7Provider.Get(field7Handle);
                set
                {
                    MarkDataDirty(6);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field7Provider.Set(field7Handle, value);
                }
            }

            internal uint field8Handle;

            public uint? Field8
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field8Provider.Get(field8Handle);
                set
                {
                    MarkDataDirty(7);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field8Provider.Set(field8Handle, value);
                }
            }

            internal uint field9Handle;

            public ulong? Field9
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field9Provider.Get(field9Handle);
                set
                {
                    MarkDataDirty(8);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field9Provider.Set(field9Handle, value);
                }
            }

            internal uint field10Handle;

            public int? Field10
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field10Provider.Get(field10Handle);
                set
                {
                    MarkDataDirty(9);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field10Provider.Set(field10Handle, value);
                }
            }

            internal uint field11Handle;

            public long? Field11
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field11Provider.Get(field11Handle);
                set
                {
                    MarkDataDirty(10);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field11Provider.Set(field11Handle, value);
                }
            }

            internal uint field12Handle;

            public uint? Field12
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field12Provider.Get(field12Handle);
                set
                {
                    MarkDataDirty(11);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field12Provider.Set(field12Handle, value);
                }
            }

            internal uint field13Handle;

            public ulong? Field13
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field13Provider.Get(field13Handle);
                set
                {
                    MarkDataDirty(12);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field13Provider.Set(field13Handle, value);
                }
            }

            internal uint field14Handle;

            public int? Field14
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field14Provider.Get(field14Handle);
                set
                {
                    MarkDataDirty(13);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field14Provider.Set(field14Handle, value);
                }
            }

            internal uint field15Handle;

            public long? Field15
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field15Provider.Get(field15Handle);
                set
                {
                    MarkDataDirty(14);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field15Provider.Set(field15Handle, value);
                }
            }

            internal uint field16Handle;

            public global::Improbable.Gdk.Core.EntityId? Field16
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field16Provider.Get(field16Handle);
                set
                {
                    MarkDataDirty(15);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field16Provider.Set(field16Handle, value);
                }
            }

            internal uint field17Handle;

            public global::Improbable.TestSchema.SomeType? Field17
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field17Provider.Get(field17Handle);
                set
                {
                    MarkDataDirty(16);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field17Provider.Set(field17Handle, value);
                }
            }

            internal uint field18Handle;

            public global::Improbable.TestSchema.SomeEnum? Field18
            {
                get => global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field18Provider.Get(field18Handle);
                set
                {
                    MarkDataDirty(17);
                    global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field18Provider.Set(field18Handle, value);
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
                if (propertyIndex < 0 || propertyIndex >= 18)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 17]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(197716, SchemaComponentData.Create());
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
            public uint ComponentId => 197716;

            public bool? Field1;
            public float? Field2;
            public global::Improbable.Gdk.Core.Option<byte[]> Field3;
            public int? Field4;
            public long? Field5;
            public double? Field6;
            public global::Improbable.Gdk.Core.Option<string> Field7;
            public uint? Field8;
            public ulong? Field9;
            public int? Field10;
            public long? Field11;
            public uint? Field12;
            public ulong? Field13;
            public int? Field14;
            public long? Field15;
            public global::Improbable.Gdk.Core.EntityId? Field16;
            public global::Improbable.TestSchema.SomeType? Field17;
            public global::Improbable.TestSchema.SomeEnum? Field18;

            public Snapshot(bool? field1, float? field2, global::Improbable.Gdk.Core.Option<byte[]> field3, int? field4, long? field5, double? field6, global::Improbable.Gdk.Core.Option<string> field7, uint? field8, ulong? field9, int? field10, long? field11, uint? field12, ulong? field13, int? field14, long? field15, global::Improbable.Gdk.Core.EntityId? field16, global::Improbable.TestSchema.SomeType? field17, global::Improbable.TestSchema.SomeEnum? field18)
            {
                Field1 = field1;
                Field2 = field2;
                Field3 = field3;
                Field4 = field4;
                Field5 = field5;
                Field6 = field6;
                Field7 = field7;
                Field8 = field8;
                Field9 = field9;
                Field10 = field10;
                Field11 = field11;
                Field12 = field12;
                Field13 = field13;
                Field14 = field14;
                Field15 = field15;
                Field16 = field16;
                Field17 = field17;
                Field18 = field18;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.TestSchema.ExhaustiveOptional.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                if (component.Field1.HasValue)
                {
                    obj.AddBool(1, component.Field1.Value);
                }

                if (component.Field2.HasValue)
                {
                    obj.AddFloat(2, component.Field2.Value);
                }

                if (component.Field3.HasValue)
                {
                    obj.AddBytes(3, component.Field3.Value);
                }

                if (component.Field4.HasValue)
                {
                    obj.AddInt32(4, component.Field4.Value);
                }

                if (component.Field5.HasValue)
                {
                    obj.AddInt64(5, component.Field5.Value);
                }

                if (component.Field6.HasValue)
                {
                    obj.AddDouble(6, component.Field6.Value);
                }

                if (component.Field7.HasValue)
                {
                    obj.AddString(7, component.Field7.Value);
                }

                if (component.Field8.HasValue)
                {
                    obj.AddUint32(8, component.Field8.Value);
                }

                if (component.Field9.HasValue)
                {
                    obj.AddUint64(9, component.Field9.Value);
                }

                if (component.Field10.HasValue)
                {
                    obj.AddSint32(10, component.Field10.Value);
                }

                if (component.Field11.HasValue)
                {
                    obj.AddSint64(11, component.Field11.Value);
                }

                if (component.Field12.HasValue)
                {
                    obj.AddFixed32(12, component.Field12.Value);
                }

                if (component.Field13.HasValue)
                {
                    obj.AddFixed64(13, component.Field13.Value);
                }

                if (component.Field14.HasValue)
                {
                    obj.AddSfixed32(14, component.Field14.Value);
                }

                if (component.Field15.HasValue)
                {
                    obj.AddSfixed64(15, component.Field15.Value);
                }

                if (component.Field16.HasValue)
                {
                    obj.AddEntityId(16, component.Field16.Value);
                }

                if (component.Field17.HasValue)
                {
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(component.Field17.Value, obj.AddObject(17));
                }

                if (component.Field18.HasValue)
                {
                    obj.AddEnum(18, (uint) component.Field18.Value);
                }
            }

            public static void SerializeUpdate(global::Improbable.TestSchema.ExhaustiveOptional.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    if (component.Field1.HasValue)
                    {
                        obj.AddBool(1, component.Field1.Value);
                    }

                    if (!component.Field1.HasValue)
                    {
                        updateObj.AddClearedField(1);
                    }
                }

                if (component.IsDataDirty(1))
                {
                    if (component.Field2.HasValue)
                    {
                        obj.AddFloat(2, component.Field2.Value);
                    }

                    if (!component.Field2.HasValue)
                    {
                        updateObj.AddClearedField(2);
                    }
                }

                if (component.IsDataDirty(2))
                {
                    if (component.Field3.HasValue)
                    {
                        obj.AddBytes(3, component.Field3.Value);
                    }

                    if (!component.Field3.HasValue)
                    {
                        updateObj.AddClearedField(3);
                    }
                }

                if (component.IsDataDirty(3))
                {
                    if (component.Field4.HasValue)
                    {
                        obj.AddInt32(4, component.Field4.Value);
                    }

                    if (!component.Field4.HasValue)
                    {
                        updateObj.AddClearedField(4);
                    }
                }

                if (component.IsDataDirty(4))
                {
                    if (component.Field5.HasValue)
                    {
                        obj.AddInt64(5, component.Field5.Value);
                    }

                    if (!component.Field5.HasValue)
                    {
                        updateObj.AddClearedField(5);
                    }
                }

                if (component.IsDataDirty(5))
                {
                    if (component.Field6.HasValue)
                    {
                        obj.AddDouble(6, component.Field6.Value);
                    }

                    if (!component.Field6.HasValue)
                    {
                        updateObj.AddClearedField(6);
                    }
                }

                if (component.IsDataDirty(6))
                {
                    if (component.Field7.HasValue)
                    {
                        obj.AddString(7, component.Field7.Value);
                    }

                    if (!component.Field7.HasValue)
                    {
                        updateObj.AddClearedField(7);
                    }
                }

                if (component.IsDataDirty(7))
                {
                    if (component.Field8.HasValue)
                    {
                        obj.AddUint32(8, component.Field8.Value);
                    }

                    if (!component.Field8.HasValue)
                    {
                        updateObj.AddClearedField(8);
                    }
                }

                if (component.IsDataDirty(8))
                {
                    if (component.Field9.HasValue)
                    {
                        obj.AddUint64(9, component.Field9.Value);
                    }

                    if (!component.Field9.HasValue)
                    {
                        updateObj.AddClearedField(9);
                    }
                }

                if (component.IsDataDirty(9))
                {
                    if (component.Field10.HasValue)
                    {
                        obj.AddSint32(10, component.Field10.Value);
                    }

                    if (!component.Field10.HasValue)
                    {
                        updateObj.AddClearedField(10);
                    }
                }

                if (component.IsDataDirty(10))
                {
                    if (component.Field11.HasValue)
                    {
                        obj.AddSint64(11, component.Field11.Value);
                    }

                    if (!component.Field11.HasValue)
                    {
                        updateObj.AddClearedField(11);
                    }
                }

                if (component.IsDataDirty(11))
                {
                    if (component.Field12.HasValue)
                    {
                        obj.AddFixed32(12, component.Field12.Value);
                    }

                    if (!component.Field12.HasValue)
                    {
                        updateObj.AddClearedField(12);
                    }
                }

                if (component.IsDataDirty(12))
                {
                    if (component.Field13.HasValue)
                    {
                        obj.AddFixed64(13, component.Field13.Value);
                    }

                    if (!component.Field13.HasValue)
                    {
                        updateObj.AddClearedField(13);
                    }
                }

                if (component.IsDataDirty(13))
                {
                    if (component.Field14.HasValue)
                    {
                        obj.AddSfixed32(14, component.Field14.Value);
                    }

                    if (!component.Field14.HasValue)
                    {
                        updateObj.AddClearedField(14);
                    }
                }

                if (component.IsDataDirty(14))
                {
                    if (component.Field15.HasValue)
                    {
                        obj.AddSfixed64(15, component.Field15.Value);
                    }

                    if (!component.Field15.HasValue)
                    {
                        updateObj.AddClearedField(15);
                    }
                }

                if (component.IsDataDirty(15))
                {
                    if (component.Field16.HasValue)
                    {
                        obj.AddEntityId(16, component.Field16.Value);
                    }

                    if (!component.Field16.HasValue)
                    {
                        updateObj.AddClearedField(16);
                    }
                }

                if (component.IsDataDirty(16))
                {
                    if (component.Field17.HasValue)
                    {
                        global::Improbable.TestSchema.SomeType.Serialization.Serialize(component.Field17.Value, obj.AddObject(17));
                    }

                    if (!component.Field17.HasValue)
                    {
                        updateObj.AddClearedField(17);
                    }
                }

                if (component.IsDataDirty(17))
                {
                    if (component.Field18.HasValue)
                    {
                        obj.AddEnum(18, (uint) component.Field18.Value);
                    }

                    if (!component.Field18.HasValue)
                    {
                        updateObj.AddClearedField(18);
                    }
                }
            }

            public static void SerializeUpdate(global::Improbable.TestSchema.ExhaustiveOptional.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.Field1.HasValue)
                    {
                        var field = update.Field1.Value;

                        if (field.HasValue)
                        {
                            obj.AddBool(1, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(1);
                        }
                    }
                }

                {
                    if (update.Field2.HasValue)
                    {
                        var field = update.Field2.Value;

                        if (field.HasValue)
                        {
                            obj.AddFloat(2, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(2);
                        }
                    }
                }

                {
                    if (update.Field3.HasValue)
                    {
                        var field = update.Field3.Value;

                        if (field.HasValue)
                        {
                            obj.AddBytes(3, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(3);
                        }
                    }
                }

                {
                    if (update.Field4.HasValue)
                    {
                        var field = update.Field4.Value;

                        if (field.HasValue)
                        {
                            obj.AddInt32(4, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(4);
                        }
                    }
                }

                {
                    if (update.Field5.HasValue)
                    {
                        var field = update.Field5.Value;

                        if (field.HasValue)
                        {
                            obj.AddInt64(5, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(5);
                        }
                    }
                }

                {
                    if (update.Field6.HasValue)
                    {
                        var field = update.Field6.Value;

                        if (field.HasValue)
                        {
                            obj.AddDouble(6, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(6);
                        }
                    }
                }

                {
                    if (update.Field7.HasValue)
                    {
                        var field = update.Field7.Value;

                        if (field.HasValue)
                        {
                            obj.AddString(7, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(7);
                        }
                    }
                }

                {
                    if (update.Field8.HasValue)
                    {
                        var field = update.Field8.Value;

                        if (field.HasValue)
                        {
                            obj.AddUint32(8, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(8);
                        }
                    }
                }

                {
                    if (update.Field9.HasValue)
                    {
                        var field = update.Field9.Value;

                        if (field.HasValue)
                        {
                            obj.AddUint64(9, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(9);
                        }
                    }
                }

                {
                    if (update.Field10.HasValue)
                    {
                        var field = update.Field10.Value;

                        if (field.HasValue)
                        {
                            obj.AddSint32(10, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(10);
                        }
                    }
                }

                {
                    if (update.Field11.HasValue)
                    {
                        var field = update.Field11.Value;

                        if (field.HasValue)
                        {
                            obj.AddSint64(11, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(11);
                        }
                    }
                }

                {
                    if (update.Field12.HasValue)
                    {
                        var field = update.Field12.Value;

                        if (field.HasValue)
                        {
                            obj.AddFixed32(12, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(12);
                        }
                    }
                }

                {
                    if (update.Field13.HasValue)
                    {
                        var field = update.Field13.Value;

                        if (field.HasValue)
                        {
                            obj.AddFixed64(13, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(13);
                        }
                    }
                }

                {
                    if (update.Field14.HasValue)
                    {
                        var field = update.Field14.Value;

                        if (field.HasValue)
                        {
                            obj.AddSfixed32(14, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(14);
                        }
                    }
                }

                {
                    if (update.Field15.HasValue)
                    {
                        var field = update.Field15.Value;

                        if (field.HasValue)
                        {
                            obj.AddSfixed64(15, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(15);
                        }
                    }
                }

                {
                    if (update.Field16.HasValue)
                    {
                        var field = update.Field16.Value;

                        if (field.HasValue)
                        {
                            obj.AddEntityId(16, field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(16);
                        }
                    }
                }

                {
                    if (update.Field17.HasValue)
                    {
                        var field = update.Field17.Value;

                        if (field.HasValue)
                        {
                            global::Improbable.TestSchema.SomeType.Serialization.Serialize(field.Value, obj.AddObject(17));
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(17);
                        }
                    }
                }

                {
                    if (update.Field18.HasValue)
                    {
                        var field = update.Field18.Value;

                        if (field.HasValue)
                        {
                            obj.AddEnum(18, (uint) field.Value);
                        }

                        if (!field.HasValue)
                        {
                            updateObj.AddClearedField(18);
                        }
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.TestSchema.ExhaustiveOptional.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                if (snapshot.Field1.HasValue)
                {
                    obj.AddBool(1, snapshot.Field1.Value);
                }

                if (snapshot.Field2.HasValue)
                {
                    obj.AddFloat(2, snapshot.Field2.Value);
                }

                if (snapshot.Field3.HasValue)
                {
                    obj.AddBytes(3, snapshot.Field3.Value);
                }

                if (snapshot.Field4.HasValue)
                {
                    obj.AddInt32(4, snapshot.Field4.Value);
                }

                if (snapshot.Field5.HasValue)
                {
                    obj.AddInt64(5, snapshot.Field5.Value);
                }

                if (snapshot.Field6.HasValue)
                {
                    obj.AddDouble(6, snapshot.Field6.Value);
                }

                if (snapshot.Field7.HasValue)
                {
                    obj.AddString(7, snapshot.Field7.Value);
                }

                if (snapshot.Field8.HasValue)
                {
                    obj.AddUint32(8, snapshot.Field8.Value);
                }

                if (snapshot.Field9.HasValue)
                {
                    obj.AddUint64(9, snapshot.Field9.Value);
                }

                if (snapshot.Field10.HasValue)
                {
                    obj.AddSint32(10, snapshot.Field10.Value);
                }

                if (snapshot.Field11.HasValue)
                {
                    obj.AddSint64(11, snapshot.Field11.Value);
                }

                if (snapshot.Field12.HasValue)
                {
                    obj.AddFixed32(12, snapshot.Field12.Value);
                }

                if (snapshot.Field13.HasValue)
                {
                    obj.AddFixed64(13, snapshot.Field13.Value);
                }

                if (snapshot.Field14.HasValue)
                {
                    obj.AddSfixed32(14, snapshot.Field14.Value);
                }

                if (snapshot.Field15.HasValue)
                {
                    obj.AddSfixed64(15, snapshot.Field15.Value);
                }

                if (snapshot.Field16.HasValue)
                {
                    obj.AddEntityId(16, snapshot.Field16.Value);
                }

                if (snapshot.Field17.HasValue)
                {
                    global::Improbable.TestSchema.SomeType.Serialization.Serialize(snapshot.Field17.Value, obj.AddObject(17));
                }

                if (snapshot.Field18.HasValue)
                {
                    obj.AddEnum(18, (uint) snapshot.Field18.Value);
                }
            }

            public static global::Improbable.TestSchema.ExhaustiveOptional.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.TestSchema.ExhaustiveOptional.Component();

                component.field1Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field1Provider.Allocate(world);

                if (obj.GetBoolCount(1) == 1)
                {
                    component.Field1 = new bool?(obj.GetBool(1));
                }

                component.field2Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field2Provider.Allocate(world);

                if (obj.GetFloatCount(2) == 1)
                {
                    component.Field2 = new float?(obj.GetFloat(2));
                }

                component.field3Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field3Provider.Allocate(world);

                if (obj.GetBytesCount(3) == 1)
                {
                    component.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>(obj.GetBytes(3));
                }

                component.field4Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field4Provider.Allocate(world);

                if (obj.GetInt32Count(4) == 1)
                {
                    component.Field4 = new int?(obj.GetInt32(4));
                }

                component.field5Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field5Provider.Allocate(world);

                if (obj.GetInt64Count(5) == 1)
                {
                    component.Field5 = new long?(obj.GetInt64(5));
                }

                component.field6Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field6Provider.Allocate(world);

                if (obj.GetDoubleCount(6) == 1)
                {
                    component.Field6 = new double?(obj.GetDouble(6));
                }

                component.field7Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field7Provider.Allocate(world);

                if (obj.GetStringCount(7) == 1)
                {
                    component.Field7 = new global::Improbable.Gdk.Core.Option<string>(obj.GetString(7));
                }

                component.field8Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field8Provider.Allocate(world);

                if (obj.GetUint32Count(8) == 1)
                {
                    component.Field8 = new uint?(obj.GetUint32(8));
                }

                component.field9Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field9Provider.Allocate(world);

                if (obj.GetUint64Count(9) == 1)
                {
                    component.Field9 = new ulong?(obj.GetUint64(9));
                }

                component.field10Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field10Provider.Allocate(world);

                if (obj.GetSint32Count(10) == 1)
                {
                    component.Field10 = new int?(obj.GetSint32(10));
                }

                component.field11Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field11Provider.Allocate(world);

                if (obj.GetSint64Count(11) == 1)
                {
                    component.Field11 = new long?(obj.GetSint64(11));
                }

                component.field12Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field12Provider.Allocate(world);

                if (obj.GetFixed32Count(12) == 1)
                {
                    component.Field12 = new uint?(obj.GetFixed32(12));
                }

                component.field13Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field13Provider.Allocate(world);

                if (obj.GetFixed64Count(13) == 1)
                {
                    component.Field13 = new ulong?(obj.GetFixed64(13));
                }

                component.field14Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field14Provider.Allocate(world);

                if (obj.GetSfixed32Count(14) == 1)
                {
                    component.Field14 = new int?(obj.GetSfixed32(14));
                }

                component.field15Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field15Provider.Allocate(world);

                if (obj.GetSfixed64Count(15) == 1)
                {
                    component.Field15 = new long?(obj.GetSfixed64(15));
                }

                component.field16Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field16Provider.Allocate(world);

                if (obj.GetEntityIdCount(16) == 1)
                {
                    component.Field16 = new global::Improbable.Gdk.Core.EntityId?(obj.GetEntityIdStruct(16));
                }

                component.field17Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field17Provider.Allocate(world);

                if (obj.GetObjectCount(17) == 1)
                {
                    component.Field17 = new global::Improbable.TestSchema.SomeType?(global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.GetObject(17)));
                }

                component.field18Handle = global::Improbable.TestSchema.ExhaustiveOptional.ReferenceTypeProviders.Field18Provider.Allocate(world);

                if (obj.GetEnumCount(18) == 1)
                {
                    component.Field18 = new global::Improbable.TestSchema.SomeEnum?((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(18));
                }

                return component;
            }

            public static global::Improbable.TestSchema.ExhaustiveOptional.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.TestSchema.ExhaustiveOptional.Update();
                var obj = updateObj.GetFields();

                {
                    var isCleared = updateObj.IsFieldCleared(1);

                    if (isCleared)
                    {
                        update.Field1 = new global::Improbable.Gdk.Core.Option<bool?>(new bool?());
                    }
                    else if (obj.GetBoolCount(1) == 1)
                    {
                        update.Field1 = new global::Improbable.Gdk.Core.Option<bool?>(obj.GetBool(1));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(2);

                    if (isCleared)
                    {
                        update.Field2 = new global::Improbable.Gdk.Core.Option<float?>(new float?());
                    }
                    else if (obj.GetFloatCount(2) == 1)
                    {
                        update.Field2 = new global::Improbable.Gdk.Core.Option<float?>(obj.GetFloat(2));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(3);

                    if (isCleared)
                    {
                        update.Field3 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.Option<byte[]>>(new global::Improbable.Gdk.Core.Option<byte[]>());
                    }
                    else if (obj.GetBytesCount(3) == 1)
                    {
                        update.Field3 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.Option<byte[]>>(obj.GetBytes(3));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(4);

                    if (isCleared)
                    {
                        update.Field4 = new global::Improbable.Gdk.Core.Option<int?>(new int?());
                    }
                    else if (obj.GetInt32Count(4) == 1)
                    {
                        update.Field4 = new global::Improbable.Gdk.Core.Option<int?>(obj.GetInt32(4));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(5);

                    if (isCleared)
                    {
                        update.Field5 = new global::Improbable.Gdk.Core.Option<long?>(new long?());
                    }
                    else if (obj.GetInt64Count(5) == 1)
                    {
                        update.Field5 = new global::Improbable.Gdk.Core.Option<long?>(obj.GetInt64(5));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(6);

                    if (isCleared)
                    {
                        update.Field6 = new global::Improbable.Gdk.Core.Option<double?>(new double?());
                    }
                    else if (obj.GetDoubleCount(6) == 1)
                    {
                        update.Field6 = new global::Improbable.Gdk.Core.Option<double?>(obj.GetDouble(6));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(7);

                    if (isCleared)
                    {
                        update.Field7 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.Option<string>>(new global::Improbable.Gdk.Core.Option<string>());
                    }
                    else if (obj.GetStringCount(7) == 1)
                    {
                        update.Field7 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.Option<string>>(obj.GetString(7));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(8);

                    if (isCleared)
                    {
                        update.Field8 = new global::Improbable.Gdk.Core.Option<uint?>(new uint?());
                    }
                    else if (obj.GetUint32Count(8) == 1)
                    {
                        update.Field8 = new global::Improbable.Gdk.Core.Option<uint?>(obj.GetUint32(8));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(9);

                    if (isCleared)
                    {
                        update.Field9 = new global::Improbable.Gdk.Core.Option<ulong?>(new ulong?());
                    }
                    else if (obj.GetUint64Count(9) == 1)
                    {
                        update.Field9 = new global::Improbable.Gdk.Core.Option<ulong?>(obj.GetUint64(9));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(10);

                    if (isCleared)
                    {
                        update.Field10 = new global::Improbable.Gdk.Core.Option<int?>(new int?());
                    }
                    else if (obj.GetSint32Count(10) == 1)
                    {
                        update.Field10 = new global::Improbable.Gdk.Core.Option<int?>(obj.GetSint32(10));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(11);

                    if (isCleared)
                    {
                        update.Field11 = new global::Improbable.Gdk.Core.Option<long?>(new long?());
                    }
                    else if (obj.GetSint64Count(11) == 1)
                    {
                        update.Field11 = new global::Improbable.Gdk.Core.Option<long?>(obj.GetSint64(11));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(12);

                    if (isCleared)
                    {
                        update.Field12 = new global::Improbable.Gdk.Core.Option<uint?>(new uint?());
                    }
                    else if (obj.GetFixed32Count(12) == 1)
                    {
                        update.Field12 = new global::Improbable.Gdk.Core.Option<uint?>(obj.GetFixed32(12));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(13);

                    if (isCleared)
                    {
                        update.Field13 = new global::Improbable.Gdk.Core.Option<ulong?>(new ulong?());
                    }
                    else if (obj.GetFixed64Count(13) == 1)
                    {
                        update.Field13 = new global::Improbable.Gdk.Core.Option<ulong?>(obj.GetFixed64(13));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(14);

                    if (isCleared)
                    {
                        update.Field14 = new global::Improbable.Gdk.Core.Option<int?>(new int?());
                    }
                    else if (obj.GetSfixed32Count(14) == 1)
                    {
                        update.Field14 = new global::Improbable.Gdk.Core.Option<int?>(obj.GetSfixed32(14));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(15);

                    if (isCleared)
                    {
                        update.Field15 = new global::Improbable.Gdk.Core.Option<long?>(new long?());
                    }
                    else if (obj.GetSfixed64Count(15) == 1)
                    {
                        update.Field15 = new global::Improbable.Gdk.Core.Option<long?>(obj.GetSfixed64(15));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(16);

                    if (isCleared)
                    {
                        update.Field16 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.EntityId?>(new global::Improbable.Gdk.Core.EntityId?());
                    }
                    else if (obj.GetEntityIdCount(16) == 1)
                    {
                        update.Field16 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.EntityId?>(obj.GetEntityIdStruct(16));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(17);

                    if (isCleared)
                    {
                        update.Field17 = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeType?>(new global::Improbable.TestSchema.SomeType?());
                    }
                    else if (obj.GetObjectCount(17) == 1)
                    {
                        update.Field17 = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeType?>(global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.GetObject(17)));
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(18);

                    if (isCleared)
                    {
                        update.Field18 = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeEnum?>(new global::Improbable.TestSchema.SomeEnum?());
                    }
                    else if (obj.GetEnumCount(18) == 1)
                    {
                        update.Field18 = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeEnum?>((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(18));
                    }
                }

                return update;
            }

            public static global::Improbable.TestSchema.ExhaustiveOptional.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.TestSchema.ExhaustiveOptional.Update();
                var obj = data.GetFields();

                if (obj.GetBoolCount(1) == 1)
                {
                    update.Field1 = new global::Improbable.Gdk.Core.Option<bool?>(obj.GetBool(1));
                }

                if (obj.GetFloatCount(2) == 1)
                {
                    update.Field2 = new global::Improbable.Gdk.Core.Option<float?>(obj.GetFloat(2));
                }

                if (obj.GetBytesCount(3) == 1)
                {
                    update.Field3 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.Option<byte[]>>(obj.GetBytes(3));
                }

                if (obj.GetInt32Count(4) == 1)
                {
                    update.Field4 = new global::Improbable.Gdk.Core.Option<int?>(obj.GetInt32(4));
                }

                if (obj.GetInt64Count(5) == 1)
                {
                    update.Field5 = new global::Improbable.Gdk.Core.Option<long?>(obj.GetInt64(5));
                }

                if (obj.GetDoubleCount(6) == 1)
                {
                    update.Field6 = new global::Improbable.Gdk.Core.Option<double?>(obj.GetDouble(6));
                }

                if (obj.GetStringCount(7) == 1)
                {
                    update.Field7 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.Option<string>>(obj.GetString(7));
                }

                if (obj.GetUint32Count(8) == 1)
                {
                    update.Field8 = new global::Improbable.Gdk.Core.Option<uint?>(obj.GetUint32(8));
                }

                if (obj.GetUint64Count(9) == 1)
                {
                    update.Field9 = new global::Improbable.Gdk.Core.Option<ulong?>(obj.GetUint64(9));
                }

                if (obj.GetSint32Count(10) == 1)
                {
                    update.Field10 = new global::Improbable.Gdk.Core.Option<int?>(obj.GetSint32(10));
                }

                if (obj.GetSint64Count(11) == 1)
                {
                    update.Field11 = new global::Improbable.Gdk.Core.Option<long?>(obj.GetSint64(11));
                }

                if (obj.GetFixed32Count(12) == 1)
                {
                    update.Field12 = new global::Improbable.Gdk.Core.Option<uint?>(obj.GetFixed32(12));
                }

                if (obj.GetFixed64Count(13) == 1)
                {
                    update.Field13 = new global::Improbable.Gdk.Core.Option<ulong?>(obj.GetFixed64(13));
                }

                if (obj.GetSfixed32Count(14) == 1)
                {
                    update.Field14 = new global::Improbable.Gdk.Core.Option<int?>(obj.GetSfixed32(14));
                }

                if (obj.GetSfixed64Count(15) == 1)
                {
                    update.Field15 = new global::Improbable.Gdk.Core.Option<long?>(obj.GetSfixed64(15));
                }

                if (obj.GetEntityIdCount(16) == 1)
                {
                    update.Field16 = new global::Improbable.Gdk.Core.Option<global::Improbable.Gdk.Core.EntityId?>(obj.GetEntityIdStruct(16));
                }

                if (obj.GetObjectCount(17) == 1)
                {
                    update.Field17 = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeType?>(global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.GetObject(17)));
                }

                if (obj.GetEnumCount(18) == 1)
                {
                    update.Field18 = new global::Improbable.Gdk.Core.Option<global::Improbable.TestSchema.SomeEnum?>((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(18));
                }

                return update;
            }

            public static global::Improbable.TestSchema.ExhaustiveOptional.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.TestSchema.ExhaustiveOptional.Snapshot();

                if (obj.GetBoolCount(1) == 1)
                {
                    component.Field1 = new bool?(obj.GetBool(1));
                }

                if (obj.GetFloatCount(2) == 1)
                {
                    component.Field2 = new float?(obj.GetFloat(2));
                }

                if (obj.GetBytesCount(3) == 1)
                {
                    component.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>(obj.GetBytes(3));
                }

                if (obj.GetInt32Count(4) == 1)
                {
                    component.Field4 = new int?(obj.GetInt32(4));
                }

                if (obj.GetInt64Count(5) == 1)
                {
                    component.Field5 = new long?(obj.GetInt64(5));
                }

                if (obj.GetDoubleCount(6) == 1)
                {
                    component.Field6 = new double?(obj.GetDouble(6));
                }

                if (obj.GetStringCount(7) == 1)
                {
                    component.Field7 = new global::Improbable.Gdk.Core.Option<string>(obj.GetString(7));
                }

                if (obj.GetUint32Count(8) == 1)
                {
                    component.Field8 = new uint?(obj.GetUint32(8));
                }

                if (obj.GetUint64Count(9) == 1)
                {
                    component.Field9 = new ulong?(obj.GetUint64(9));
                }

                if (obj.GetSint32Count(10) == 1)
                {
                    component.Field10 = new int?(obj.GetSint32(10));
                }

                if (obj.GetSint64Count(11) == 1)
                {
                    component.Field11 = new long?(obj.GetSint64(11));
                }

                if (obj.GetFixed32Count(12) == 1)
                {
                    component.Field12 = new uint?(obj.GetFixed32(12));
                }

                if (obj.GetFixed64Count(13) == 1)
                {
                    component.Field13 = new ulong?(obj.GetFixed64(13));
                }

                if (obj.GetSfixed32Count(14) == 1)
                {
                    component.Field14 = new int?(obj.GetSfixed32(14));
                }

                if (obj.GetSfixed64Count(15) == 1)
                {
                    component.Field15 = new long?(obj.GetSfixed64(15));
                }

                if (obj.GetEntityIdCount(16) == 1)
                {
                    component.Field16 = new global::Improbable.Gdk.Core.EntityId?(obj.GetEntityIdStruct(16));
                }

                if (obj.GetObjectCount(17) == 1)
                {
                    component.Field17 = new global::Improbable.TestSchema.SomeType?(global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.GetObject(17)));
                }

                if (obj.GetEnumCount(18) == 1)
                {
                    component.Field18 = new global::Improbable.TestSchema.SomeEnum?((global::Improbable.TestSchema.SomeEnum) obj.GetEnum(18));
                }

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.TestSchema.ExhaustiveOptional.Component component)
            {
                var obj = updateObj.GetFields();

                {
                    var isCleared = updateObj.IsFieldCleared(1);

                    if (isCleared)
                    {
                        component.Field1 = new bool?();
                    }
                    else if (obj.GetBoolCount(1) == 1)
                    {
                        var value = obj.GetBool(1);
                        component.Field1 = new bool?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(2);

                    if (isCleared)
                    {
                        component.Field2 = new float?();
                    }
                    else if (obj.GetFloatCount(2) == 1)
                    {
                        var value = obj.GetFloat(2);
                        component.Field2 = new float?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(3);

                    if (isCleared)
                    {
                        component.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>();
                    }
                    else if (obj.GetBytesCount(3) == 1)
                    {
                        var value = obj.GetBytes(3);
                        component.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(4);

                    if (isCleared)
                    {
                        component.Field4 = new int?();
                    }
                    else if (obj.GetInt32Count(4) == 1)
                    {
                        var value = obj.GetInt32(4);
                        component.Field4 = new int?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(5);

                    if (isCleared)
                    {
                        component.Field5 = new long?();
                    }
                    else if (obj.GetInt64Count(5) == 1)
                    {
                        var value = obj.GetInt64(5);
                        component.Field5 = new long?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(6);

                    if (isCleared)
                    {
                        component.Field6 = new double?();
                    }
                    else if (obj.GetDoubleCount(6) == 1)
                    {
                        var value = obj.GetDouble(6);
                        component.Field6 = new double?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(7);

                    if (isCleared)
                    {
                        component.Field7 = new global::Improbable.Gdk.Core.Option<string>();
                    }
                    else if (obj.GetStringCount(7) == 1)
                    {
                        var value = obj.GetString(7);
                        component.Field7 = new global::Improbable.Gdk.Core.Option<string>(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(8);

                    if (isCleared)
                    {
                        component.Field8 = new uint?();
                    }
                    else if (obj.GetUint32Count(8) == 1)
                    {
                        var value = obj.GetUint32(8);
                        component.Field8 = new uint?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(9);

                    if (isCleared)
                    {
                        component.Field9 = new ulong?();
                    }
                    else if (obj.GetUint64Count(9) == 1)
                    {
                        var value = obj.GetUint64(9);
                        component.Field9 = new ulong?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(10);

                    if (isCleared)
                    {
                        component.Field10 = new int?();
                    }
                    else if (obj.GetSint32Count(10) == 1)
                    {
                        var value = obj.GetSint32(10);
                        component.Field10 = new int?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(11);

                    if (isCleared)
                    {
                        component.Field11 = new long?();
                    }
                    else if (obj.GetSint64Count(11) == 1)
                    {
                        var value = obj.GetSint64(11);
                        component.Field11 = new long?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(12);

                    if (isCleared)
                    {
                        component.Field12 = new uint?();
                    }
                    else if (obj.GetFixed32Count(12) == 1)
                    {
                        var value = obj.GetFixed32(12);
                        component.Field12 = new uint?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(13);

                    if (isCleared)
                    {
                        component.Field13 = new ulong?();
                    }
                    else if (obj.GetFixed64Count(13) == 1)
                    {
                        var value = obj.GetFixed64(13);
                        component.Field13 = new ulong?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(14);

                    if (isCleared)
                    {
                        component.Field14 = new int?();
                    }
                    else if (obj.GetSfixed32Count(14) == 1)
                    {
                        var value = obj.GetSfixed32(14);
                        component.Field14 = new int?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(15);

                    if (isCleared)
                    {
                        component.Field15 = new long?();
                    }
                    else if (obj.GetSfixed64Count(15) == 1)
                    {
                        var value = obj.GetSfixed64(15);
                        component.Field15 = new long?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(16);

                    if (isCleared)
                    {
                        component.Field16 = new global::Improbable.Gdk.Core.EntityId?();
                    }
                    else if (obj.GetEntityIdCount(16) == 1)
                    {
                        var value = obj.GetEntityIdStruct(16);
                        component.Field16 = new global::Improbable.Gdk.Core.EntityId?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(17);

                    if (isCleared)
                    {
                        component.Field17 = new global::Improbable.TestSchema.SomeType?();
                    }
                    else if (obj.GetObjectCount(17) == 1)
                    {
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.GetObject(17));
                        component.Field17 = new global::Improbable.TestSchema.SomeType?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(18);

                    if (isCleared)
                    {
                        component.Field18 = new global::Improbable.TestSchema.SomeEnum?();
                    }
                    else if (obj.GetEnumCount(18) == 1)
                    {
                        var value = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(18);
                        component.Field18 = new global::Improbable.TestSchema.SomeEnum?(value);
                    }
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.TestSchema.ExhaustiveOptional.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                {
                    var isCleared = updateObj.IsFieldCleared(1);

                    if (isCleared)
                    {
                        snapshot.Field1 = new bool?();
                    }
                    else if (obj.GetBoolCount(1) == 1)
                    {
                        var value = obj.GetBool(1);
                        snapshot.Field1 = new bool?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(2);

                    if (isCleared)
                    {
                        snapshot.Field2 = new float?();
                    }
                    else if (obj.GetFloatCount(2) == 1)
                    {
                        var value = obj.GetFloat(2);
                        snapshot.Field2 = new float?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(3);

                    if (isCleared)
                    {
                        snapshot.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>();
                    }
                    else if (obj.GetBytesCount(3) == 1)
                    {
                        var value = obj.GetBytes(3);
                        snapshot.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(4);

                    if (isCleared)
                    {
                        snapshot.Field4 = new int?();
                    }
                    else if (obj.GetInt32Count(4) == 1)
                    {
                        var value = obj.GetInt32(4);
                        snapshot.Field4 = new int?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(5);

                    if (isCleared)
                    {
                        snapshot.Field5 = new long?();
                    }
                    else if (obj.GetInt64Count(5) == 1)
                    {
                        var value = obj.GetInt64(5);
                        snapshot.Field5 = new long?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(6);

                    if (isCleared)
                    {
                        snapshot.Field6 = new double?();
                    }
                    else if (obj.GetDoubleCount(6) == 1)
                    {
                        var value = obj.GetDouble(6);
                        snapshot.Field6 = new double?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(7);

                    if (isCleared)
                    {
                        snapshot.Field7 = new global::Improbable.Gdk.Core.Option<string>();
                    }
                    else if (obj.GetStringCount(7) == 1)
                    {
                        var value = obj.GetString(7);
                        snapshot.Field7 = new global::Improbable.Gdk.Core.Option<string>(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(8);

                    if (isCleared)
                    {
                        snapshot.Field8 = new uint?();
                    }
                    else if (obj.GetUint32Count(8) == 1)
                    {
                        var value = obj.GetUint32(8);
                        snapshot.Field8 = new uint?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(9);

                    if (isCleared)
                    {
                        snapshot.Field9 = new ulong?();
                    }
                    else if (obj.GetUint64Count(9) == 1)
                    {
                        var value = obj.GetUint64(9);
                        snapshot.Field9 = new ulong?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(10);

                    if (isCleared)
                    {
                        snapshot.Field10 = new int?();
                    }
                    else if (obj.GetSint32Count(10) == 1)
                    {
                        var value = obj.GetSint32(10);
                        snapshot.Field10 = new int?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(11);

                    if (isCleared)
                    {
                        snapshot.Field11 = new long?();
                    }
                    else if (obj.GetSint64Count(11) == 1)
                    {
                        var value = obj.GetSint64(11);
                        snapshot.Field11 = new long?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(12);

                    if (isCleared)
                    {
                        snapshot.Field12 = new uint?();
                    }
                    else if (obj.GetFixed32Count(12) == 1)
                    {
                        var value = obj.GetFixed32(12);
                        snapshot.Field12 = new uint?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(13);

                    if (isCleared)
                    {
                        snapshot.Field13 = new ulong?();
                    }
                    else if (obj.GetFixed64Count(13) == 1)
                    {
                        var value = obj.GetFixed64(13);
                        snapshot.Field13 = new ulong?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(14);

                    if (isCleared)
                    {
                        snapshot.Field14 = new int?();
                    }
                    else if (obj.GetSfixed32Count(14) == 1)
                    {
                        var value = obj.GetSfixed32(14);
                        snapshot.Field14 = new int?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(15);

                    if (isCleared)
                    {
                        snapshot.Field15 = new long?();
                    }
                    else if (obj.GetSfixed64Count(15) == 1)
                    {
                        var value = obj.GetSfixed64(15);
                        snapshot.Field15 = new long?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(16);

                    if (isCleared)
                    {
                        snapshot.Field16 = new global::Improbable.Gdk.Core.EntityId?();
                    }
                    else if (obj.GetEntityIdCount(16) == 1)
                    {
                        var value = obj.GetEntityIdStruct(16);
                        snapshot.Field16 = new global::Improbable.Gdk.Core.EntityId?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(17);

                    if (isCleared)
                    {
                        snapshot.Field17 = new global::Improbable.TestSchema.SomeType?();
                    }
                    else if (obj.GetObjectCount(17) == 1)
                    {
                        var value = global::Improbable.TestSchema.SomeType.Serialization.Deserialize(obj.GetObject(17));
                        snapshot.Field17 = new global::Improbable.TestSchema.SomeType?(value);
                    }
                }

                {
                    var isCleared = updateObj.IsFieldCleared(18);

                    if (isCleared)
                    {
                        snapshot.Field18 = new global::Improbable.TestSchema.SomeEnum?();
                    }
                    else if (obj.GetEnumCount(18) == 1)
                    {
                        var value = (global::Improbable.TestSchema.SomeEnum) obj.GetEnum(18);
                        snapshot.Field18 = new global::Improbable.TestSchema.SomeEnum?(value);
                    }
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<bool?> Field1;
            public Option<float?> Field2;
            public Option<global::Improbable.Gdk.Core.Option<byte[]>> Field3;
            public Option<int?> Field4;
            public Option<long?> Field5;
            public Option<double?> Field6;
            public Option<global::Improbable.Gdk.Core.Option<string>> Field7;
            public Option<uint?> Field8;
            public Option<ulong?> Field9;
            public Option<int?> Field10;
            public Option<long?> Field11;
            public Option<uint?> Field12;
            public Option<ulong?> Field13;
            public Option<int?> Field14;
            public Option<long?> Field15;
            public Option<global::Improbable.Gdk.Core.EntityId?> Field16;
            public Option<global::Improbable.TestSchema.SomeType?> Field17;
            public Option<global::Improbable.TestSchema.SomeEnum?> Field18;
        }

        internal class ExhaustiveOptionalDynamic : IDynamicInvokable
        {
            public uint ComponentId => ExhaustiveOptional.ComponentId;

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
                    Field1 = snapshot.Field1,
                    Field2 = snapshot.Field2,
                    Field3 = snapshot.Field3,
                    Field4 = snapshot.Field4,
                    Field5 = snapshot.Field5,
                    Field6 = snapshot.Field6,
                    Field7 = snapshot.Field7,
                    Field8 = snapshot.Field8,
                    Field9 = snapshot.Field9,
                    Field10 = snapshot.Field10,
                    Field11 = snapshot.Field11,
                    Field12 = snapshot.Field12,
                    Field13 = snapshot.Field13,
                    Field14 = snapshot.Field14,
                    Field15 = snapshot.Field15,
                    Field16 = snapshot.Field16,
                    Field17 = snapshot.Field17,
                    Field18 = snapshot.Field18
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
