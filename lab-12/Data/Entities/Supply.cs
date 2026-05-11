namespace lab_12.Data.Entities
{
    public class Supply
    {
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public int? Volume { get; set; }
        public Supplier Supplier { get; set; }
        public Item Item { get; set; }
    }
}
