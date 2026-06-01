using System;
using SQLite;

namespace lab_14.Entities
{
    [Table("Supply")]
    public class Supply
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public int ItemId { get; set; }

        public DateTime Date { get; set; }

        public int Volume { get; set; }
    }
}
