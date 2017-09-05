using System.Collections.Generic;
using System.IO;
using Domain.Entityes;

namespace Domain.Abstrac
{
    /// <summary>
    /// Интерфейс возвращающий коллекцию слайдов из БД
    /// </summary>
    public interface ISliderRepository
    {
        IEnumerable<Slider> Sliders { get; }
        void SaveSlider(Slider slider);
        void RemoveSlider(int sliderId, DirectoryInfo directory);
        void SavePhoto(int sliderId, string url);
        void RemovePhoto(int sliderId, DirectoryInfo directory);
    }
}