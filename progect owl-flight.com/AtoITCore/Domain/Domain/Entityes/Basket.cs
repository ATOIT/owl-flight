using System.Collections.Generic;

namespace Domain.Entityes
{
    
    /// <summary>
    /// Сущность для хранения покупок в сессии
    /// </summary>
    public class Basket
    {
        public Basket()
        {
            AnswerList = new List<string>();
        }
        /// <summary>
        /// коллекция товаров в корзине
        /// </summary>
        private readonly List<Product> _myCollection = new List<Product>();

        //ответ пользователю
        public List<string> AnswerList { get; set; }
        public IEnumerable<Product> Lines => _myCollection;

        /// <summary>
        /// количество товаров в корзине
        /// </summary>
        public int CountItem => _myCollection.Count;
        

        /// <summary>
        /// добавление товара в корзину
        /// </summary>
        public void AddProduct(Product product)
        {
                _myCollection.Add(product);
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        public void RemoveProduct( int line)
        {
            Product remove = new Product();
            foreach (var i in _myCollection)
            {
                if (i.GetHashCode() == line)
                {
                    remove = i;
                } 
            }
            _myCollection.Remove(remove);
        }

        /// <summary>
        /// получаем сумму товаров
        /// </summary>
        public double ComputeTotalValue()
        {
            double totalVelue = 0;
            foreach (var i in _myCollection)
            {
                    totalVelue += i.Price;
            }
            return totalVelue;
        }

        /// <summary>
        /// очистка козины
        /// </summary>
        public void Clear()
        {
            _myCollection.Clear();
        }
    }
}
