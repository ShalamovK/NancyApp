using Nancy;
using Nancy.ModelBinding;
using NancyApp.Web.Models;
using System.Collections.Generic;

namespace NancyApp.Web.Modules {
    public class SimpleModule : NancyModule {
        public SimpleModule() {
            Post("/sample/vehicles", parameters => {
                VehicleModel model1 = this.Bind();
                var model2 = this.Bind<VehicleModel>();

                VehicleModel instance = new VehicleModel {
                    Color = "Default"
                };
                var model3 = this.BindTo(instance);

                List<VehicleModel> models = new List<VehicleModel> {
                    model1,
                    model2,
                    model3
                };

                return this.Response.AsJson(models);
            });
        }
    }

    public class IgnoreModule : NancyModule {
        public IgnoreModule() {
            Post("/sample/ignore", parameters => {
                VehicleModel model1 = this.Bind<VehicleModel>(x => x.Color);

                return this.Response.AsJson(model1);
            });
        }
    }
}