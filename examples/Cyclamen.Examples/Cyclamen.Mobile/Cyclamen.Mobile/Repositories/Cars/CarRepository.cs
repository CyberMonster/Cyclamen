using Cyclamen.Mobile.Configuration;
using Cyclamen.Mobile.DTO;
using Cyclamen.Mobile.Helpers;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cyclamen.Mobile.Repositories.Cars
{
    public class CarRepository : ICarRepository
    {
        private readonly SQLiteAsyncConnection _connection;
        public CarRepository(IResourceHelper resourceHelper)
        {
            _connection = new SQLiteAsyncConnection(resourceHelper.GetResourcePath(ReposConnection.CarRepositoryConnection));
            _connection.CreateTableAsync<Car>().Wait();
            _connection.CreateTableAsync<Engine>().Wait();
            _connection.CreateTableAsync<Wheel>().Wait();
            _connection.CreateTableAsync<Corpus>().Wait();
        }

        public async Task<List<Car>> GetCars()
            => await _connection.Table<Car>().ToListAsync();

        public async Task<List<Engine>> GetEngines()
            => await _connection.Table<Engine>().ToListAsync();

        public async Task<List<Wheel>> GetWheels()
            => await _connection.Table<Wheel>().ToListAsync();

        public async Task<List<Corpus>> GetCorpuses()
            => await _connection.Table<Corpus>().ToListAsync();

        public async Task<List<Manufacture>> GetManufactures()
            => await _connection.Table<Manufacture>().ToListAsync();

        public async Task<List<Model>> GetModels()
            => await _connection.Table<Model>().ToListAsync();

        public async Task<Car> GetCar(int id)
            => await _connection.GetAsync<Car>(id);

        public async Task<Engine> GetEngine(int id)
            => await _connection.GetAsync<Engine>(id);

        public async Task<Wheel> GetWheel(int id)
            => await _connection.GetAsync<Wheel>(id);

        public async Task<Corpus> GetCorpus(int id)
            => await _connection.GetAsync<Corpus>(id);

        public async Task<Manufacture> GetManufacture(int id)
            => await _connection.GetAsync<Manufacture>(id);

        public async Task<Model> GetModel(int id)
            => await _connection.GetAsync<Model>(id);
    }
}
