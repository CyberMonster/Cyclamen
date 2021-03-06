﻿using SQLite;

namespace Cyclamen.Mobile.DTO
{
    [Table("Cars")]
    public class Car
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int EngineId { get; set; }
        public int WheelsId { get; set; }
        public int CorpusId { get; set; }
        public int ModelId { get; set; }
    }
}
