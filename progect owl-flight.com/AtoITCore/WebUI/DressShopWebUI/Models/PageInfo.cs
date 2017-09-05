using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entityes;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Класс для построения пейджинга
    /// </summary>
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);// всего страниц
    }
    /// <summary>
    /// модель, которая отдается в представение.
    /// </summary>
    public class PageModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }

       // return View(GetModel(selling.ToList(), size, page)); - вывод данных в модель, используя пейджинг.
        /// <summary>
        /// Вспомагательный метод, для пейджинга
        /// </summary>
        /// <param name="mas"> массив данных из БД</param>
        /// <param name="size">количество обьектов на страницу</param>
        /// <param name="page">текущая страница</param>
        /// <returns></returns>
        private PageModel GetModel(IList<Product> mas, int size, int page)
        {
            int pageSize = CountItem(mas, size); //расчитываем исходя из продуктов а не из фото
            IEnumerable<Product> sell = mas.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = mas.Count() };
            return new PageModel { PageInfo = pageInfo, Products = sell };
        }

        /// <summary>
        /// Вспомогательный метод, для расщета количества элементов на странице по константе
        /// </summary>
        /// <param name="mas">Массив фотографий</param>
        /// <param name="pageSize"> Количество продуктов на странице</param>
        /// <returns></returns>
        private int CountItem(IList<Product> mas, int pageSize)
        {
            int count = 0;
            int countProduct = 0;
            int id = 0;
            foreach (var i in mas)
            {

                if (id.Equals(0) || id.Equals(i.ProductId))
                {
                    id = i.ProductId;
                    count++;
                }
                else
                {
                    if (countProduct == pageSize - 1)
                        break;
                    countProduct++;
                    count++;
                    id = i.ProductId;

                }
            }
            return count;
        }
    }


}