# LordJZ.Unsafe
Provides a set of potentially unsafe methods implemented in CIL

### IntPtr ReferenceToIntPtr<T>(ref T value)
Converts a reference parameter to native int (`IntPtr`).
```
T obj = default(T); // T is struct
IntPtr pObj = UnsafeOperations.ReferenceToIntPtr(ref d);
*(byte*)pObj.ToPointer() = 10;
```
Warning: Usage on class fields can return a dangling pointer.
