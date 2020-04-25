using MediatR;
using OnlineShop.Application.Commands.MeasureUnit;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.MeasureUnit
{
    public class DeleteMeasureUnitCommandHandler : IRequestHandler<DeleteMeasureUnitCommand, bool>
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;

        public DeleteMeasureUnitCommandHandler(IMeasureUnitRepository measureUnitRepository)
        {
            _measureUnitRepository = measureUnitRepository;
        }

        public async Task<bool> Handle(DeleteMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            return await _measureUnitRepository.DeleteAsync(request);
        }
    }
}
