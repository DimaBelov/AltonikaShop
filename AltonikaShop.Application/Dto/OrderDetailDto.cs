using AltonikaShop.Domain.Entities;
using CoreLib.Data;

namespace AltonikaShop.Application.Dto
{
    class OrderDetailDto : IDto<OrderDetail>
    {
        int? order_id;
        int? product_id;
        string product_name;
        int quantity;
        string img_src;

        public OrderDetail GetEntity()
        {
            return new OrderDetail
            {
                OrderId = order_id,
                Product = new Product
                {
                    Id = product_id,
                    Name = product_name,
                    ImageSource = img_src
                },
                Quantity = quantity
            };
        }
    }
}
