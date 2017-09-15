using System.Collections.Generic;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Application.Specifications;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Services
{
    public class ProductService : GenericService, IProductService
    {
        public ProductService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public IEnumerable<Product> GetAll()
        {
            return GetAll<Product>(new ProductGetAll());
        }

        public Product GetById(int id)
        {
            return Get<Product>(new ProductGetById(id));
        }
    }
}
