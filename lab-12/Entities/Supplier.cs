using System;
using SQLite;

namespace Model
{
    public partial class Supplier
    {
        [PrimaryKey]
        public Int64 ID { get; set; }
        
        [NotNull]
        public String Name { get; set; }
        
        [NotNull]
        public String Address { get; set; }
        
        public String Phone { get; set; }
        
    }
    
}
