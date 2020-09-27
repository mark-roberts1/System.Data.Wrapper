using System;
using System.Collections.Generic;
using System.Text;

namespace System.Data.Wrapper
{
    /// <summary>
    /// A factory class used to construct implementations of <see cref="IDbCommand"/>
    /// </summary>
    public interface IDbCommandFactory
    {
        /// <summary>
        /// Constructs an <see cref="IDbCommand"/> instance using the given parameters.
        /// </summary>
        /// <param name="commandText">The text of the command to execute.</param>
        /// <param name="commandType">The type of command being executed.</param>
        /// <param name="connection">A database connection.</param>
        /// <param name="parameters">Query parameters.</param>
        /// <returns>A command to be executed.</returns>
        IDbCommand BuildCommand(string commandText, CommandType commandType, IDbConnection connection, params IDbParameter[] parameters);
    }
}
