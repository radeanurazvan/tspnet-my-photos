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
                .Tap(r => this.PhotosList.Items.Add(new PhotoViewModel(r.Value.Id, r.Value.Path, r.Value.Title)));
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

        private async Task ChangeTitleForSelected()
        {
            var selectedPhoto = PhotosList.SelectedItem as PhotoViewModel;
            if (selectedPhoto == null)
            {
                return;
            }

            var newTitle = ShowChangeTitleDialog("Change title", $"Change title of {selectedPhoto.Name}");

            var res = new ApiResult();
            await Result.Try(() => res = this.facade.ChangeTitle(selectedPhoto.Id, newTitle))
                .Ensure(r => r.IsSuccess, res.Error)
                .Tap(LoadList)
                .OnFailure(e => MessageBox.Show(e));
        }

        private async Task AddAttributeToSelected()
        {
            var selectedPhoto = PhotosList.SelectedItem as PhotoViewModel;
            if (selectedPhoto == null)
            {
                return;
            }

            var inputs = ShowAddAttributeDialog("Add attribute", $"Add attribute to {selectedPhoto.Name}");
            var res = new ApiResult();
            await Result.Try(() => res = this.facade.AddAttributeValue(selectedPhoto.Id, inputs.Item1, inputs.Item2))
                .Ensure(r => r.IsSuccess, res.Error)
                .Tap(LoadList)
                .OnFailure(e => MessageBox.Show(e));
        }

        private void InitEvents()
        {
            AddPhotoBtn.Click += (sender, e) => FileDialog.ShowDialog();
            FileDialog.FileOk += async (sender, e) => await this.CreateFile();
            PhotosList.SelectedIndexChanged += (sender, e) =>
            {
                this.DeleteBtn.Enabled 
                    = this.AddAttributeBtn.Enabled 
                    = this.ChangeTitleBtn.Enabled
                    = PhotosList.SelectedIndex >= 0;
            };
            DeleteBtn.Click += async (sender, e) => await this.DeleteSelected();
            ChangeTitleBtn.Click += async (sender, e) => await this.ChangeTitleForSelected();
            AddAttributeBtn.Click += async (sender, e) => await this.AddAttributeToSelected();
        }

        private async Task LoadList()
        {
            var photos = (await this.facade.GetPhotosAsync())
                .Select(p => new PhotoViewModel(p));

            this.PhotosList.Items.Clear();
            this.PhotosList.Items.AddRange(photos.ToArray());
        }

        public static string ShowChangeTitleDialog(string text, string caption)
        {
            var prompt = new Form
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label() { Left = 50, Top = 20, Text = text };
            var textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            var confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public (Guid, string) ShowAddAttributeDialog(string text, string caption)
        {
            var prompt = new Form
            {
                Width = 500,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            var textLabel = new Label { Left = 50, Top = 20, Text = text };
            var comboBox = new ComboBox { Left = 50, Top = 50, Width = 400 };

            var attributes = this.facade.GetAttributes()
                .Select(a => new AttributeViewModel { Id = a.Id, Name = a.Name });
            comboBox.Items.AddRange(attributes.ToArray());

            var textBox = new TextBox { Left = 50, Top = 80, Width = 400 };

            var confirmation = new Button { Text = "Ok", Left = 350, Width = 100, Top = 150, DialogResult = DialogResult.OK };
            
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? (((comboBox.SelectedItem as AttributeViewModel)?.Id).GetValueOrDefault(), textBox.Text): (Guid.Empty, "");
        }

        private sealed class PhotoViewModel
        {
            public PhotoViewModel(FileDto photo)
                : this(photo.Id, photo.Path, photo.Title)
            {
            }

            public PhotoViewModel(Guid id, string path, string name)
            {
                Id = id;
                Name = name;
                Path = path;
            }

            public Guid Id { get; }

            public string Name { get; }
            
            public string Path { get; }

            public override string ToString() => $"{Name} ({Path})";
        }

        private sealed class AttributeViewModel
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public override string ToString() => Name;
        }
    }
}
