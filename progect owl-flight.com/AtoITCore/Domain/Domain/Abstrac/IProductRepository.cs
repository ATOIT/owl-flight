using System.Collections.Generic;
using System.IO;
using Domain.Entityes;

namespace Domain.Abstrac
{
    /// <summary>
    /// Интерфейс возвращающий коллекцию товаров из БД
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        void RemoveProduct(int productId, DirectoryInfo directory);
        void SavePhoto(int productId, string url);
        void RemovePhoto(int productId, DirectoryInfo directory);
    }
}