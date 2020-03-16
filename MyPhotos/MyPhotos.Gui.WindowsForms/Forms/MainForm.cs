using System.Windows.Forms;
using MyPhotos.Gui.WindowsForms.Factory;
using MyPhotos.Gui.WindowsForms.Forms;

namespace MyPhotos.Gui.WindowsForms
{
    public partial class MainForm : Form
    {
        private readonly IComponentFactory componentFactory;

        public MainForm(IComponentFactory componentFactory)
        {
            this.componentFactory = componentFactory;
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            AttributesBtn.Click += (sender, e) => componentFactory.Resolve<AttributesForm>().ShowDialog();
        }
    }
}
