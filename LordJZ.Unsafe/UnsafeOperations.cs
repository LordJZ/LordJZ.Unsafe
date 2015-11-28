using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LordJZ.Unsafe
{
    /// <summary>
    /// Provides a set of potentially unsafe operations implemented in CIL.
    /// </summary>
    public static class UnsafeOperations
    {
        static Exception NotRewritten()
        {
            return new InvalidOperationException(
                "LordJZ.Unsafe requires to be re-written " +
                "with LordJZ.Unsafe.Builder before being used.");
        }

        /// <summary>
        /// Performs unsafe conversion of a reference parameter to an <see cref="IntPtr"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the reference parameter.
        /// </typeparam>
        /// <param name="value">
        /// The reference parameter to be converted to an <see cref="IntPtr"/>.
        /// </param>
        /// <returns>
        /// The chip representation of the reference as an <see cref="IntPtr"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// LordJZ.Unsafe requires to be re-written with LordJZ.Unsafe.Builder before being used.
        /// </exception>
        [DebuggerStepThrough, CompilerGenerated]
        public static IntPtr ReferenceToIntPtr<T>(ref T value)
        {
            throw NotRewritten();
        }

        /// <summary>
        /// Retrieves the address of an object as an <see cref="IntPtr"/>.
        /// </summary>
        /// <param name="obj">
        /// The instance to retrieve address of.
        /// </param>
        /// <returns>
        /// Address of the method table pointer of the object.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// LordJZ.Unsafe requires to be re-written with LordJZ.Unsafe.Builder before being used.
        /// </exception>
        [DebuggerStepThrough, CompilerGenerated]
        public static IntPtr ObjectToIntPtr(object obj)
        {
            throw NotRewritten();
        }

        /// <summary>
        /// Converts a pointer to an object reference.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the object to convert to. This can only be a reference type.
        /// </typeparam>
        /// <param name="pointer">
        /// Address of the object's method table pointer.
        /// </param>
        /// <returns>
        /// Object reference located at the specified location in memory.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// LordJZ.Unsafe requires to be re-written with LordJZ.Unsafe.Builder before being used.
        /// </exception>
        [DebuggerStepThrough, CompilerGenerated]
        public static T IntPtrToObject<T>(IntPtr pointer) where T : class
        {
            throw NotRewritten();
        }

        /// <summary>
        /// Reinterprents a managed reference as a managed reference of a different type.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the resulting managed reference.
        /// </typeparam>
        /// <param name="obj">
        /// The managed reference to reinterpret.
        /// </param>
        /// <returns>
        /// The reinterpreted managed reference of the specified type.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// LordJZ.Unsafe requires to be re-written with LordJZ.Unsafe.Builder before being used.
        /// </exception>
        [DebuggerStepThrough, CompilerGenerated]
        public static T Cast<T>(object obj) where T : class
        {
            throw NotRewritten();
        }
    }
}
