using Cyclamen.Mobile.Repositories.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Models.MainPage
{
    public class MainPageModel : IMainPageModel
    {
        private ICarRepository _carRepository;

        public MainPageModel(ICarRepository carRepository)
            => _carRepository = carRepository;

        public async Task<List<CarModel>> LoadCars()
        {
            var cars = await _carRepository.GetCars();
            var manufactures = await _carRepository.GetManufactures();
            var models = await _carRepository.GetModels();
            return cars.Select(c => CarModel.FromCarDto(c,
                manufactures.FirstOrDefault(m => m.Id == c.ManufactureId),
                models.FirstOrDefault(m => m.Id == c.ModelId))).ToList();
        }
    }
}
