using System;
using Xamarin.Forms;

namespace pr_13
{
    public partial class MainPage : ContentPage
    {
        private Random _rnd = new Random();
        private int _clickCount = 0; 

        public MainPage()
        {
            InitializeComponent();
        }

        Color GetRandomColor()
        {
            return Color.FromRgb(_rnd.Next(0, 256), _rnd.Next(0, 256), _rnd.Next(0, 256));
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            _clickCount++;
            labelCount.Text = $"Кликов: {_clickCount}";

            button.BackgroundColor = GetRandomColor();

            double maxWidth = mainLayout.Width - button.Width;
            double maxHeight = mainLayout.Height - button.Height;

            if (maxWidth <= 0 || maxHeight <= 0) return;

            double randomX = _rnd.NextDouble() * maxWidth;
            double randomY = _rnd.NextDouble() * maxHeight;

            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.None);
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(randomX, randomY, button.Width, button.Height));
        }
    }
}