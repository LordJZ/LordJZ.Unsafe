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
        /// Performs unsafe conversion of a reference parameter to <see cref="IntPtr"/>.
        /// </summary>
        /// <typeparam name="T">
        /// Type of the reference parameter.
        /// </typeparam>
        /// <param name="value">
        /// The reference parameter to be converted to <see cref="IntPtr"/>
        /// </param>
        /// <returns>
        /// The chip representation of the reference as <see cref="IntPtr"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// LordJZ.Unsafe requires to be re-written with LordJZ.Unsafe.Builder before being used.
        /// </exception>
        [DebuggerStepThrough, CompilerGenerated]
        public static IntPtr ReferenceToIntPtr<T>(ref T value)
        {
            throw NotRewritten();
        }
    }
}
