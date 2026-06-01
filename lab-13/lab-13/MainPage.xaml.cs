using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace lab_13
{
    public partial class MainPage : ContentPage
    {
        private bool isBlinking = false;
        private bool isFlashOn = false;
        private CancellationTokenSource blinkCts;
        private string lastSelectedPhoneNumber = string.Empty;

        public MainPage()
        {
            InitializeComponent();
        }

        private void GyroscopeBtn_Clicked(object sender, EventArgs e)
        {
           
            if (!Gyroscope.IsMonitoring)
            {
                Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                Gyroscope.Start(SensorSpeed.UI);
            }
        }

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                gyroscopeLabel.Text = $"X: {data.AngularVelocity.X:F2}\n" +
                                      $"Y: {data.AngularVelocity.Y:F2}\n" +
                                      $"Z: {data.AngularVelocity.Z:F2}";
            });
        }


        private void BatteryBtn_Clicked(object sender, EventArgs e)
        {
            var level = Battery.ChargeLevel;

            string chargeText =
                level < 0
                ? "Неизвестно"
                : $"{level * 100:F0}%";

            batteryLabel.Text =
                $"Заряд: {chargeText}\n" +
                $"Статус: {Battery.State}\n" +
                $"Источник: {Battery.PowerSource}";
        }

        private void DeviceBtn_Clicked(object sender, EventArgs e)
        {
            deviceLabel.Text =
                $"Модель: {DeviceInfo.Model}\n" +
                $"Производитель: {DeviceInfo.Manufacturer}\n" +
                $"ОС: {DeviceInfo.Platform} {DeviceInfo.VersionString}";
        }

        private void DisplayBtn_Clicked(object sender, EventArgs e)
        {
            var metrics = DeviceDisplay.MainDisplayInfo;

            displayLabel.Text =
                $"Экран: {metrics.Width}x{metrics.Height}\n" +
                $"Плотность: {metrics.Density:F2}\n" +
                $"Частота обновления экрана: {metrics.RefreshRate}";
        }

        private async void FlashBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!isFlashOn)
                {
                    await Flashlight.TurnOnAsync();

                    isFlashOn = true;

                    flashBtn.Text = "Выключить фонарик";
                }
                else
                {
                    await Flashlight.TurnOffAsync();

                    isFlashOn = false;

                    flashBtn.Text = "Включить фонарик";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Ошибка",
                    $"Фонарик недоступен: {ex.Message}",
                    "OK");
            }
        }

        private async void BlinkBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (isBlinking)
                {
                    blinkCts?.Cancel();

                    isBlinking = false;

                    blinkBtn.Text = "Мигать (1 сек)";

                    await Flashlight.TurnOffAsync();

                    return;
                }

                isBlinking = true;

                blinkBtn.Text = "Остановить мигание";

                blinkCts = new CancellationTokenSource();

                bool state = false;

                while (!blinkCts.Token.IsCancellationRequested)
                {
                    state = !state;

                    if (state)
                        await Flashlight.TurnOnAsync();
                    else
                        await Flashlight.TurnOffAsync();

                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

        private async void ScreenshotBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var screenshot = await Screenshot.CaptureAsync();

                screenLabel.Text =
                    $"Скриншот сделан!\n" +
                    $"Размер: {screenshot.Width}x{screenshot.Height}";

                var stream = await screenshot.OpenReadAsync();

                screenshotImage.Source =
                    ImageSource.FromStream(() => stream);
            }
            catch (Exception ex)
            {
                screenLabel.Text =
                    $"Ошибка скриншота: {ex.Message}";
            }
        }

        private async void ContactBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var status =
                    await Permissions.CheckStatusAsync<Permissions.ContactsRead>();

                if (status != PermissionStatus.Granted)
                {
                    status =
                        await Permissions.RequestAsync<Permissions.ContactsRead>();
                }

                if (status == PermissionStatus.Granted)
                {
                    var contacts = await Contacts.GetAllAsync();

                    var list =
                        contacts
                        .Where(c => c.Phones.Any())
                        .ToList();

                    if (list.Any())
                    {
                        var rand = new Random().Next(list.Count);

                        var contact = list[rand];

                        lastSelectedPhoneNumber =
                            contact.Phones.First().PhoneNumber;

                        contactLabel.Text =
                            $"Контакт: {contact.DisplayName}\n" +
                            $"Тел: {lastSelectedPhoneNumber}";

                        dialBtn.IsEnabled = true;
                    }
                    else
                    {
                        contactLabel.Text =
                            "В телефонной книге нет контактов с номерами.";
                    }
                }
                else
                {
                    contactLabel.Text =
                        "Доступ к контактам отклонен пользователем.";
                }
            }
            catch (Exception ex)
            {
                contactLabel.Text =
                    $"Ошибка работы с контактами: {ex.Message}";
            }
        }

        private void DialBtn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastSelectedPhoneNumber))
            {
                PhoneDialer.Open(lastSelectedPhoneNumber);
            }
        }
    }
}