using MediatR;
using OnlineShop.Application.Commands.MeasureUnit;
using System.Threading;
using System.Threading.Tasks;
using OnlineShop.Application.Repositories.Interfaces;

namespace OnlineShop.Application.Handlers.MeasureUnit
{
    public class CreateMeasureUnitCommandHandler : IRequestHandler<CreateMeasureUnitCommand, bool>
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;

        public CreateMeasureUnitCommandHandler(IMeasureUnitRepository measureUnitRepository)
        {
            _measureUnitRepository = measureUnitRepository;
        }

        public async Task<bool> Handle(CreateMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            return await _measureUnitRepository.CreateAsync(request);
        }
    }
}
