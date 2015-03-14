using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LordJZ.Unsafe.Tests
{
    [TestClass]
    public class ReferenceToIntPtrTests
    {
        [TestMethod]
        public unsafe void TestInt32()
        {
            int v = 10;

            IntPtr p = UnsafeOperations.ReferenceToIntPtr(ref v);
            Assert.AreEqual(p, UnsafeOperations.ReferenceToIntPtr(ref v));
            Assert.AreEqual(10, v);
            Assert.AreNotEqual(IntPtr.Zero, p);

            int* pv = (int*)p.ToPointer();
            Assert.AreEqual(10, *pv);
            Assert.AreEqual(10, v);

            *pv = 20;
            Assert.AreEqual(20, *pv);
            Assert.AreEqual(20, v);

            v = 30;
            Assert.AreEqual(30, *pv);
            Assert.AreEqual(30, v);
        }

        [TestMethod]
        public unsafe void TestInt64()
        {
            const long start = (long)uint.MaxValue + 50;
            long v = start;

            IntPtr p = UnsafeOperations.ReferenceToIntPtr(ref v);
            Assert.AreEqual(p, UnsafeOperations.ReferenceToIntPtr(ref v));
            Assert.AreEqual(start, v);
            Assert.AreNotEqual(IntPtr.Zero, p);

            long* pv = (long*)p.ToPointer();
            Assert.AreEqual(start, *pv);
            Assert.AreEqual(start, v);

            *pv += 20;
            Assert.AreEqual(start + 20, *pv);
            Assert.AreEqual(start + 20, v);

            v = start - 5;
            Assert.AreEqual(start - 5, *pv);
            Assert.AreEqual(start - 5, v);
        }

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        struct MyStruct
        {
            [FieldOffset(0)]
            public decimal Decimal;
            [FieldOffset(0 + sizeof(decimal))]
            public long Primitive;
            [FieldOffset(0 + sizeof(decimal) + sizeof(long))]
            public string Obj;
        }

        [TestMethod]
        public unsafe void TestStruct()
        {
            MyStruct original = new MyStruct { Primitive = 10 };
            MyStruct v = original;

            IntPtr p = UnsafeOperations.ReferenceToIntPtr(ref v);
            Assert.AreEqual(p, UnsafeOperations.ReferenceToIntPtr(ref v));
            Assert.AreEqual(p, UnsafeOperations.ReferenceToIntPtr(ref v.Decimal));
            Assert.AreEqual(original, v);
            Assert.AreNotEqual(IntPtr.Zero, p);

            Assert.AreNotEqual(UnsafeOperations.ReferenceToIntPtr(ref v.Primitive),
                               UnsafeOperations.ReferenceToIntPtr(ref v.Obj));
            Assert.AreNotEqual(UnsafeOperations.ReferenceToIntPtr(ref v.Primitive),
                               UnsafeOperations.ReferenceToIntPtr(ref v));

            IntPtr pPrim = p + sizeof(decimal);
            Assert.AreEqual(pPrim, UnsafeOperations.ReferenceToIntPtr(ref v.Primitive));
            long* pv = (long*)pPrim.ToPointer();
            Assert.AreEqual(10, v.Primitive);
            Assert.AreEqual(10, *pv);
            Assert.AreEqual(0m, v.Decimal);
            Assert.AreEqual(null, v.Obj);

            *pv += 20;
            Assert.AreEqual(30, v.Primitive);
            Assert.AreEqual(30, *pv);
            Assert.AreEqual(0m, v.Decimal);
            Assert.AreEqual(null, v.Obj);

            v.Primitive = 50;
            Assert.AreEqual(50, v.Primitive);
            Assert.AreEqual(50, *pv);
            Assert.AreEqual(0m, v.Decimal);
            Assert.AreEqual(null, v.Obj);
        }
    }
}
