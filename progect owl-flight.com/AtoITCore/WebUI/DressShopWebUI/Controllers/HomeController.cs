using System.Linq;
using System.Web.Mvc;
using Domain.Abstrac;

namespace DressShopWebUI.Controllers
{

    public class HomeController : Controller
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IProductRepository _productRepository;
        //Объявляем зависимость контроллера от хранилища сущностей
        public HomeController(IProductRepository productRepo, ISliderRepository sliderRepo)
        {
            _productRepository = productRepo;
            _sliderRepository = sliderRepo;
        }

        //страница "Про нас"
        public ViewResult AboutUs()
        {
            return View();
        }

        //генирация слайдера
        public ActionResult Slider()  
        {
            return PartialView(_sliderRepository.Sliders.OrderBy(x=>x.Number));
        }

        // страница каталога
        public ActionResult Selling()
        {
            return View(_productRepository.Products.
                OrderByDescending(x => x.DateCreate));
        }
    }
}