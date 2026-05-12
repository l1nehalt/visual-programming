using System;
using System.ComponentModel;
using SQLite;

namespace Model
{
    public partial class Item
    {
        [PrimaryKey]
        [DisplayName("ID Товара")]
        public Int64 ID { get; set; }
        
        [NotNull]
        [DisplayName("Наименование")]
        public String Name { get; set; }
        
        [NotNull]
        [DisplayName("Производитель")]
        public String Manufacturer { get; set; }
        
        [NotNull]
        [DisplayName("Стоимость")]
        public Decimal Price { get; set; }
    }
}
