using System.Data.Entity;
using Domain.Entityes;
namespace Domain.Concrete
{
    public class ShopContext : DbContext
    {
        public ShopContext(): base("DefaultConnection") { }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails  { get; set; }
        public virtual DbSet<ProductInOrder> ProductInOrders { get; set; }
    }
}
