using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpFunctionalExtensions;
using MyPhotos.Business.Contracts;

namespace MyPhotos.Gui.WindowsForms.Forms
{
    public partial class AttributesForm : Form
    {
        private readonly IMyPhotosFacade facade;

        public AttributesForm(IMyPhotosFacade facade)
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
            this.AttributesList.Items.Clear();
        }

        private async Task Save()
        {
            var dto = new AttributeDto { Name = AttributeNameInput.Text, AllowsMultipleValues = AllowMultipleValuesCheckbox.Checked };

            await Result.Try(() => facade.CreateAttributeAsync(dto))
                .Tap(() => AttributeNameInput.Text = string.Empty)
                .Tap(() => AllowMultipleValuesCheckbox.Checked = false)
                .Tap(() => AttributesList.Items.Add(new AttributeViewModel(dto)))
                .OnFailure(e => MessageBox.Show(e));
        }

        private async Task DeleteSelected()
        {
            var selectedAttribute = AttributesList.SelectedItem as AttributeViewModel;
            if (selectedAttribute == null)
            {
                return;
            }

            await Result.Try(() => this.facade.DeleteAttributeAsync(selectedAttribute.Id))
                .Tap(() => AttributesList.Items.Remove(AttributesList.SelectedItem));
        }

        private async Task LoadList()
        {
            var attributes = (await this.facade.GetAttributesAsync())
                .Select(a => new AttributeViewModel(a));
            AttributesList.Items.AddRange(attributes.ToArray());
        }

        private void InitEvents()
        {
            this.SaveBtn.Click += async (sender, e) => await Save();
            this.AttributesList.SelectedIndexChanged += (sender, e) => DeleteButton.Enabled = this.AttributesList.SelectedIndex >= 0;
            this.DeleteButton.Click += async (sender, e) => await DeleteSelected();
        }

        private sealed class AttributeViewModel
        {
            public AttributeViewModel(AttributeDto attribute)
            {
                Id = attribute.Id;
                Name = attribute.Name;
            }

            public Guid Id { get; set; }

            public string Name { get; set; }

            public override string ToString() => Name;
        }
    }
}
