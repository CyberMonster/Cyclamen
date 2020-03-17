using Cyclamen.Mobile.DTO;

namespace Cyclamen.Mobile.Models.MainPage
{
    public class CarModel
    {
        public int Id { get; set; }
        public string ManufactureName { get; set; }
        public string ModelName { get; set; }

        public static CarModel FromCarDto(Car car, Manufacture manufacture, Model model)
            => new CarModel
            {
                Id = car.Id,
                ManufactureName = manufacture?.Name,
                ModelName = model?.Name
            };
    }
}
