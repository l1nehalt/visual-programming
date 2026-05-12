using System;
using System.ComponentModel;
using SQLite;

namespace Model
{
    public partial class Supply
    {
        [NotNull]
        [DisplayName("ID Поставки")]
        public Int64 SupplierID { get; set; }
        
        [NotNull]
        [DisplayName("ID Товара")]
        public Int64 ItemID { get; set; }
        
        [NotNull]
        [DisplayName("Дата поставки")]
        public DateTime Date { get; set; }

        [DisplayName("Объем")]
        public Int64? Volume { get; set; }
        
    }
    
}
