using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class BasketLine
    {
        public Product Product { get; set; }
        public string Size { get; set; }
    }
}
