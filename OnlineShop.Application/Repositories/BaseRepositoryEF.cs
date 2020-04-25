using MediatR;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Repositories
{
    public class BaseRepositoryEF : IRepository
    {
        private readonly IShopDbContext _dbContext;

        public BaseRepositoryEF(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<bool> CreateAsync(IRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(IRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(IRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
