using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpFunctionalExtensions;
using MyPhotos.Business.Contracts;

namespace MyPhotos.Gui.WindowsForms.Forms
{
    public partial class PhotosForm : Form
    {
        private readonly IMyPhotosFacade facade;

        public PhotosForm(IMyPhotosFacade facade)
        {
            this.facade = facade;
        
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

        private async Task CreateFile()
        {
            await Result.Try(() => this.facade.CreatePhotoAsync(FileDialog.FileName))
                .Tap(r => this.PhotosList.Items.Add(new PhotoViewModel(r.Value.Id, r.Value.Path)));
        }
        
        private async Task DeleteSelected()
        {
            var selectedPhoto = PhotosList.SelectedItem as PhotoViewModel;
            if (selectedPhoto == null)
            {
                return;
            }

            await Result.Try(() => this.facade.DeletePhotoAsync(selectedPhoto.Id))
                .Tap(() => PhotosList.Items.Remove(PhotosList.SelectedItem));
        }
        
        private void InitEvents()
        {
            AddPhotoBtn.Click += (sender, e) => FileDialog.ShowDialog();
            FileDialog.FileOk += async (sender, e) => await this.CreateFile();
            PhotosList.SelectedIndexChanged += (sender, e) => this.DeleteBtn.Enabled = PhotosList.SelectedIndex >= 0;
            DeleteBtn.Click += async (sender, e) => await this.DeleteSelected();
        }

        private async Task LoadList()
        {
            var photos = (await this.facade.GetPhotosAsync())
                .Select(p => new PhotoViewModel(p));
            this.PhotosList.Items.AddRange(photos.ToArray());
        }

        private sealed class PhotoViewModel
        {
            public PhotoViewModel(FileDto photo)
                : this(photo.Id, photo.Path)
            {
            }

            public PhotoViewModel(Guid id, string path)
            {
                Id = id;
                Name = path.Split('\\').Last().Split('.').First();
                Path = path;
            }

            public Guid Id { get; }

            public string Name { get; }
            
            public string Path { get; }

            public override string ToString() => $"{Name} ({Path})";
        }
    }
}
