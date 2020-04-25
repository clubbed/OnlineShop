using MediatR;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.Product
{
    //public class GetAllProductsQuery : IRequest<List<ProductVM>>
    public class GetAllProductsQuery : IRequest<IResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
