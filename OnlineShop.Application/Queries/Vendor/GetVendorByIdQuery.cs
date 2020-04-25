using MediatR;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.Vendor
{
    public class GetVendorByIdQuery : IRequest<VendorVM>
    {
        public GetVendorByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
