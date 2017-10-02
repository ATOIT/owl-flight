using System.Collections.Generic;
using System.IO;
using Domain.Entityes;

namespace Domain.Abstrac
{
    public interface IOrderRepository
    {
        IEnumerable<OrderDetails> OrderDetailses { get; }
        void SaveOrder(OrderDetails orderDetails, Basket basket);
        void RemoveOrder(int orderId);
        void OrderComplite(int orderId);
        void OrderNew(int orderId);
    }
}