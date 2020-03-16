using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpFunctionalExtensions;
using MyPhotos.Domain;
using MyPhotos.Domain.Interfaces;

namespace MyPhotos.Gui.WindowsForms.Forms
{
    public partial class PhotosForm : Form
    {
        private readonly IRepository<Photo> repository;

        public PhotosForm(IRepository<Photo> repository)
        {
            this.repository = repository;

            InitializeComponent();
            InitEvents();
        }

        protected override async void OnLoad(EventArgs e)
        {
            await LoadList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.PhotosList.Items.Clear();
        }

        private Task CreateFile()
        {
            return Photo.Create(FileDialog.FileName)
                .Tap(p => this.repository.Add(p))
                .Tap(() => this.repository.SaveChanges())
                .Tap(p => this.PhotosList.Items.Add(new PhotoViewModel(p)));
        }
        
        private Task DeleteSelected()
        {
            var selectedPhoto = PhotosList.SelectedItem as PhotoViewModel;
            if (selectedPhoto == null)
            {
                return Task.CompletedTask;
            }

            return this.repository.GetById(selectedPhoto.Id).ToResult("Photo not found")
                .Tap(a => a.Delete())
                .Tap(() => this.repository.SaveChanges())
                .Tap(() => PhotosList.Items.Remove(selectedPhoto));
        }
        
        private void InitEvents()
        {
            AddPhotoBtn.Click += (sender, e) => FileDialog.ShowDialog();
            FileDialog.FileOk += async (sender, e) => await this.CreateFile();
            PhotosList.SelectedIndexChanged += (sender, e) => this.DeleteBtn.Enabled = PhotosList.SelectedIndex >= 0;
            DeleteBtn.Click += (sender, e) => this.DeleteSelected();
        }

        private async Task LoadList()
        {
            var photos = (await this.repository.GetAll())
                .Select(p => new PhotoViewModel(p));
            this.PhotosList.Items.AddRange(photos.ToArray());
        }

        private sealed class PhotoViewModel
        {
            public PhotoViewModel(Photo photo)
            {
                Id = photo.Id;
                Path = photo.Path;
                Name = photo.Path.Split('\\').Last().Split('.').First();
            }

            public Guid Id { get; }

            public string Name { get; }
            
            public string Path { get; }

            public override string ToString() => $"{Name} ({Path})";
        }
    }
}
