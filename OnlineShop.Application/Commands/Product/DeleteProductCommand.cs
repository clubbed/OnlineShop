using MediatR;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Commands.Product
{
    public class DeleteProductCommand : IRequest<IResponse>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
