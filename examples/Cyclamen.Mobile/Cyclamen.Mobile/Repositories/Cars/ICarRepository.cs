using Cyclamen.Mobile.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Repositories.Cars
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetCars();
        public Task<List<Engine>> GetEngines();
        public Task<List<Wheels>> GetWheels();
        public Task<List<Corpus>> GetCorpuses();
        public Task<List<Manufacture>> GetManufactures();
        public Task<List<Model>> GetModels();

        public Task<Car> GetCar(int id);
        public Task<Engine> GetEngine(int id);
        public Task<Wheels> GetWheel(int id);
        public Task<Corpus> GetCorpus(int id);
        public Task<Manufacture> GetManufacture(int id);
        public Task<Model> GetModel(int id);
    }
}
