using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.Wrapper
{
    /// <summary>
    /// Extension methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Ensures that a string ends with ".sql"
        /// </summary>
        /// <param name="filename">string to check</param>
        internal static string EnsureSqlFile(this string filename)
        {
            if (filename == null || filename.EndsWith(".sql")) return filename;

            return $"{filename}.sql";
        }

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
