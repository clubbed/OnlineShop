using MediatR;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.Order
{
    public class DeleteOrderCommand : IRequest<IResponse>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
