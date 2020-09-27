using System;
using System.Collections.Generic;
using System.Data.Wrapper;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.SqlClient.Wrapper
{
    /// <inheritdoc/>
    public class SqlServerCommand : Data.Wrapper.IDbCommand
    {
        private bool disposed;
        private readonly SqlCommand _sqlCommand;

        /// <summary>
        /// Constructs an instance of <see cref="SqlServerCommand"/>
        /// </summary>
        public SqlServerCommand()
        {
            _sqlCommand = new SqlCommand();
            Parameters = new List<IDbParameter>();
        }

        /// <inheritdoc/>
        public string CommandText
        {
            get => _sqlCommand.CommandText;
            set => _sqlCommand.CommandText = value;
        }

        /// <inheritdoc/>
        public CommandType CommandType
        {
            get => _sqlCommand.CommandType;
            set => _sqlCommand.CommandType = value;
        }

        /// <inheritdoc/>
        public Data.Wrapper.IDbConnection Connection
        {
            get => new SqlServerConnection(_sqlCommand.Connection);
            set
            {
                if (!(value is SqlServerConnection sqlServerConnection))
                {
                    throw new ArgumentException($"{typeof(SqlServerConnection)} must be used with {typeof(SqlServerCommand)}");
                }

                _sqlCommand.Connection = sqlServerConnection.Connection;
            }
        }

        /// <inheritdoc/>
        public IList<IDbParameter> Parameters { get; }

        private void LoadParameters()
        {
            _sqlCommand.Parameters.Clear();

            if (Parameters.Count > 0)
            {
                foreach (var param in Parameters)
                {
                    SqlParameter sqlParam;

                    if (param.DbType != null)
                    {
                        sqlParam = new SqlParameter(param.Name, param.DbType.Value)
                        {
                            Value = param.Value
                        };
                    }
                    else
                    {
                        sqlParam = new SqlParameter(param.Name, param.Value);
                    }

                    if (!string.IsNullOrEmpty(param.TypeName))
                    {
                        sqlParam.TypeName = param.TypeName;
                    }

                    _sqlCommand.Parameters.Add(sqlParam);
                }
            }
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
                _sqlCommand?.Dispose();
                disposed = true;
            }
        }

        /// <inheritdoc/>
        public Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken)
        {
            LoadParameters();
            return _sqlCommand.ExecuteNonQueryAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IDataReader> ExecuteReaderAsync(CancellationToken cancellationToken)
        {
            LoadParameters();
            return await _sqlCommand.ExecuteReaderAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public Task<object> ExecuteScalarAsync(CancellationToken cancellationToken)
        {
            LoadParameters();
            return _sqlCommand.ExecuteScalarAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<int> ExecuteNonQueryAsync()
        {
            LoadParameters();
            return await _sqlCommand.ExecuteNonQueryAsync();
        }

        /// <inheritdoc/>
        public async Task<IDataReader> ExecuteReaderAsync()
        {
            LoadParameters();
            return await _sqlCommand.ExecuteReaderAsync();
        }

        /// <inheritdoc/>
        public async Task<object> ExecuteScalarAsync()
        {
            LoadParameters();
            return await _sqlCommand.ExecuteScalarAsync();
        }

        /// <inheritdoc/>
        public int ExecuteNonQuery()
        {
            LoadParameters();
            return _sqlCommand.ExecuteNonQuery();
        }

        /// <inheritdoc/>
        public IDataReader ExecuteReader()
        {
            LoadParameters();
            return _sqlCommand.ExecuteReader();
        }

        /// <inheritdoc/>
        public object ExecuteScalar()
        {
            LoadParameters();
            return _sqlCommand.ExecuteScalar();
        }
    }
}
