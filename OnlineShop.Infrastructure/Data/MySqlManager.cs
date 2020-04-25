using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using OnlineShop.Application.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Data
{
    public class MySQLManager : ISqlManager
    {
        private readonly string _connectionString;

        public MySQLManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySQL");
        }

        public async Task<DataTable> GetDataTableAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();

            using (var con = new MySqlConnection(_connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters
                                .AddWithValue(param.ParameterName, param.Value);
                        }
                    }

                    var reader = await cmd.ExecuteReaderAsync();

                    dt.Load(reader);
                }
            }

            return dt;
        }

        public async Task<bool> DeleteAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            return await ExecuteNonQueryAsync(commandText, commandType, parameters) > 0;
        }

        public async Task<bool> InsertAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            return await ExecuteNonQueryAsync(commandText, commandType, parameters) > 0;
        }

        public async Task<bool> UpdateAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            return await ExecuteNonQueryAsync(commandText, commandType, parameters) > 0;
        }

        public async Task<object> GetObjectAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            return await ExecuteScalarAsync(commandText, commandType, parameters);
        }

        private async Task<int> ExecuteNonQueryAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters
                                .AddWithValue(param.ParameterName, param.Value);
                        }
                    }

                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task<SqlDataReader> ExecuteReaderAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters
                                .AddWithValue(param.ParameterName, param.Value);
                        }
                    }

                    return await cmd.ExecuteReaderAsync();
                }
            }
        }

        private async Task<object> ExecuteScalarAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                if (con.State != ConnectionState.Open) con.Open();

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters
                                .AddWithValue(param.ParameterName, param.Value);
                        }
                    }

                    return await cmd.ExecuteScalarAsync();
                }
            }
        }
    }
}
