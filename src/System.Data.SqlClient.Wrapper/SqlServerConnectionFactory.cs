using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.SqlClient.Wrapper
{
    /// <inheritdoc/>
    public class SqlServerConnectionFactory : Data.Wrapper.IDbConnectionFactory
    {
        /// <inheritdoc/>
        public Data.Wrapper.IDbConnection BuildConnection(string connectionString)
        {
            return new SqlServerConnection(connectionString);
        }
    }
}
