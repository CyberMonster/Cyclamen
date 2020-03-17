using Cyclamen.Mobile.Repositories.Cars;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Models.CarDetailPage
{
    public class CarDetailPageModel : ICarDetailPageModel
    {
        private readonly ICarRepository _carRepository;

        public CarDetailPageModel(ICarRepository carRepository)
            => _carRepository = carRepository;

        public async Task<CarDetailModel> LoadCar(int carId)
        {
            var car = await _carRepository.GetCar(carId);
            var model = await _carRepository.GetModel(car.ModelId);
            return new CarDetailModel
            {
                Engine = await _carRepository.GetEngine(car.EngineId),
                Wheels = await _carRepository.GetWheel(car.WheelsId),
                Corpus = await _carRepository.GetCorpus(car.CorpusId),
                Model = model,
                Manufacture = await _carRepository.GetManufacture(model.ManufactureId),
            };
        }
    }
}
