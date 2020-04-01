using System;
using System.Net.Mime;
using System.ServiceModel;
using System.ServiceModel.Description;
using Microsoft.Extensions.DependencyInjection;
using MyPhotos.Business;
using MyPhotos.Business.Contracts;
using MyPhotos.Domain;
using MyPhotos.Persistence.EntityFramework;

namespace MyPhotos.Host.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddDomain()
                .AddBusiness()
                .AddInfrastructure();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                System.Console.WriteLine("Lansare server WCF...");
                var host = new ServiceHost(scope.ServiceProvider.GetService<IMyPhotosFacade>(), new Uri("http://localhost:8000/PC"));
                foreach (ServiceEndpoint se in host.Description.Endpoints)
                {
                    System.Console.WriteLine($"A (address): {se.Address} \nB (binding): {se.Binding.Name} \nC(Contract): {se.Contract.Name}\n");
                }

                host.Open();

                System.Console.WriteLine("Server in executie. Se asteapta conexiuni...");
                System.Console.WriteLine("Apasati Enter pentru a opri serverul!");
                System.Console.ReadLine();

                host.Close();
            }
        }
    }
}
