using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class ProductGetAll : DbSpecification
    {
        protected override string CreateCommandText()
        {
            return "Product_GetAll";
        }
    }
}
