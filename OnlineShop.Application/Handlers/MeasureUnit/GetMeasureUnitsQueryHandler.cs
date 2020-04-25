using MediatR;
using OnlineShop.Application.Queries.MeasureUnit;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.MeasureUnit
{
    public class GetMeasureUnitsQueryHandler : IRequestHandler<GetMeasureUnitsQuery, List<MeasureUnitVM>>
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;

        public GetMeasureUnitsQueryHandler(IMeasureUnitRepository measureUnitRepository)
        {
            _measureUnitRepository = measureUnitRepository;
        }

        public async Task<List<MeasureUnitVM>> Handle(GetMeasureUnitsQuery request, CancellationToken cancellationToken)
        {
            return await _measureUnitRepository.GetMeasureUnitsAsync();
        }
    }
}
