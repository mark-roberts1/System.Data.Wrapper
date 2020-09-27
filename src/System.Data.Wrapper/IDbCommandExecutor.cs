using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Wrapper
{
    /// <summary>
    /// This class is responsible for executing commands against a database.
    /// </summary>
    public interface IDbCommandExecutor
    {
        /// <summary>
        /// Executes a command and returns <see cref="IEnumerable{T}"/> results.
        /// </summary>
        /// <typeparam name="T">a type to which to convert query results</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="rowMapper">A function to map <typeparamref name="T"/> from <see cref="IDataReader"/></param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        IEnumerable<T> Execute<T>(IDbCommand command, Func<IDataReader, T> rowMapper);
        /// <summary>
        /// Executes a command asynchronously and returns <see cref="IEnumerable{T}"/> results.
        /// </summary>
        /// <typeparam name="T">a type to which to convert query results</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="rowMapper">A function to map <typeparamref name="T"/> from <see cref="IDataReader"/></param>
        /// <param name="cancellationToken">token used to cancel the action</param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        Task<IEnumerable<T>> ExecuteAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper, CancellationToken cancellationToken);
        /// <summary>
        /// Executes a command asynchronously and returns <see cref="IEnumerable{T}"/> results.
        /// </summary>
        /// <typeparam name="T">a type to which to convert query results</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="rowMapper">A function to map <typeparamref name="T"/> from <see cref="IDataReader"/></param>
        /// <returns><see cref="IEnumerable{T}"/></returns>
        Task<IEnumerable<T>> ExecuteAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper);
        /// <summary>
        /// Executes a command and returns the first row as an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">the type to convert the query result.</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="rowMapper">A function to map <typeparamref name="T"/> from <see cref="IDataReader"/></param>
        /// <returns>an instance of <typeparamref name="T"/></returns>
        T ExecuteSingle<T>(IDbCommand command, Func<IDataReader, T> rowMapper);
        /// <summary>
        /// Executes a command asynchronously and returns the first row as an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">the type to convert the query result.</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="rowMapper">A function to map <typeparamref name="T"/> from <see cref="IDataReader"/></param>
        /// <param name="cancellationToken">token used to cancel the action</param>
        /// <returns>an instance of <typeparamref name="T"/></returns>
        Task<T> ExecuteSingleAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper, CancellationToken cancellationToken);
        /// <summary>
        /// Executes a command asynchronously and returns the first row as an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">the type to convert the query result.</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="rowMapper">A function to map <typeparamref name="T"/> from <see cref="IDataReader"/></param>
        /// <returns>an instance of <typeparamref name="T"/></returns>
        Task<T> ExecuteSingleAsync<T>(IDbCommand command, Func<IDataReader, T> rowMapper);
        /// <summary>
        /// Executes a command and returns the first column of the first row as an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">the type to convert the query result.</typeparam>
        /// <param name="command">a command to execute</param>
        /// <returns>an instance of <typeparamref name="T"/></returns>
        T ExecuteScalar<T>(IDbCommand command);
        /// <summary>
        /// Executes a command asynchronously and returns the first column of the first row as an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">the type to convert the query result.</typeparam>
        /// <param name="command">a command to execute</param>
        /// <param name="cancellationToken">token used to cancel the action</param>
        /// <returns>an instance of <typeparamref name="T"/></returns>
        Task<T> ExecuteScalarAsync<T>(IDbCommand command, CancellationToken cancellationToken);
        /// <summary>
        /// Executes a command asynchronously and returns the first column of the first row as an instance of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">the type to convert the query result.</typeparam>
        /// <param name="command">a command to execute</param>
        /// <returns>an instance of <typeparamref name="T"/></returns>
        Task<T> ExecuteScalarAsync<T>(IDbCommand command);
        /// <summary>
        /// Executes a command and returns the number of affected records.
        /// </summary>
        /// <param name="command">a command to execute</param>
        /// <returns>the number of affected records</returns>
        int ExecuteNonQuery(IDbCommand command);
        /// <summary>
        /// Executes a command asynchronously and returns the number of affected records.
        /// </summary>
        /// <param name="command">a command to execute</param>
        /// <param name="cancellationToken">token used to cancel the action</param>
        /// <returns>the number of affected records</returns>
        Task<int> ExecuteNonQueryAsync(IDbCommand command, CancellationToken cancellationToken);
        /// <summary>
        /// Executes a command asynchronously and returns the number of affected records.
        /// </summary>
        /// <param name="command">a command to execute</param>
        /// <returns>the number of affected records</returns>
        Task<int> ExecuteNonQueryAsync(IDbCommand command);
    }
}
