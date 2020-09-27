using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Wrapper
{
    /// <summary>
    /// Used to queries against a database
    /// </summary>
    public class DbCommandExecutor : IDbCommandExecutor
    {
        /// <inheritdoc/>
        public IEnumerable<T> Execute<T>(IDbCommand command, Func<IDataReader, T> rowMapper)
        {
            command.ThrowIfNull("command");
            rowMapper.ThrowIfNull("rowMapper");

            var results = new List<T>();

            command.Connection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    results.Add(rowMapper.Invoke(reader));
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ExecuteAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper, CancellationToken cancellationToken)
        {
            command.ThrowIfNull("command");
            rowMapper.ThrowIfNull("rowMapper");

            var results = new List<T>();

            await command.Connection.OpenAsync(cancellationToken);
            using (var reader = await command.ExecuteReaderAsync(cancellationToken))
            {
                while (reader.Read())
                {
                    results.Add(rowMapper.Invoke(reader));
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> ExecuteAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper)
        {
            command.ThrowIfNull("command");
            rowMapper.ThrowIfNull("rowMapper");

            var results = new List<T>();

            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    results.Add(rowMapper.Invoke(reader));
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public int ExecuteNonQuery(IDbCommand command)
        {
            command.ThrowIfNull("command");

            command.Connection.Open();

            return command.ExecuteNonQuery();
        }

        /// <inheritdoc/>
        public async Task<int> ExecuteNonQueryAsync(IDbCommand command, CancellationToken cancellationToken)
        {
            command.ThrowIfNull("command");

            await command.Connection.OpenAsync(cancellationToken);
            return await command.ExecuteNonQueryAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<int> ExecuteNonQueryAsync(IDbCommand command)
        {
            command.ThrowIfNull("command");

            await command.Connection.OpenAsync();

            return await command.ExecuteNonQueryAsync();
        }

        /// <inheritdoc/>
        public T ExecuteScalar<T>(IDbCommand command)
        {
            command.ThrowIfNull("command");

            command.Connection.Open();

            object scalarValue = command.ExecuteScalar();

            return (T)Convert.ChangeType(scalarValue, typeof(T));
        }

        /// <inheritdoc/>
        public async Task<T> ExecuteScalarAsync<T>(IDbCommand command, CancellationToken cancellationToken)
        {
            command.ThrowIfNull("command");

            await command.Connection.OpenAsync(cancellationToken);
            object scalarValue = await command.ExecuteScalarAsync(cancellationToken);

            return (T)Convert.ChangeType(scalarValue, typeof(T));
        }

        /// <inheritdoc/>
        public async Task<T> ExecuteScalarAsync<T>(IDbCommand command)
        {
            command.ThrowIfNull("command");

            await command.Connection.OpenAsync();
            object scalarValue = await command.ExecuteScalarAsync();

            return (T)Convert.ChangeType(scalarValue, typeof(T));
        }

        /// <inheritdoc/>
        public T ExecuteSingle<T>(IDbCommand command, Func<IDataReader, T> rowMapper)
        {
            command.ThrowIfNull("command");
            rowMapper.ThrowIfNull("rowMapper");

            T result = default;

            command.Connection.Open();

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = rowMapper.Invoke(reader);
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<T> ExecuteSingleAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper, CancellationToken cancellationToken)
        {
            command.ThrowIfNull("command");
            rowMapper.ThrowIfNull("rowMapper");

            T result = default;

            await command.Connection.OpenAsync(cancellationToken);
            using (var reader = await command.ExecuteReaderAsync(cancellationToken))
            {
                if (reader.Read())
                {
                    result = rowMapper.Invoke(reader);
                }
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<T> ExecuteSingleAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper)
        {
            command.ThrowIfNull("command");
            rowMapper.ThrowIfNull("rowMapper");

            T result = default;

            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (reader.Read())
                {
                    result = rowMapper.Invoke(reader);
                }
            }

            return result;
        }
    }
}
