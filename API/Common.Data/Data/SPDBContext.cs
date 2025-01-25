using Common.Data.Data.Contracts;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Common.Data.Data
{
    public class SPDBContext : ISPDBContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionKey;

        public SPDBContext(IConfiguration config, string connectionKey)
        {
            _config = config;
            _connectionKey = connectionKey;
        }

        public async Task<IEnumerable<T>> GetDataAsync<T, P>(string sqlQuery, P parameters)
        {
            using IDbConnection connection = new NpgsqlConnection(
                _config.GetConnectionString(_connectionKey));

            return await connection.QueryAsync<T>(
                sqlQuery, parameters, commandType: CommandType.Text);
        }

        public async Task<IEnumerable<T1>> GetAllDataAsync<T1, T2>(string query)
        {
            using IDbConnection connection = new NpgsqlConnection(
                _config.GetConnectionString(_connectionKey));

            return await connection.QueryAsync<T1>(
                query, commandType: CommandType.Text);
        }

        public async Task<T> GetFirstResultAsync<T, P>(string sqlQuery, P parameters)
        {
            using IDbConnection connection = new NpgsqlConnection(
                _config.GetConnectionString(_connectionKey));

            var result = await connection.QueryFirstOrDefaultAsync<T>(
                sqlQuery, parameters, commandType: CommandType.Text);

            return result;
        }

        public async Task<bool> ExecuteProcedureAsync<P>(string sqlQuery, P parameters)
        {
            try
            {
                using IDbConnection connection = new NpgsqlConnection(
                    _config.GetConnectionString(_connectionKey));

                await connection.ExecuteAsync(
                    sqlQuery,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing procedure {sqlQuery}: {ex.Message}");

                throw;
            }
        }
    }
}
