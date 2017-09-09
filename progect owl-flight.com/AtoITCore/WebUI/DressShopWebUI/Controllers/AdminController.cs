using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstrac;
using Domain.Entityes;



namespace DressShopWebUI.Controllers
{
    /// <summary>
    /// Контроллер для админ - панели
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public AdminController(IProductRepository productRepo, ISliderRepository sliderRepo, IOrderRepository orderRepo)
        {
            _productRepository = productRepo;
            _orderRepository = orderRepo;
            _sliderRepository = sliderRepo;
        }

        //#region Работа с товарами

        ////------------------------------------------------Стартовая страница------------------------------------------------------------------
        public ActionResult MyPanel()
        {
            return View(_productRepository.Products.
                OrderByDescending(x => x.DateCreate));
        }

        [HttpPost]
        //Сортировка и поиск по имени продукта
        public ActionResult MyPanel(string searchName, SortType sortType)
        {
            var product = _productRepository.Products;
            if (!string.IsNullOrEmpty(searchName))
            {
                //поиск в коллекции продуктов продукта по имени
                var enumerable = product as IList<Product> ?? product.ToList();
                var qvery = enumerable.Where(s => s.Name.Equals(searchName)).ToList();
                if (qvery.Count != 0)
                {
                    TempData["message"] = $"Обран товар по имені - \"{searchName}\"";
                    return PartialView("PartialMyPanel", qvery);
                }
                //если ничего не найденно 
                TempData["message"] = $"Товару з іменем - \"{searchName}\" не існує!";
                return PartialView("PartialMyPanel", enumerable);
            }
            switch (sortType)
            {
                case SortType.Before:
                    product = _productRepository.Products.
                        OrderByDescending(x => x.DateCreate);
                    break;
                case SortType.Later:
                    product = _productRepository.Products.
                        OrderBy(x => x.DateCreate);
                    break;
            }
            return PartialView("PartialMyPanel", product);
        }

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Добавление товара-------------------------------------------------------------------
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null)
            {
                //проверяем налиие размера
                if (product.S == false && product.M == false && product.L == false && product.Xl == false && product.Xxl == false && product.Xl3 == false && product.Xl4 == false)
                {
                    ModelState.AddModelError("", "Ви не обрали розмір!");
                    return View();
                }
                var photoName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(upload.FileName);
                photoName += extension;
                List<string> extensions = new List<string> { ".jpg", ".png", ".gif" };
                // сохраняем файл
                if (extensions.Contains(extension))
                {
                    upload.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
                }
                else
                {
                    ModelState.AddModelError("", "Помилка! Не вірне розширення фотографії!");
                    return View();
                }
               
                try
                {
                    product.Photo = photoName;
                    //сохраняем новый товар
                    _productRepository.SaveProduct(product);
                    TempData["message"] = "Товар успішно доданий!";
                }
                catch (Exception)
                {
                    //при ошибке, удаляем файлы из директории
                    DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
                    foreach (FileInfo file in directory.GetFiles())
                    {
                            if (file.ToString()== photoName)
                                file.Delete();
                    }
                    TempData["message"] = "Щось не так :( Товар не був доданий!";
                }
                return RedirectToAction("MyPanel");
            }
            ModelState.AddModelError("",
                "Помилка! Товар не був доданий! перевірте будь ласка правильність заповнення форми та наявність фото!");
            return View();
        }

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Редактировние товара----------------------------------------------------------------
        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            var qvery = _productRepository.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

            if (qvery != null && ModelState.IsValid && qvery.Photo!="new")
            {
                try
                {
                    product.Photo = qvery.Photo;
                    _productRepository.SaveProduct(product);
                    TempData["message"] = "Зміни в товарі були збережені";
                }
                catch (Exception)
                {
                    TempData["messageBad"] = "Щось не так :( Товар не був змінений!";
                }
                return RedirectToAction("MyPanel");
            }
            ModelState.AddModelError("",
                "Помилка! Товар не був доданий! перевірте будь ласка правильність заповнення форми та наявність фото!");
            var productSelect = _productRepository.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            return View("EditProduct", productSelect);

        }

        ////------------------------------------------------Удаление товара---------------------------------------------------------------------
        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
            try
            {
                _productRepository.RemoveProduct(productId, directory);
                TempData["message"] = "Товар був успішно видалений!";
            }
            catch (Exception)
            {
                TempData["message"] = "Щось не так :( Товар не був видалений!";
            }
            return RedirectToAction("MyPanel");
        }

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Редактот фото товара----------------------------------------------------------------


        [HttpPost]
        public ActionResult DeletePhoto(int idProduct) // Удаление фото
        {
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
            try
            {
                _productRepository.RemovePhoto(idProduct, directory);
            }
            catch (Exception)
            {
                ViewBag.Error = "Ошибка! Что то пошло не так :( Мы не смогли удалить фото! ";
            }
            var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == idProduct);
            if (product != null)
                return PartialView("EditPhoto", product);
            return PartialView("EditPhoto", new Product());
        }
        ////------------------------------------------------------------------------------------------------------------------------------------
        ////------------------------------------------------Добавление фото на сервер-----------------------------------------------------------

        [HttpPost]
        public ActionResult UploadPhoto(int productId, HttpPostedFileBase fileInput)
        {
            var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == productId);
            var photoName = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(fileInput.FileName);
            photoName += extension;
            List<string> extensions = new List<string> { ".jpg", ".png", ".gif" };
            // сохраняем файл
            if (extensions.Contains(extension))
            {
                if (product != null && product.Photo=="new")
                {
                    fileInput.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
                    _productRepository.SavePhoto(productId, photoName);
                }
                else
                {
                    ViewBag.Error = "Помилка! Товар вже має фото!";
                    if (product != null)
                        return PartialView("EditPhoto", product);
                    return PartialView("EditPhoto", new Product());
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Помилка! Не вірне розширення фотографії!");
                if (product != null)
                    PartialView("EditPhoto", product);
                return PartialView("EditPhoto", new Product());
            }
            return PartialView("EditPhoto", product);
        }

        ////------------------------------------------------------------------------------------------------------------------------------------


        //#endregion

        #region Работа cо слайдером
        ////------------------------------------------------Стартовая страница------------------------------------------------------------------
        [HttpGet]
        public ActionResult SliderResult()
        {
            return View(_sliderRepository.Sliders.
                        OrderBy(x => x.Number));
        }
        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Добавление слайда----------------------------------------------------------------
        public ActionResult AddSlider()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSlider(Slider slider, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid && upload != null)
            {
                var photoName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(upload.FileName);
                photoName += extension;
                List<string> extensions = new List<string> { ".jpg", ".png", ".gif" };
                // сохраняем файл
                if (extensions.Contains(extension))
                {
                    upload.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
                }
                else
                {
                    ModelState.AddModelError("", "Помилка! Не вірне розширення фотографії!");
                    return View();
                }

                try
                {
                    slider.SlidePhoto = photoName;
                    //сохраняем новый товар
                    _sliderRepository.SaveSlider(slider);
                    TempData["message"] = "Слайд успішно доданий!";
                }
                catch (Exception)
                {
                    //при ошибке, удаляем файлы из директории
                    DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        if (file.ToString() == photoName)
                            file.Delete();
                    }
                    TempData["message"] = "Щось не так :( Слайд не був доданий!";
                }
                return RedirectToAction("SliderResult");
            }
            ModelState.AddModelError("",
                "Помилка! Слайд не був доданий! перевірте будь ласка правильність заповнення форми та наявність фото!");
            return View();
        }

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Редактировние слайда----------------------------------------------------------------

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Удаление удаление слайда---------------------------------------------------------------------

        ////------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region работа с заказами

        public ActionResult OrdeResult()
        {
            return View(_orderRepository.OrderDetailses.OrderByDescending(x=>x.DateOrder));
        }

        #endregion
    }


    //emum для сортировки по дате
    public enum SortType
    {
        None = 0,
        Before = 1,
        Later = 2
    }
    //emum для сортировки по категории
 

}
