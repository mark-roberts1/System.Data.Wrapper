using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.Wrapper
{
    /// <inheritdoc/>
    public class DbParameter : IDbParameter
    {
        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public object Value { get; set; }

        /// <inheritdoc/>
        public DbType? DbType { get; set; }

        /// <inheritdoc/>
        public string TypeName { get; set; }

        /// <summary>
        /// Constructs a DbParameter using the provided parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static DbParameter From(string name, object value)
        {
            return new DbParameter
            {
                Name = name,
                Value = value
            };
        }

        /// <summary>
        /// Constructs a DbParameter using the provided parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="dbType"></param>
        /// <param name="typeName"></param>
        public static DbParameter From(string name, object value, DbType? dbType, string typeName)
        {
            return new DbParameter
            {
                Name = name,
                Value = value,
                DbType = dbType,
                TypeName = typeName
            };
        }
    }
}
