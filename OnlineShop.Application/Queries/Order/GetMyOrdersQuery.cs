using MediatR;
using OnlineShop.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.Order
{
    public class GetMyOrdersQuery : IRequest<IResponse>
    {
        public GetMyOrdersQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
