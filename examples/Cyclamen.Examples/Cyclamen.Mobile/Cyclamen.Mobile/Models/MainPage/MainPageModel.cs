using Cyclamen.Mobile.Repositories.Cars;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Models.MainPage
{
    public class MainPageModel : IMainPageModel
    {
        private readonly ICarRepository _carRepository;

        public MainPageModel(ICarRepository carRepository)
            => _carRepository = carRepository;

        public async Task<List<CarModel>> LoadCars()
        {
            var cars = await _carRepository.GetCars();
            var manufactures = await _carRepository.GetManufactures();
            var models = await _carRepository.GetModels();
            var modelsWithManufactures = models.Join(manufactures,
                mod => mod.ManufactureId,
                man => man.Id,
                (mod, man) => (mod, man)).ToList();
            return cars.Select(c =>
            {
                var (model, manufacture) = modelsWithManufactures.FirstOrDefault((mwm) => mwm.mod.Id == c.ModelId);
                return CarModel.FromCarDto(c, manufacture, model);
            }).ToList();
        }
    }
}
