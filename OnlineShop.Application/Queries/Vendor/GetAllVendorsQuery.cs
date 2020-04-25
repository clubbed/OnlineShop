using MediatR;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Queries.Vendor
{
    public class GetAllVendorsQuery : IRequest<List<VendorVM>>
    {
    }
}
