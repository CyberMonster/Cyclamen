using SQLite;

namespace Cyclamen.Mobile.DTO
{
    [Table("Models")]
    public class Model : DefaultEntity
    {
        public int ManufactureId { get; set; }
        public int SellStartYear { get; set; }
        public int SellEndYear { get; set; }
    }
}
