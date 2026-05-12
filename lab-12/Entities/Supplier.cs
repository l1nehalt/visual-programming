using System;
using System.ComponentModel;
using SQLite;

namespace Model
{
    public partial class Supplier
    {
        [PrimaryKey]
        [DisplayName("ID Поставщика")]
        public Int64 ID { get; set; }
        
        [NotNull]
        [DisplayName("ФИО")]
        public String Name { get; set; }
        
        [NotNull]
        [DisplayName("Адрес")]
        public String Address { get; set; }

        [DisplayName("Телефон")]
        public String Phone { get; set; }
        
    }
    
}
