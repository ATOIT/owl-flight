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
        //public ActionResult AddProduct()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddProduct(Product product, HttpPostedFileBase upload,
        //    IEnumerable<HttpPostedFileBase> uploads)
        //{
        //    if (ModelState.IsValid && upload != null)
        //    {
        //        List<Photo> list = new List<Photo>();
        //        var photoName = Guid.NewGuid().ToString();
        //        var extension = Path.GetExtension(upload.FileName);
        //        photoName += extension;
        //        List<string> extensions = new List<string> {".jpg", ".png", ".gif"};
        //        // сохраняем файл
        //        if (extensions.Contains(extension))
        //        {
        //            upload.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
        //            list.Add(new Photo {PhotoUrl = photoName, Priority = true});
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Ошибка! Не верное расширение фотографии!");
        //            return View();
        //        }
        //        foreach (var file in uploads)
        //        {

        //            if (file != null)
        //            {
        //                photoName = Guid.NewGuid().ToString();
        //                extension = Path.GetExtension(file.FileName);
        //                photoName += extension;
        //                // сохраняем файл в папку Files в проекте
        //                if (extensions.Contains(extension))
        //                {
        //                    file.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
        //                    list.Add(new Photo {PhotoUrl = photoName, Priority = false});
        //                }
        //                else
        //                {
        //                    ModelState.AddModelError("", "Ошибка! Не верное расширение фотографии!");
        //                    return View();
        //                }
        //            }
        //        }
        //        try
        //        {
        //            //сохраняем новый товар
        //            _productRepository.SaveProduct(product, list);
        //            TempData["message"] = "Товар успешно добавлен!";
        //        }
        //        catch (Exception)
        //        {
        //            //при ошибке, удаляем файлы из директории
        //            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
        //            foreach (FileInfo file in directory.GetFiles())
        //            {
        //                foreach (var i in list)
        //                {
        //                    if (i.PhotoUrl.Contains(file.ToString()))
        //                        file.Delete();
        //                }
        //            }
        //            TempData["message"] = "что то пошло не так :( Товар не был добавлен!";
        //        }
        //        return RedirectToAction("MyPanel");
        //    }
        //    ModelState.AddModelError("",
        //        "Ошибка! Товар не был добавлен! проверьте пожалуйста правильность заполнения формы и наличие фото!");
        //    return View();
        //}

        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Редактировние товара----------------------------------------------------------------
        [HttpGet]
        public ActionResult EditProduct(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == productId);

            return View(product);
        }

        //[HttpPost]
        //public ActionResult EditProduct(Product product)
        //{
        //    var qvery = _productRepository.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

        //    if (qvery != null && ModelState.IsValid && !qvery.Photo.Count.Equals(0))
        //    {
        //        try
        //        {
        //            _productRepository.SaveProduct(product, null);
        //            TempData["message"] = "Изменения в товаре были сохранены";
        //        }
        //        catch (Exception)
        //        {
        //            TempData["messageBad"] = "что то пошло не так :( Товар не был изменен!";
        //        }
        //        return RedirectToAction("MyPanel");
        //    }
        //    ModelState.AddModelError("",
        //        "Ошибка! Товар не был изменен! проверьте пожалуйста правильность заполнения формы и наличие фото!");
        //    var productSelect = _productRepository.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
        //    return View("EditProduct", productSelect);

        //}

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
        //[HttpPost]
        //public ActionResult PriorityСhangesPhoto(int idProduct, int id) // Изменение приоритета фото
        //{
        //    try
        //    {
        //        _productRepository.PriorityСhangesPhoto(idProduct,id);
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "Ошибка! Что то пошло не так :( Приоритет фото не был изменен!";
        //    }
        //    var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == idProduct);
        //    if (product != null)
        //        return PartialView("EditPhoto", product.Photo.ToList());
        //    return PartialView("EditPhoto", new List<Photo>());
        //}


        //[HttpPost]
        //public ActionResult DeletePhoto(int idProduct, int id = 0) // Удаление фото
        //{
        //    DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/PhotoForDB/"));
        //    try
        //    {
        //        _productRepository.RemovePhoto(idProduct, id, directory);
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "Ошибка! Что то пошло не так :( Мы не смогли удалить фото! ";
        //    }
        //    var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == idProduct);
        //    if (product != null)
        //        return  PartialView("EditPhoto", product.Photo.ToList());
        //    return PartialView("EditPhoto", new List<Photo>());
        //}
        ////------------------------------------------------------------------------------------------------------------------------------------
        ////------------------------------------------------Добавление фото на сервер-----------------------------------------------------------

        //[HttpPost]
        //public ActionResult UploadPhoto(int productId, HttpPostedFileBase fileInput)
        //{
        //    var product = _productRepository.Products.FirstOrDefault(x => x.ProductId == productId);
        //    var photoName = Guid.NewGuid().ToString();
        //    var extension = Path.GetExtension(fileInput.FileName);
        //    photoName += extension;
        //    List<string> extensions = new List<string> { ".jpg", ".png", ".gif" };
        //    // сохраняем файл
        //    if (extensions.Contains(extension))
        //    {
        //        fileInput.SaveAs(Server.MapPath("~/PhotoForDB/" + photoName));
        //        _productRepository.SavePhoto(productId, photoName);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Ошибка! Не верное расширение фотографии!");
        //        if (product != null)
        //            PartialView("EditPhoto", product.Photo.ToList());
        //        return PartialView("EditPhoto", new List<Photo>());
        //    }
        //    if (product != null)
        //        return PartialView("EditPhoto", product.Photo.ToList());
        //    return PartialView("EditPhoto", new List<Photo>() );
        //}

        ////------------------------------------------------------------------------------------------------------------------------------------


        //#endregion

        #region Работа cо слайдером
        ////------------------------------------------------Стартовая страница------------------------------------------------------------------
        [HttpGet]
        public ActionResult SliderResult()
        {
            //выбираем все отзывы
            return View(_sliderRepository.Sliders.
                        OrderBy(x => x.Number));
        }

        //[HttpPost]
        //public ActionResult EditingReviews(SortType sortType)
        //{
        //    //сортируем отзывы
        //    var reviews = _reviewsRepository.Reviewses;
        //    switch (sortType)
        //    {
        //        case SortType.Before:
        //            reviews = _reviewsRepository.Reviewses.
        //                OrderByDescending(x => x.DateFeedback);
        //            break;
        //        case SortType.Later:
        //            reviews = _reviewsRepository.Reviewses.
        //                OrderBy(x => x.DateFeedback);
        //            break;
        //    }
        //    return PartialView("PartialEditingReviews", reviews);
        //}


        ////------------------------------------------------------------------------------------------------------------------------------------

        ////------------------------------------------------Редактировние отзыва----------------------------------------------------------------
        //[HttpGet]
        //public ActionResult EditReview(int reviewId)
        //{
        //    //выбираем отзыв для редактирования
        //    var review = _reviewsRepository.Reviewses.FirstOrDefault(x => x.ReviewId == reviewId);
        //    return View(review);
        //}

        //[HttpPost]
        //public ActionResult EditReview(Reviews review)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //пробуем отредактировать отзыв
        //            _reviewsRepository.SaveReview(review);
        //            TempData["message"] = "Изменения в отзыве были сохранены";
        //            return RedirectToAction("EditingReviews");
        //        }
        //        TempData["message"] = "Ошибка! Изменения не были сохранены, проверьте данные!";
        //        return RedirectToAction("EditReview", review.ReviewId);
        //    }
        //    catch (Exception)
        //    {
        //        TempData["message"] = "Ошибка! мы не смогли сохранить изменения в отзыве :(";
        //        return RedirectToAction("EditReview", review.ReviewId);
        //    }
        //}
        ////------------------------------------------------------------------------------------------------------------------------------------


        ////------------------------------------------------Удаление отзыва---------------------------------------------------------------------
        //[HttpGet]
        //public ActionResult DeleteReviews(int reviewId)
        //{
        //    //выбираем отзыв для удаления
        //    var review = _reviewsRepository.Reviewses.FirstOrDefault(x => x.ReviewId == reviewId);
        //    return View(review);
        //}

        //[HttpPost]
        //public ActionResult DeleteReviews(Reviews review)
        //{
        //    try
        //    {
        //        //пробуем удалить отзыв
        //        _reviewsRepository.RemoveReview(review);
        //        TempData["message"] = "Отзыв был успешно удален!";
        //        return RedirectToAction("EditingReviews");
        //    }
        //    catch (Exception)
        //    {
        //        //ошибка в базе и т.д.
        //        TempData["message"] = "Ошибка! Мы не смогли удалить отзыв :( ";
        //        return RedirectToAction("DeleteReviews", review.ReviewId);
        //    }
        //}
        ////------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region работа с заказами

        public ActionResult OrdeResult()
        {
            return View();
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
