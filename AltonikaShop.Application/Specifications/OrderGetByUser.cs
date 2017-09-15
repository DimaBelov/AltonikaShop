using CoreLib.Data;

namespace AltonikaShop.Application.Specifications
{
    sealed class OrderGetByUser : DbSpecification
    {
        public OrderGetByUser(int userId)
        {
            AddParameter("@user_id", userId);
        }

        protected override string CreateCommandText()
        {
            return "Order_GetByUser";
        }
    }
}
