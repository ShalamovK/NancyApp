using Nancy.Hosting.Self;
using System;

namespace NancyApp {
    class Program
    {
        static void Main(string[] args)
        {
            //var container = new UnityContainer();
            //// DAL
            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            //// BLL
            //container.RegisterType<IVehicleService, VehicleService>();
            //container.Resolve<IUnitOfWork>();
            //container.Resolve<IVehicleService>();

            HostConfiguration configuration = new HostConfiguration
            {
                UrlReservations = new UrlReservations
                {
                    CreateAutomatically = true
                },
            };
            var host = new NancyHost(configuration, new Uri("http://localhost:1234"));
            host.Start();

            Console.ReadKey();
        }
    }
}
