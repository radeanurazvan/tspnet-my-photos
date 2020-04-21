using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace MyPhotos.Gui.WindowsForms
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var services = new ServiceCollection()
                .AddScoped<IMyPhotosFacade>(_ => new MyPhotosFacadeClient())
                .AddPresentation();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetService<MainForm>();
                Application.EnableVisualStyles();
                Application.Run(mainForm);
            }
        }
    }
}