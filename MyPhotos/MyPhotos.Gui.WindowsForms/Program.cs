using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MyPhotos.Domain;
using MyPhotos.Persistence.EntityFramework;

namespace MyPhotos.Gui.WindowsForms
{
    public static class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection()
                .AddDomain()
                .AddInfrastructure()
                .AddPresentation();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetService<MainForm>();
                Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(mainForm);
            }
        }
    }
}