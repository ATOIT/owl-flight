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
        public void SaveOrder(OrderDetails orderDetails, Basket basket)
        {
            if (orderDetails.OrderId == 0 || basket.Lines.Count() != 0)
            {
                List<ProductInOrder> productInOrders = new List<ProductInOrder>();
                foreach (var i in basket.Lines)
                {
                    if (i != null)
                    {
                        productInOrders.Add(new ProductInOrder
                        {
                            ProductInOrderName = i.Name,
                            ProductInOrderPhoto = i.Photo,
                            ProductInOrderPrice = i.Price,
                            ProductInOrderSize = i.SelectedSize
                        });
                    }
                }
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
                    DateOrder = DateTime.Now,
                    ProductInOrders = productInOrders
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
            if (oneOrder != null)
            {
                var remuveProduct = _context.ProductInOrders.Where(x => x.OrderDetails.OrderId == orderId);
                foreach (var i in remuveProduct)
                {
                    _context.ProductInOrders.Remove(i);
                }
                _context.OrderDetails.Remove(oneOrder);
                _context.SaveChanges();
            }
            else
                throw new Exception();
        }

        public void OrderComplite(int orderId)
        {
            var oneOrder = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                OrderDetails order = _context.OrderDetails.Find(oneOrder.OrderId);
                if (order != null)
                {
                    order.Status = "виконаний";
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        public void OrderNew(int orderId)
        {
            var oneOrder = _context.OrderDetails.FirstOrDefault(x => x.OrderId == orderId);
            if (oneOrder != null)
            {
                OrderDetails order = _context.OrderDetails.Find(oneOrder.OrderId);
                if (order != null)
                {
                    order.Status = "новий";
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }
    }
}
