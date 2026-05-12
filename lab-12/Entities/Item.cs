using System;
using SQLite;

namespace Model
{
    public partial class Item
    {
        [PrimaryKey]
        public Int64 ID { get; set; }
        
        [NotNull]
        public String Name { get; set; }
        
        [NotNull]
        public String Manufacturer { get; set; }
        
        [NotNull]
        public Decimal Price { get; set; }
    }
}
