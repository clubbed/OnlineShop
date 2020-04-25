using MediatR;
using OnlineShop.Application.Commands.MeasureUnit;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.Application.Handlers.MeasureUnit
{
    public class UpdateMeasureUnitCommandHandler : IRequestHandler<UpdateMeasureUnitCommand, bool>
    {
        //private readonly IShopDbContext dbContext;

        //public UpdateMeasureUnitCommandHandler(IShopDbContext dbContext)
        //{
        //    this.dbContext = dbContext;
        //}
        private readonly IMeasureUnitRepository _measureUnitRepository;

        public UpdateMeasureUnitCommandHandler(IMeasureUnitRepository measureUnitRepository)
        {
            _measureUnitRepository = measureUnitRepository;
        }

        public async Task<bool> Handle(UpdateMeasureUnitCommand request, CancellationToken cancellationToken)
        {
            return await _measureUnitRepository.UpdateAsync(request);

            //var toUpdate = await dbContext.MeasureUnits.FindAsync(request.Id);

            //toUpdate.Name = request.Name;

            //dbContext.MeasureUnits.Update(toUpdate);

            //var result = await dbContext.SaveChangesAsync();

            //return result == 1 ? true : false;

        }
    }
}
