using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyApp.BLL.Services;
using NancyApp.Common.Contracts;
using NancyApp.DAL;

namespace NancyApp.Web.IoC {
    public class BootstrapperConfig : DefaultNancyBootstrapper {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines) {
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<IVehicleService, VehicleService>();
        }
    }
}