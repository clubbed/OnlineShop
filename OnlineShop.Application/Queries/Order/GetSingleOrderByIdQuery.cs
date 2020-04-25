using MediatR;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.Order
{
    public class GetSingleOrderByIdQuery : IRequest<IResponse>
    {
        public GetSingleOrderByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
