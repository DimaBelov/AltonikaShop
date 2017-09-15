using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class ProductGetById : DbSpecification
    {
        public ProductGetById(int id)
        {
            AddParameter("@product_id", id);
        }

        protected override string CreateCommandText()
        {
            return "Product_GetById";
        }
    }
}
