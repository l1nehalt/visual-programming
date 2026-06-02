using pr_14.Models;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace pr_14.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class TextNoteEntryPage : ContentPage
    {
        private string _selectedImagePath;

        public string ItemId
        {
            set { LoadNote(value); }
        }

        public TextNoteEntryPage()
        {
            InitializeComponent();
            BindingContext = new TextNote();
        }

        void LoadNote(string filename)
        {
            try
            {
                var lines = File.ReadAllLines(filename);
                string imagePath = lines.Length > 0 ? lines[0] : "";
                string text = lines.Length > 1 ? string.Join(Environment.NewLine, lines, 1, lines.Length - 1) : "";

                _selectedImagePath = imagePath;

                TextNote note = new TextNote
                {
                    Filename = filename,
                    Text = text,
                    ImagePath = imagePath,
                    Date = File.GetCreationTime(filename)
                };

                BindingContext = note;

                if (!string.IsNullOrEmpty(imagePath))
                {
                    noteImage.Source = ImageSource.FromFile(imagePath);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can't load note");
            }
        }
        async void OnSelectImageClicked(object sender, EventArgs e)
        {
            try
            {
                PermissionStatus status;

                if (DeviceInfo.Platform == DevicePlatform.Android && DeviceInfo.Version.Major >= 13)
                {
                    status = await Permissions.CheckStatusAsync<Permissions.Photos>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<Permissions.Photos>();
                    }
                }
                else
                {
                    status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<Permissions.StorageRead>();
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                    {
                        Title = "Please pick a photo"
                    });

                    if (result != null)
                    {
                        _selectedImagePath = result.FullPath;
                        noteImage.Source = ImageSource.FromFile(_selectedImagePath);

                        var note = (TextNote)BindingContext;
                        note.ImagePath = _selectedImagePath;
                    }
                }
                else
                {
                    await DisplayAlert("Доступ запрещен", "Приложению нужен доступ к галерее, чтобы выбрать фото.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось открыть галерею: {ex.Message}", "OK");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (TextNote)BindingContext;
            string filename = note.Filename;

            if (string.IsNullOrWhiteSpace(filename))
            {
                filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
            }

            string contentToSave = _selectedImagePath + Environment.NewLine + note.Text;
            File.WriteAllText(filename, contentToSave);

            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (TextNote)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}