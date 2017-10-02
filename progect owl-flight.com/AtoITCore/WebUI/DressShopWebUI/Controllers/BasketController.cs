using System.Linq;
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

        public ViewResult Index(Basket basket, string returnUrl)
        {
            var userBasket = new BasketViewModel
            {
                Basket = basket,
                ReturnUrl = returnUrl
            };
            if (userBasket.Basket.CountItem == 0)
            {
                ViewBag.Sorry = "Ваша корзина пуста";
            }
            return View(userBasket);

        }


        [HttpPost]
        public ActionResult Index(BasketViewModel basketViewModel, Basket basket)
        {
            if (ModelState.IsValid && basket.CountItem != 0)
            {
                _emailSending.SendMailToAdministrator(basket, basketViewModel.Orders, null);
                _emailSending.SendMail(basket, basketViewModel.Orders, null);

                OrderDetails newOrder = new OrderDetails
                {
                    ClientName = basketViewModel.Orders.ClientName,
                    Email = basketViewModel.Orders.Email,
                    Phone = basketViewModel.Orders.Phone,
                    Payment = basketViewModel.Orders.Payment,
                    Delivery = basketViewModel.Orders.Delivery,
                    Address = basketViewModel.Orders.Address,
                    Status = "новий",
                    Сomment = basketViewModel.Orders.Сomment,
                };
                _orderRepository.SaveOrder(newOrder, basket);
                return RedirectToAction("Thanks", "Basket");
            }

            return Index(basket, basketViewModel.ReturnUrl);
        }
        
        public ViewResult Thanks(Basket basket)
        {
            ViewBag.Answer = basket.AnswerList.ToList();
            basket.Clear();
            return View();
        }
        
        public ActionResult AddToBasket(Basket basket, int productId, string selectedSize, string returnUrl, string action)
        {
            Product product = _productRepository.Products
               .FirstOrDefault(b => b.ProductId == productId);
            if (product != null)
            {
                product.SelectedSize = selectedSize;
                basket.AddProduct(product);
            }
            if (action == "addAndGo")
                return RedirectToAction("Index", new { returnUrl });
            return Redirect(returnUrl);

        }
        
        public RedirectToRouteResult RemoveFromBasket(Basket basket, int line, string returnUrl)
        {
            if (line != 0)
            {
                basket.RemoveProduct(line);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
        
        public PartialViewResult Summary(Basket basket)
        {
            return PartialView(basket);
        }

        public PartialViewResult BasketOnView(Basket basket)
        {
            return PartialView(basket);
        }
    }

}