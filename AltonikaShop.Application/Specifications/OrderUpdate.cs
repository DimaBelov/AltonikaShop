using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class OrderUpdate : DbSpecification
    {
        public OrderUpdate()
        {
            
        }

        protected override string CreateCommandText()
        {
            return "Order_Update";
        }
    }
}
