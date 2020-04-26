using Moq;
using NUnit.Framework;
using OnlineShop.Application.Handlers.MeasureUnit;
using OnlineShop.Application.Queries.MeasureUnit;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Handlers
{
    [TestFixture]
    public class MeasureUnitHandlersTests
    {
        [Test]
        public async Task GetMeasureUnitsQueryHandler()
        {
            var repo = new Mock<IMeasureUnitRepository>();
            repo.Setup(c => c.GetMeasureUnitsAsync()).Returns(MeasureUnitVMs());

            var handler = new GetMeasureUnitsQueryHandler(repo.Object);

            var list = await handler.Handle(new GetMeasureUnitsQuery(), new System.Threading.CancellationToken());

            Assert.That(list.Count == 2);
        }

        private Task<List<MeasureUnitVM>> MeasureUnitVMs()
        {
            return Task.FromResult(new List<MeasureUnitVM>
            {
                new MeasureUnitVM
                {
                    Name = "Cope"
                },
                new MeasureUnitVM
                {
                    Name = "Liter"
                }
            });
        }
    }
}
