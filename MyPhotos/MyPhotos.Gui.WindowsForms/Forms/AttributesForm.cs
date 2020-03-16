using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpFunctionalExtensions;
using MyPhotos.Domain.Interfaces;
using Attribute = MyPhotos.Domain.Attribute;

namespace MyPhotos.Gui.WindowsForms.Forms
{
    public partial class AttributesForm : Form
    {
        private readonly IRepository<Attribute> repository;

        public AttributesForm(IRepository<Attribute> repository)
        {
            this.repository = repository;

            InitializeComponent();
            InitEvents();
        }

        protected override async void OnLoad(EventArgs e)
        {
            await LoadList();
        }

        private Task Save()
        {
            return Attribute.Create(AttributeNameInput.Text, AllowMultipleValuesCheckbox.Checked)
                .Tap(a => this.repository.Add(a))
                .Tap(() => this.repository.SaveChanges())
                .Tap(() => AttributeNameInput.Text = string.Empty)
                .Tap(() => AllowMultipleValuesCheckbox.Checked = false)
                .Tap(a => AttributesList.Items.Add(new AttributeViewModel(a)))
                .OnFailure(e => MessageBox.Show(e));
        }

        private Task DeleteSelected()
        {
            var selectedAttribute = AttributesList.SelectedItem as AttributeViewModel;
            if (selectedAttribute == null)
            {
                return Task.CompletedTask;
            }

            return this.repository.GetById(selectedAttribute.Id).ToResult("Attribute not found")
                .Tap(a => a.Delete())
                .Tap(() => this.repository.SaveChanges())
                .Tap(() => AttributesList.Items.Remove(selectedAttribute));
        }

        private async Task LoadList()
        {
            var attributes = (await this.repository.GetAll())
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
            public AttributeViewModel(Attribute attribute)
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
