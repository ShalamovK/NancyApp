using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;
using NancyApp.Common;
using NancyApp.Common.Contracts;
using NancyApp.Common.Dtos;
using NancyApp.Web.Models;
using NancyApp.Web.Requests;
using Newtonsoft.Json;
using System.Net.Http;

namespace NancyApp.Web.Modules
{
    public class VehicleModule : NancyModule
    {
        private VehicleDto _vehicle;
        private IVehicleService _service;

        public VehicleModule(IVehicleService service)
        {
            _vehicle = new VehicleDto
            {
                Color = "Red",
                Horsepowers = 300,
                Name = "Chevy"
            };
            _service = service;

            Get("/", async (x, ct) =>
            {
                var client = new HttpClient();
                var res = await client.GetAsync("http://nancyfx.org");
                var content = await res.Content.ReadAsStringAsync();

                return (Response)content;
            });

            Get("/car/get/{id}", parameters => {
                VehicleDto vehicle = _service.Get(parameters.id);
                return JsonConvert.SerializeObject(vehicle);
            });
            Get("/car/view/{id}", parameters => {
                VehicleDto vehicle = _service.Get(parameters.id);
                return View["Details.cshtml", vehicle];
            });
            Post("/car/save", x => {
                AddVehicleRequest request = this.Bind<AddVehicleRequest>();
                VehicleModel vehicle = request.Vehicle;

                if (vehicle == null)
                    return HttpStatusCode.BadRequest;

                ModelValidationResult validationResult = this.Validate(vehicle);
                if (!validationResult.IsValid) {
                    return Negotiate.WithModel(validationResult).WithStatusCode(HttpStatusCode.BadRequest);
                }

                VehicleDto vehicleDto = new VehicleDto {
                    Color = vehicle.Color,
                    Horsepowers = vehicle.Horsepowers,
                    Name = vehicle.Name
                };

                ServiceResponse response = _service.SaveVehicle(vehicleDto);
                return JsonConvert.SerializeObject(response);
            });
        }
    }
}
