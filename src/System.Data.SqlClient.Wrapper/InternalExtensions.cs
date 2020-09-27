using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.SqlClient.Wrapper
{
    internal static class InternalExtensions
    {
        /// <summary>
        /// An extension method that throws an <see cref="ArgumentException"/> when <paramref name="instance"/> is null.
        /// </summary>
        /// <typeparam name="T">The type of object to be checked for null</typeparam>
        /// <param name="instance">The object to be checked for null</param>
        /// <param name="argName">The name to give to the constructor of <see cref="ArgumentException"/></param>
        internal static T ThrowIfNull<T>(this T instance, string argName)
        {
            if (instance == null) throw new ArgumentNullException(argName);

            return instance;
        }
    }
}
