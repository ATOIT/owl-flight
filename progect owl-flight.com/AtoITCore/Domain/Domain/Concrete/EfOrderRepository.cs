using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstrac;
using Domain.Entityes;

namespace Domain.Concrete
{
    public class EfOrderRepository : IOrderRepository
    {
        readonly ShopContext _context = new ShopContext();
        public IEnumerable<OrderDetails> OrderDetailses => _context.OrderDetails;
        public void SaveOrder(OrderDetails orderDetails)
        {
            if (orderDetails.OrderId == 0)
            {
                _context.OrderDetails.Add(new OrderDetails
                {
                    Address = orderDetails.Address,
                    ClientName = orderDetails.ClientName,
                    Delivery = orderDetails.Delivery,
                    Email = orderDetails.Email,
                    Payment = orderDetails.Payment,
                    Phone = orderDetails.Phone,
                    Сomment = orderDetails.Сomment,
                    Status = orderDetails.Status,
                    Order = orderDetails.Order
                });
                _context.SaveChanges();
            }
            else
            {
                OrderDetails order = _context.OrderDetails.Find(orderDetails.OrderId);
                if (order != null)
                {
                    order.Status = orderDetails.Status;
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        public void RemoveOrder(int orderId)
        {
            var oneOrder = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder!=null)
            {
                _context.OrderDetails.Remove(oneOrder);
                _context.SaveChanges();
            }
            else
                throw new Exception();
        }
    }
}
