using Nancy;
using Nancy.ModelBinding;
using NancyApp.Common;
using NancyApp.Common.Contracts;
using NancyApp.Common.Dtos;
using NancyApp.IoC;
using Newtonsoft.Json;

namespace NancyApp.Modules
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

            Get("/car/get/{id}", parameters => {
                VehicleDto vehicle = _service.Get(parameters.id);
                return JsonConvert.SerializeObject(vehicle);
            });
            Get("/car/view/{id}", parameters => {
                VehicleDto vehicle = _service.Get(parameters.id);
                return View["Details.cshtml", vehicle];
            });
            Post("/car/save", parameters => {
                VehicleDto vehicle = this.Bind<VehicleDto>();
                ServiceResponse response = _service.SaveVehicle(vehicle);
                return JsonConvert.SerializeObject(response);
            });
        }
    }
}
