using pr_14.Views;
using Xamarin.Forms;

namespace pr_14
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TextNoteEntryPage), typeof(TextNoteEntryPage));
        }
    }
}
