using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.Wrapper
{
    /// <summary>
    /// A factory class used to construct implementations of <see cref="IDbConnection"/>
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// Constructs a connection given a connection string.
        /// </summary>
        /// <param name="connectionString">information about a connection to a database</param>
        /// <returns>a connection</returns>
        IDbConnection BuildConnection(string connectionString);
    }
}
