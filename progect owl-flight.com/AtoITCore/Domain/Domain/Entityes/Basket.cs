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
        private readonly List<BasketLine> _myCollection = new List<BasketLine>();

        //ответ пользователю
        public List<string> AnswerList { get; set; }
        public IEnumerable<BasketLine> Lines => _myCollection;

        /// <summary>
        /// количество товаров в корзине
        /// </summary>
        public int CountItem => _myCollection.Count;
        

        /// <summary>
        /// добавление товара в корзину
        /// </summary>
        public void AddProduct(Product product, string size)
        {
                _myCollection.Add(new BasketLine
                {
                    Product = product,
                    Size = size
                });
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        public void RemoveProduct( int line)
        {
            BasketLine remove = new BasketLine();
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
                    totalVelue += i.Product.Price;
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
