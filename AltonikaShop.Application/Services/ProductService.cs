using System.Collections.Generic;
using AltonikaShop.Application.Services.Interfaces;
using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Services
{
    public class ProductService : EntityService<Product>, IProductService
    {
        public ProductService(IEntityRepository<Product> repository) : base(repository)
        {
        }

        public override IEnumerable<Product> GetAll()
        {
            return Repository.GetAllNoTrack();
        }

        public Product GetById(int id)
        {
            return Get(id);
        }
    }
}
