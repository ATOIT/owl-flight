using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Abstrac;
using Domain.Entityes;
using static System.DateTime;

namespace Domain.Concrete
{
    public class EfProductRepository : IProductRepository
    {
        readonly ShopContext _context = new ShopContext();
        public IEnumerable<Product> Products => _context.Product;

        //Добавление и редактирование продукта
        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                try
                {
                    _context.Product.Add(new Product
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Composition = product.Composition,
                        Density = product.Density,
                        S = product.S,
                        M = product.M,
                        L = product.L,
                        Xl = product.Xl,
                        Xxl = product.Xxl,
                        Xl3 = product.Xl3,
                        Xl4 = product.Xl4,
                        Style = product.Style,
                        Producer = product.Producer,
                        DateCreate = Now,
                        Photo = product.Photo
                    });
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
            {
                Product pro = _context.Product.Find(product.ProductId);
                if (pro != null)
                {
                    pro.Name = product.Name;
                    pro.Description = product.Description;
                    pro.Price = product.Price;
                    pro.Composition = product.Composition;
                    pro.Density = product.Density;
                    pro.S = product.S;
                    pro.M = product.M;
                    pro.L = product.L;
                    pro.Xl = product.Xl;
                    pro.Xxl = product.Xxl;
                    pro.Xl3 = product.Xl3;
                    pro.Xl4 = product.Xl4;
                    pro.Style = product.Style;
                    pro.Producer = product.Producer;
                    pro.Photo = product.Photo;
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        //Удаление продукта
        public void RemoveProduct(int productId, DirectoryInfo directory)
        {

            Product pro = _context.Product.FirstOrDefault(x => x.ProductId == productId);
            if (pro != null)
            {
                var urlPhoto = pro.Photo;
                _context.Product.Remove(pro);
                _context.SaveChanges();

                //foreach (FileInfo file in directory.GetFiles()) //Удаление фото из директории
                //{
                //    if (urlPhoto.Equals(file.ToString()))
                //        file.Delete();
                //}
            }
            else
                throw new Exception();
        }

        //Добавление фото к продукту
        public void SavePhoto(int productId, string url)
        {
            var oneProduct = _context.Product.FirstOrDefault(x => x.ProductId == productId);
            if (oneProduct != null)
            {
                try
                {
                    oneProduct.Photo = url;
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new Exception();
        }

        //Удаление фото
        public void RemovePhoto(int productId, DirectoryInfo directory)
        {
            var oneProduct = _context.Product.FirstOrDefault(x => x.ProductId == productId);
            if (oneProduct != null)
            {
                try
                {
                    var urlDell = oneProduct.Photo;
                    oneProduct.Photo = "";
                    _context.SaveChanges();
                    foreach (FileInfo file in directory.GetFiles()) //Пока закоментирую, для удобства
                    {
                        if (file.ToString() == urlDell)
                            file.Delete();
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            else
                throw new Exception();
        }
        
    }
}
