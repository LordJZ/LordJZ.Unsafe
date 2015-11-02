# LordJZ.Unsafe
Provides a set of potentially unsafe methods implemented in CIL

### IntPtr ReferenceToIntPtr<T>(ref T value)
Converts a reference parameter to native int (`IntPtr`).
```
T obj = default(T); // T is struct
IntPtr pObj = UnsafeOperations.ReferenceToIntPtr(ref obj);
*(byte*)pObj.ToPointer() = 10;
```
Warning: Usage on class fields can return a dangling pointer.

### IntPtr ObjectToIntPtr(object obj)
Converts an object to IntPtr.
```
IntPtr ptr = UnsafeOperations.ObjectToIntPtr("p");
char c = *(char*)(ptr + RuntimeHelpers.OffsetToStringData).ToPointer();
Debug.Assert(c == 'p');
```

### T IntPtrToObject<T>(IntPtr pointer)
Converts an IntPtr to an object.
```
// ptr from previous example
string s = UnsafeOperations.IntPtrToObject<string>(ptr);
Debug.Assert(s == "p");
```
Warning: Method calls can crash runtime if type is mismatched.

### T Cast<T>(object obj)
Converts an object reference to an object reference of a different type,
without changing the actual object type.
```
short[] unsafeArray = UnsafeOperations.Cast<short[]>("p");
char c = (char)unsafeArray[0]; // string and short[] have
Debug.Assert(c == 'p');        // identical memory layouts
```
Warning: Method calls can crash runtime if type is mismatched.
