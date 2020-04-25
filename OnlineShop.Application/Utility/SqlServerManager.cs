using Microsoft.Extensions.Configuration;
using OnlineShop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Utility
{
    public class SqlServerManager : ISqlManager
    {
        private readonly string _connectionString;

        public SqlServerManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OnlineShop");
        }
        //public SqlManager(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public async Task<DataTable> GetDataTableAsync(string commandText, 
            CommandType commandType, List<SqlParameter> parameters = null)
        {
            var dt = new DataTable();

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
                            cmd.Parameters.Add(param);
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
                            cmd.Parameters.Add(param);
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
                            cmd.Parameters.Add(param);
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
                            cmd.Parameters.Add(param);
                        }
                    }

                    return await cmd.ExecuteScalarAsync();
                }
            }
        }
    }
}
