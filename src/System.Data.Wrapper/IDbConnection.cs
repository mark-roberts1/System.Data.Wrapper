using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Wrapper
{
    /// <summary>
    /// Represents a connection to a database.
    /// </summary>
    public interface IDbConnection : IDisposable
    {
        /// <summary>
        /// Asynchronously opens a cancellable connection to the database.
        /// </summary>
        /// <param name="cancellationToken">token used to cancel the action.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ConnectionException"></exception>
        Task OpenAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Asynchronously opens a connection to the database.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ConnectionException"></exception>
        Task OpenAsync();
        /// <summary>
        /// Synchronously opens a connection to the database.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ConnectionException"></exception>
        void Open();
        /// <summary>
        /// Closes the Connection.
        /// </summary>
        void Close();
        /// <summary>
        /// Changes the database targeted on the connection.
        /// </summary>
        /// <param name="database">Name of the database to target</param>
        void ChangeDatabase(string database);
    }
}
