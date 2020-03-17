using SQLite;

namespace Cyclamen.Mobile.DTO
{
    public abstract class DefaultEntity
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
