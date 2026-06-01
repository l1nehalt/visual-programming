using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_14.Entities
{
    [Table("Item")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }

}
