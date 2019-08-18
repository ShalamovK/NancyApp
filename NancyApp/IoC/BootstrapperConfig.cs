using Microsoft.Practices.Unity;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Unity;
using Nancy.Configuration;
using Nancy.ViewEngines.Razor;
using NancyApp.AppStart;
using NancyApp.BLL.Services;
using NancyApp.Common.Contracts;
using NancyApp.DAL;

namespace NancyApp.IoC {
    public class BootstrapperConfig : UnityNancyBootstrapper {
        public override INancyEnvironment GetEnvironment() {
            return this.ApplicationContainer.Resolve<INancyEnvironment>();
        }

        protected override void ApplicationStartup(IUnityContainer container, IPipelines pipelines) {
            //base.ApplicationStartup(container, pipelines);

            //container.RegisterType<IRazorConfiguration, RazorConfig>();
        }

        protected override void ConfigureApplicationContainer(IUnityContainer existingContainer) {
        }

        protected override void ConfigureRequestContainer(IUnityContainer container, NancyContext context) {
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
        }

        protected override INancyEnvironmentConfigurator GetEnvironmentConfigurator() {
            return this.ApplicationContainer.Resolve<INancyEnvironmentConfigurator>();
        }

        protected override void RegisterNancyEnvironment(IUnityContainer container, INancyEnvironment environment) {
            container.RegisterInstance(environment);
        }

        protected override void RequestStartup(IUnityContainer container, IPipelines pipelines, NancyContext context) {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }

        protected override IRootPathProvider RootPathProvider {
            get {
                return new RootPathConfig();
            }
        }
    }
}
