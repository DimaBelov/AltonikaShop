using AltonikaShop.Domain.Entities;
using CoreLib.Data.Entity;

namespace AltonikaShop.Application.Services.Interfaces
{
    public interface IProductService : IEntityService<Product>
    {
        Product GetById(int id);
    }
}
