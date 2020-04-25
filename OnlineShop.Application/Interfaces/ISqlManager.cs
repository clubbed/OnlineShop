using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface ISqlManager
    {
        Task<DataTable> GetDataTableAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null);
        Task<bool> DeleteAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null);
        Task<bool> InsertAsync(string commandText,
        CommandType commandType, List<SqlParameter> parameters = null);
        Task<bool> UpdateAsync(string commandText,
        CommandType commandType, List<SqlParameter> parameters = null);
        Task<object> GetObjectAsync(string commandText,
            CommandType commandType, List<SqlParameter> parameters = null);
    }
}
