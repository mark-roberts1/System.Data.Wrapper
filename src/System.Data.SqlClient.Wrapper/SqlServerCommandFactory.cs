using System;
using System.Collections.Generic;
using System.Data.Wrapper;
using System.Text;

namespace System.Data.SqlClient.Wrapper
{
    /// <inheritdoc/>
    public class SqlServerCommandFactory : IDbCommandFactory
    {
        /// <inheritdoc/>
        public Data.Wrapper.IDbCommand BuildCommand(string commandText, CommandType commandType, Data.Wrapper.IDbConnection connection, params IDbParameter[] parameters)
        {
            commandText.ThrowIfNull("commandText");
            connection.ThrowIfNull("connection");

            var command = new SqlServerCommand
            {
                CommandText = commandText,
                CommandType = commandType,
                Connection = connection
            };

            if (parameters != null && parameters.Length > 0)
            {
                foreach (var param in parameters)
                    command.Parameters.Add(param);
            }

            return command;
        }
    }
}
