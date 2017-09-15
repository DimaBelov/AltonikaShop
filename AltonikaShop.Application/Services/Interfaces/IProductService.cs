using System.Collections.Generic;
using AltonikaShop.Domain.Entities;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);
    }
}
