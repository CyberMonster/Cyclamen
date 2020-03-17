using Cyclamen.Mobile.DTO;

namespace Cyclamen.Mobile.Models.CarDetailPage
{
    public class CarDetailModel
    {
        public int Id { get; set; }
        public Engine Engine { get; set; }
        public Wheels Wheels { get; set; }
        public Corpus Corpus { get; set; }
        public Model Model { get; set; }
        public Manufacture Manufacture { get; set; }
    }
}
