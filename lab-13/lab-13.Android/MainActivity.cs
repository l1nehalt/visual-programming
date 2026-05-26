using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XamarinEssentialsLab
{
    [Activity(Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : Activity
    {
        private bool isBlinking = false;
        private bool isFlashOn = false; 
        private CancellationTokenSource blinkCts;
        private string lastSelectedPhoneNumber = string.Empty;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);

            // Используем ScrollView, чтобы все элементы и скриншот поместились на экране с прокруткой
            var scrollView = new ScrollView(this);
            var layout = new LinearLayout(this) { Orientation = Orientation.Vertical };
            layout.SetPadding(30, 30, 30, 30);

            // 1. Батарея (Исправлено падение)
            var batteryLabel = new TextView(this) { Text = "1. Информация о батарее", TextSize = 16 };
            var batteryBtn = new Button(this) { Text = "Обновить батарею" };
            batteryBtn.Click += (s, e) => {
                var level = Battery.ChargeLevel;
                string chargeText = level < 0 ? "Неизвестно" : $"{level * 100:F0}%";
                batteryLabel.Text = $"Заряд: {chargeText}, Статус: {Battery.State}, Источник: {Battery.PowerSource}";
            };
            layout.AddView(batteryLabel); layout.AddView(batteryBtn);

            // 2. Устройство
            var deviceLabel = new TextView(this) { Text = "\n2. Информация об устройстве", TextSize = 16 };
            var deviceBtn = new Button(this) { Text = "Получить инфо" };
            deviceBtn.Click += (s, e) => {
                deviceLabel.Text = $"Модель: {DeviceInfo.Model}\nПроизводитель: {DeviceInfo.Manufacturer}\nОС: {DeviceInfo.Platform} {DeviceInfo.VersionString}";
            };
            layout.AddView(deviceLabel); layout.AddView(deviceBtn);

            // 3. Дисплей
            var displayLabel = new TextView(this) { Text = "\n3. Информация о дисплее", TextSize = 16 };
            var displayBtn = new Button(this) { Text = "Получить инфо экрана" };
            displayBtn.Click += (s, e) => {
                var metrics = DeviceDisplay.MainDisplayInfo;
                displayLabel.Text = $"Экран: {metrics.Width}x{metrics.Height}, Плотность: {metrics.Density:F2}, {metrics.Rotation}";
            };
            layout.AddView(displayLabel); layout.AddView(displayBtn);

            // 4. Фонарик Вкл/Выкл (Исправлено выключение)
            var flashBtn = new Button(this) { Text = "Включить фонарик" };
            flashBtn.Click += async (s, e) => {
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
                    Toast.MakeText(this, $"Фонарик недоступен: {ex.Message}", ToastLength.Short).Show();
                }
            };
            layout.AddView(new TextView(this) { Text = "\n4. Управление фонариком", TextSize = 16 });
            layout.AddView(flashBtn);

            // 5. Мигание фонариком
            var blinkBtn = new Button(this) { Text = "Мигать (1 сек)" };
            blinkBtn.Click += async (s, e) => {
                if (isBlinking)
                {
                    blinkCts?.Cancel();
                    isBlinking = false;
                    blinkBtn.Text = "Мигать (1 sec)";
                    await Flashlight.TurnOffAsync();
                }
                else
                {
                    isBlinking = true;
                    blinkBtn.Text = "Остановить мигание";
                    blinkCts = new CancellationTokenSource();
                    _ = Task.Run(async () => {
                        bool state = false;
                        while (!blinkCts.Token.IsCancellationRequested)
                        {
                            try
                            {
                                state = !state;
                                if (state) await Flashlight.TurnOnAsync();
                                else await Flashlight.TurnOffAsync();
                                await Task.Delay(1000, blinkCts.Token);
                            }
                            catch { }
                        }
                    });
                }
            };
            layout.AddView(blinkBtn);

            // 6. Скриншот (Исправлено визуальное отображение)
            var screenLabel = new TextView(this) { Text = "\n6. Скриншот", TextSize = 16 };
            var screenBtn = new Button(this) { Text = "Сделать скриншот" };
            var screenshotImageView = new ImageView(this); // Элемент для вывода картинки на экран

            screenBtn.Click += async (s, e) => {
                try
                {
                    var screenshot = await Screenshot.CaptureAsync();
                    screenLabel.Text = $"Скриншот сделан! Размер: {screenshot.Width}x{screenshot.Height}\nОтображен ниже:";

                    // Конвертируем поток скриншота в картинку для Android
                    using (var stream = await screenshot.OpenReadAsync())
                    {
                        var bitmap = BitmapFactory.DecodeStream(stream);
                        // Уменьшим картинку, чтобы она аккуратно смотрелась в приложении
                        screenshotImageView.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap, 400, 700, true));
                    }
                }
                catch (Exception ex)
                {
                    screenLabel.Text = $"Ошибка скриншота: {ex.Message}";
                }
            };
            layout.AddView(screenLabel); layout.AddView(screenBtn); layout.AddView(screenshotImageView);

            // 7. Контакты (Исправлен runtime-запрос разрешения)
            var contactLabel = new TextView(this) { Text = "\n7. Случайный контакт", TextSize = 16 };
            var contactBtn = new Button(this) { Text = "Получить контакт" };
            var dialBtn = new Button(this) { Text = "Передать в звонилку" };
            dialBtn.Enabled = false;

            contactBtn.Click += async (s, e) => {
                try
                {
                    // ПРИНУДИТЕЛЬНЫЙ ЗАПРОС РАЗРЕШЕНИЯ НА ЭКРАНЕ ТЕЛЕФОНА
                    var status = await Permissions.CheckStatusAsync<Permissions.ContactsRead>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<Permissions.ContactsRead>();
                    }

                    if (status == PermissionStatus.Granted)
                    {
                        var contacts = await Contacts.GetAllAsync();
                        var list = contacts.Where(c => c.Phones.Any()).ToList();
                        if (list.Any())
                        {
                            var rand = new Random().Next(list.Count);
                            var contact = list[rand];
                            lastSelectedPhoneNumber = contact.Phones.First().PhoneNumber;
                            contactLabel.Text = $"Контакт: {contact.DisplayName}\nТел: {lastSelectedPhoneNumber}";
                            dialBtn.Enabled = true;
                        }
                        else
                        {
                            contactLabel.Text = "В телефонной книге нет контактов с номерами.";
                        }
                    }
                    else
                    {
                        contactLabel.Text = "Доступ к контактам отклонен пользователем.";
                    }
                }
                catch (Exception ex)
                {
                    contactLabel.Text = $"Ошибка работы с контактами: {ex.Message}";
                }
            };
            layout.AddView(contactLabel); layout.AddView(contactBtn);

            // 8. Набор номера
            dialBtn.Click += (s, e) => {
                if (!string.IsNullOrEmpty(lastSelectedPhoneNumber))
                {
                    PhoneDialer.Open(lastSelectedPhoneNumber);
                }
            };
            layout.AddView(dialBtn);

            scrollView.AddView(layout);
            SetContentView(scrollView);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}