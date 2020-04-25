using MediatR;

namespace OnlineShop.Application.Commands.MeasureUnit
{
    public class UpdateMeasureUnitCommand : IRequest<bool>
    {
        public UpdateMeasureUnitCommand(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; }
    }
}
