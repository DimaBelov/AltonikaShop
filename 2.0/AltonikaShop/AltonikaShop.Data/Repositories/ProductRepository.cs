using AltonikaShop.Data.Repositories.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AltonikaShop.Data.Repositories
{
    public class ProductRepository : EntityRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
