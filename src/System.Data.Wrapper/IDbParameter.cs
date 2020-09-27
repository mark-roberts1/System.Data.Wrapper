using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.Wrapper
{
    /// <summary>
    /// Parameter to provide to an instance of <see cref="IDbCommand"/>
    /// </summary>
    public interface IDbParameter
    {
        /// <summary>
        /// Name of the parameter
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Value of the parameter
        /// </summary>
        object Value { get; }
        /// <summary>
        /// Data type of the parameter
        /// </summary>
        DbType? DbType { get; }
        /// <summary>
        /// For structured types, the name of the user defined type
        /// </summary>
        string TypeName { get; }
    }
}
