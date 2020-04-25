using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<bool> DeleteAsync(IRequest request);
        Task<bool> UpdateAsync(IRequest request);
        Task<bool> CreateAsync(IRequest request);
    }
}
