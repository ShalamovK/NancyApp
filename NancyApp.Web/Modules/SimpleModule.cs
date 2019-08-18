using Nancy;

namespace NancyApp.Web.Modules {
    public class SimpleModule : NancyModule {
        public SimpleModule() {
            Get("/returnok", param => {
                return HttpStatusCode.OK;
            });
        }
    }
}