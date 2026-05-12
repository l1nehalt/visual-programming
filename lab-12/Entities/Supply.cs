using System;
using SQLite;

namespace Model
{
    public partial class Supply
    {
        [NotNull]
        public Int64 SupplierID { get; set; }
        
        [NotNull]
        public Int64 ItemID { get; set; }
        
        [NotNull]
        public DateTime Date { get; set; }
        
        public Int64? Volume { get; set; }
        
    }
    
}
