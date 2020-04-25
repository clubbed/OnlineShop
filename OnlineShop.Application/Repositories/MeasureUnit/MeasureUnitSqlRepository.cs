using OnlineShop.Application.Caching;
using OnlineShop.Application.Commands.MeasureUnit;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.Utility;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineShop.Application.Repositories.MeasureUnit
{
    public class MeasureUnitSqlRepository : IMeasureUnitRepository
    {
        private readonly ISqlManager _sqlManager;
        private readonly ICacheService _cacheService;

        public MeasureUnitSqlRepository(ISqlManager sqlManager,
            ICacheService cacheService)
        {
            _sqlManager = sqlManager;
            _cacheService = cacheService;
        }

        public async Task<bool> CreateAsync(CreateMeasureUnitCommand request)
        {
            string commandText = $"INSERT INTO MeasureUnits (Name) VALUES (@Name)";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", request.Name)
            };

            var result = await _sqlManager.InsertAsync(commandText, CommandType.Text, parameters);

            if (result)
            {
                await _cacheService
                    .DeleteKeyAsync(RedisDefaultKeys.GetAllMeasureUnits);
            }

            return result;
        }

        public async Task<bool> DeleteAsync(DeleteMeasureUnitCommand request)
        {
            string commandText = $"DELETE FROM MeasureUnits ID = @Id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Id", request.Id)
            };

            var result = await _sqlManager.DeleteAsync(commandText, CommandType.Text, parameters);

            if (result)
            {
                await _cacheService
                    .DeleteKeyAsync(RedisDefaultKeys.GetAllMeasureUnits);
            }

            return result;
        }

        public async Task<List<MeasureUnitVM>> GetMeasureUnitsAsync()
        {
            string commandText = $"SELECT * FROM MeasureUnits";

            var dt = await _sqlManager
                .GetDataTableAsync(commandText, CommandType.Text);

            var measureUnits = (from DataRow dr in dt.Rows
                                select new MeasureUnitVM
                                {
                                    Name = (string)dr["Name"]
                                }).ToList();

            return measureUnits;
        }

        public async Task<bool> UpdateAsync(UpdateMeasureUnitCommand request)
        {
            string commandText = $"UPDATE MeasureUnits SET Name = @Name WHERE ID = @Id";

            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", request.Name),
                new SqlParameter("@Id", request.Id)
            };

            var result = await _sqlManager.UpdateAsync(commandText, CommandType.Text, parameters);

            if (result)
            {
                await _cacheService
                    .DeleteKeyAsync(RedisDefaultKeys.GetAllMeasureUnits);
            }

            return result;
        }
    }
}
