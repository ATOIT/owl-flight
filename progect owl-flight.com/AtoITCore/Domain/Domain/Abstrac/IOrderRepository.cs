using System.Collections.Generic;
using System.IO;
using Domain.Entityes;

namespace Domain.Abstrac
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDetails> OrderDetailses { get; }
        void SaveOrder(OrderDetails orderDetails);
        void RemoveOrder(int orderId);
    }
}