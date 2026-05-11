using lab_12.Data;

namespace lab_12
{
    public static class Program
    {
       
        [STAThread]
        static void Main()
        {
            using (var db = new SupplyContext())
            {
                db.Database.EnsureCreated();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new SupplyForm());
        }
    }
}