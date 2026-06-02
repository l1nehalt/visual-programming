using pr_14.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace pr_14.Views
{
    public partial class TextNotesPage : ContentPage
    {
        private string _selectedImagePath;
        private string _activeFilename; 

        public TextNotesPage()
        {
            InitializeComponent();
        }

        void OnAddClicked(object sender, EventArgs e)
        {
            _activeFilename = null;
            _selectedImagePath = null;

            noteTitleEntry.Text = string.Empty;
            editor.Text = string.Empty;
            noteImage.Source = null;

            imageContainer.IsVisible = false;

            editForm.IsVisible = true;
        }

        async void OnSelectImageClicked(object sender, EventArgs e)
        {
            try
            {
                PermissionStatus status;

                if (DeviceInfo.Platform == DevicePlatform.Android &&
                    DeviceInfo.Version.Major >= 13)
                {
                    status = await Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.Photos>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<Xamarin.Essentials.Permissions.Photos>();
                    }
                }
                else
                {
                    status = await Permissions.CheckStatusAsync<Xamarin.Essentials.Permissions.StorageRead>();
                    if (status != PermissionStatus.Granted)
                    {
                        status = await Permissions.RequestAsync<Xamarin.Essentials.Permissions.StorageRead>();
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    var result = await MediaPicker.PickPhotoAsync(new Xamarin.Essentials.MediaPickerOptions
                    {
                        Title = "Please pick a photo"
                    });

                    if (result != null)
                    {
                        _selectedImagePath = result.FullPath;
                        noteImage.Source = ImageSource.FromFile(_selectedImagePath);

                        imageContainer.IsVisible = true;
                    }
                }
                else
                {
                    await DisplayAlert("Доступ запрещен", "Нужен доступ к галерее, чтобы выбрать фото.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", $"Не удалось открыть галерею: {ex.Message}", "OK");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(noteTitleEntry.Text))
            {
                await DisplayAlert("Внимание", "Необходимо ввести название заметки", "OK");

                noteTitleEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(_activeFilename))
            {
                _activeFilename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
            }

            string contentToSave = $"{_selectedImagePath}{Environment.NewLine}{noteTitleEntry.Text}{Environment.NewLine}{editor.Text}";
            File.WriteAllText(_activeFilename, contentToSave);

            noteTitleEntry.Text = string.Empty;
            editor.Text = string.Empty;
            noteImage.Source = null;
            _selectedImagePath = null;
            _activeFilename = null;

            imageContainer.IsVisible = false;
            editForm.IsVisible = false;

            UpdateFileList();
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_activeFilename) && File.Exists(_activeFilename))
            {
                File.Delete(_activeFilename);
            }

            noteTitleEntry.Text = string.Empty;
            editor.Text = string.Empty;
            noteImage.Source = null;
            _selectedImagePath = null;
            _activeFilename = null;

            imageContainer.IsVisible = false;
            editForm.IsVisible = false;

            UpdateFileList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateFileList();
        }

        void UpdateFileList()
        {
            var notes = new List<TextNote>();

            if (Directory.Exists(App.FolderPath))
            {
                var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");
                foreach (var filename in files)
                {
                    var lines = File.ReadAllLines(filename);

                    string imagePath = lines.Length > 0 ? lines[0] : "";
                    string title = lines.Length > 1 ? lines[1] : "";

                    string text = lines.Length > 2 ? string.Join(Environment.NewLine, lines, 2, lines.Length - 2) : "";

                    string displayText = !string.IsNullOrWhiteSpace(title) ? title : text;

                    notes.Add(new TextNote
                    {
                        Filename = filename,
                        Text = displayText, 
                        ImagePath = imagePath,
                        Date = File.GetCreationTime(filename)
                    });
                }
            }

            collectionView.ItemsSource = notes
                .OrderByDescending(d => d.Date)
                .ToList();
        }

        void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                TextNote note = (TextNote)e.CurrentSelection.FirstOrDefault();
                collectionView.SelectedItem = null; 

                if (File.Exists(note.Filename))
                {
                    _activeFilename = note.Filename;

                    var lines = File.ReadAllLines(note.Filename);
                    _selectedImagePath = lines.Length > 0 ? lines[0] : "";
                    string title = lines.Length > 1 ? lines[1] : "";
                    string text = lines.Length > 2 ? string.Join(Environment.NewLine, lines, 2, lines.Length - 2) : "";

                    noteTitleEntry.Text = title;
                    editor.Text = text;

                    if (!string.IsNullOrEmpty(_selectedImagePath) && File.Exists(_selectedImagePath))
                    {
                        noteImage.Source = ImageSource.FromFile(_selectedImagePath);
                        imageContainer.IsVisible = true;
                    }
                    else
                    {
                        noteImage.Source = null;
                        imageContainer.IsVisible = false;
                    }

                    editForm.IsVisible = true;
                }
            }
        }
    }
}