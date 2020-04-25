using OnlineShop.Application.Commands.MeasureUnit;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Interfaces
{
    public interface IMeasureUnitRepository
    {
        Task<List<MeasureUnitVM>> GetMeasureUnitsAsync();
        Task<bool> DeleteAsync(DeleteMeasureUnitCommand request);
        Task<bool> UpdateAsync(UpdateMeasureUnitCommand request);
        Task<bool> CreateAsync(CreateMeasureUnitCommand request);
    }
}
