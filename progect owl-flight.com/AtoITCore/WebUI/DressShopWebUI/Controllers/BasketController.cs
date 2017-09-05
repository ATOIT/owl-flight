using System.Linq;
using System.Text;
using System.Web.Mvc;
using Domain.Abstrac;
using Domain.Entityes;
using DressShopWebUI.Models;

namespace DressShopWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IEmailSending _emailSending;
        private readonly IOrderRepository _orderRepository;
        public BasketController(IProductRepository productRepo, IEmailSending emailSend, IOrderRepository orderRepo)
        {
            _productRepository = productRepo;
            _emailSending = emailSend;
            _orderRepository = orderRepo;
        }
        
        //отображение корзины
        public ViewResult Index(Basket basket, string returnUrl)
        {
            var userBasket = new BasketViewModel
            {
                Basket = basket,
                ReturnUrl = returnUrl
            };
            if (userBasket.Basket.CountItem==0)
            {
                ViewBag.Sorry = "Ваша корзина пуста";
            }
            return View(userBasket);

        }

        // POST метод, оформления заказа
        [HttpPost]
        public ActionResult Index( BasketViewModel basketViewModel, Basket basket)
        {
            //Добавляем в связыватель товары из корзины
            //Проверяем валидность модели, и наличие товаров в корзине
            if (ModelState.IsValid && basket.CountItem!=0)
            {
                //Отсылаем письма
                _emailSending.SendMailToAdministrator(basket,basketViewModel.Orders,null);
                _emailSending.SendMail(basket, basketViewModel.Orders, null);
                //записываем покупку в базу
                StringBuilder order = new StringBuilder();
                foreach (var i in basket.Lines)
                {
                    order.Append($"{i.Product.Name} розмір - {i.Size}");
                }
                OrderDetails newOrder = new OrderDetails
                {
                    ClientName = basketViewModel.Orders.ClientName,
                    Email = basketViewModel.Orders.Email,
                    Phone = basketViewModel.Orders.Phone,
                    Payment = basketViewModel.Orders.Payment,
                    Delivery = basketViewModel.Orders.Delivery,
                    Address = basketViewModel.Orders.Address,
                    Status = "Нове замовлення",
                    Сomment = basketViewModel.Orders.Сomment,
                    DateOrder = basketViewModel.Orders.DateOrder,
                    Order = order.ToString()
                };
                _orderRepository.SaveOrder(newOrder);
                return RedirectToAction("Thanks","Basket");
            }
           
            return Index(basket, basketViewModel.ReturnUrl);
        }

        //Благодарности за покупку
        public ViewResult Thanks(Basket basket)
        {
            //формируем ответ для пользователя
            ViewBag.Answer = basket.AnswerList.ToList();
            //очищаем корзину
            basket.Clear();
            return View();
        }

        //Метод добавления товаров в корзину с переходом на оформление заказа
        public ActionResult AddToBasket(Basket basket, int productId, string selectedSize, string returnUrl, string action)
        {
             Product product = _productRepository.Products
                .FirstOrDefault(b => b.ProductId == productId);
            if (product != null)
            {
                basket.AddProduct(product, selectedSize);
            }
            if (action == "addAndGo")
            {
                return RedirectToAction("Index", new { returnUrl });
            }
            else
            {
                return Redirect(returnUrl);
            }
           
        }

        //метод добавления товара в корзину 

        //Метод удаления товаров из корзины
        public RedirectToRouteResult RemoveFromBasket(Basket basket, int line, string returnUrl)
        {
            if (line != 0)
            {
                basket.RemoveProduct(line);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //Частичное представление корзины для _Layout
        public PartialViewResult Summary(Basket basket)
        {
            return PartialView(basket);
        }
        //Частичное представление корзины для Selling и Partners (плавающая корзина)
        public PartialViewResult BasketOnView(Basket basket)
        {
            return PartialView(basket);
        }
    }

}