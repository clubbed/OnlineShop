using Moq;
using NUnit.Framework;
using OnlineShop.Application.Repositories.Interfaces;
using OnlineShop.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Tests.Repositories
{
    [TestFixture]
    public class MeasureUnitRepositoryTest
    {
        [Test]
        public async Task GetMeasureUnits_NotNull_And_SameLength()
        {
            var repository = new Mock<IMeasureUnitRepository>();

            repository.Setup(c => c.GetMeasureUnitsAsync())
                .Returns(MeasureUnitVMs());

            var list = await repository.Object.GetMeasureUnitsAsync();
            
            Assert.That(list.Count == 2);
            Assert.NotNull(list);
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
