using System;
using System.Collections.Generic;
using System.Data.Wrapper;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.SqlClient.Wrapper
{
    /// <inheritdoc/>
    public class SqlServerConnection : Data.Wrapper.IDbConnection
    {
        private bool disposed;

        /// <summary>
        /// The underlying <see cref="SqlConnection"/> object
        /// </summary>
        public SqlConnection Connection { get; }

        /// <summary>
        /// Constructs an instance of <see cref="SqlServerConnection"/> using the provided connection string.
        /// </summary>
        /// <param name="connectionString">information about how to connect to a database</param>
        public SqlServerConnection(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Constructs an instance of <see cref="SqlServerConnection"/> using an existing <see cref="SqlConnection"/>.
        /// </summary>
        /// <param name="connection">An existing <see cref="SqlConnection"/></param>
        public SqlServerConnection(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                Connection?.Dispose();
                disposed = true;
            }
        }

        /// <inheritdoc/>
        public async Task OpenAsync(CancellationToken cancellationToken)
        {
            try
            {
                await Connection.OpenAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ConnectionException($"An error occurred while opening a connection to {Connection.Database} on {Connection.DataSource}", ex);
            }
        }

        /// <inheritdoc/>
        public async Task OpenAsync()
        {
            try
            {
                await Connection.OpenAsync();
            }
            catch (Exception ex)
            {
                throw new ConnectionException($"An error occurred while opening a connection to {Connection.Database} on {Connection.DataSource}", ex);
            }
        }

        /// <inheritdoc/>
        public void Open()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {
                throw new ConnectionException($"An error occurred while opening a connection to {Connection.Database} on {Connection.DataSource}", ex);
            }
        }

        /// <inheritdoc/>
        public void Close()
        {
            Connection.Close();
        }

        /// <inheritdoc/>
        public void ChangeDatabase(string database)
        {
            Connection.ChangeDatabase(database);
        }
    }
}
