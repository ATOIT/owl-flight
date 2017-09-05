using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.Abstrac;
using Domain.Entityes;


namespace Domain.Concrete
{
    public class EfSliderRepository : ISliderRepository
    {
        readonly ShopContext _context = new ShopContext();

        public IEnumerable<Slider> Sliders => _context.Slider;
        public void SaveSlider(Slider slider)
        {
            if (slider.SlideId == 0)
            {
                _context.Slider.Add(new Slider
                {
                    Name = slider.Name,
                    Number = slider.Number,
                    SlideDescription = slider.SlideDescription,
                    SlidePhoto = slider.SlidePhoto
                });
                _context.SaveChanges();
            }
            else
            {
                Slider slid = _context.Slider.Find(slider.SlideId);
                if (slid != null)
                {
                    slid.Name = slider.Name;
                    slid.SlideDescription = slider.SlideDescription;
                    slid.Number = slider.Number;
                    slid.SlidePhoto = slider.SlidePhoto;
                    _context.SaveChanges();
                }
                else
                    throw new Exception();
            }
        }

        public void RemoveSlider(int sliderId, DirectoryInfo directory)
        {
            Slider slid = _context.Slider.FirstOrDefault(x => x.SlideId == sliderId);
            if (slid != null)
            {
                var urlPhoto = slid.SlidePhoto;
                _context.Slider.Remove(slid);
                _context.SaveChanges();
                foreach (FileInfo file in directory.GetFiles()) //Удаление фото из директории
                {
                    if (urlPhoto.Equals(file.ToString()))
                        file.Delete();
                }
            }
            else
                throw new Exception();
        }

        public void SavePhoto(int sliderId, string url)
        {
            var oneSlide = _context.Slider.FirstOrDefault(x => x.SlideId == sliderId);
            if (oneSlide != null)
            {
                try
                {
                    oneSlide.SlidePhoto = url;
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

        public void RemovePhoto(int sliderId, DirectoryInfo directory)
        {
            var oneSlide = _context.Slider.FirstOrDefault(x => x.SlideId == sliderId);
            if (oneSlide != null)
            {
                try
                {
                    var urlDell = oneSlide.SlidePhoto;
                    oneSlide.SlidePhoto = "";
                    _context.SaveChanges();
                    foreach (FileInfo file in directory.GetFiles()) 
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
