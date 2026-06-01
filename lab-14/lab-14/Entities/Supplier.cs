using SQLite;

namespace lab_14.Entities
{
    [Table("Supplier")]
    public class Supplier
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
    }
}