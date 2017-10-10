using System.Collections.Generic;
using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Services
{
    class ProductGetAll : DbSpecification
    {
        protected override string CreateCommandText()
        {
            return "product_getall";
        }
    }

    class ProductUpdate : DbSpecification
    {
        public ProductUpdate(IEnumerable<Product> products)
        {
            AddTableParameter("@products", products, Product.Tvp);
        }

        protected override string CreateCommandText()
        {
            return "product_update";
        }
    }

    public class TestService : GenericService
    {
        public TestService(IGenericRepository genericRepository) : base(genericRepository)
        {
        }

        public IEnumerable<Product> ProductGetAll()
        {
            return GetAll<Product>(new ProductGetAll());
        }

        public void Update(IEnumerable<Product> products) => Execute(new ProductUpdate(products));
    }
}
