using MediatR;
using OnlineShop.Application.Response;
using OnlineShop.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace OnlineShop.Application.Commands.Order
{
    public class CreateOrderCommand : IRequest<IResponse>
    {
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }
        public ICollection<OrderDetailsVm> OrderDetails { get; set; }
    }
}
