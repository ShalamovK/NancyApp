using FluentValidation;
using NancyApp.Web.Models;

namespace NancyApp.Web.Requests {
    public class AddVehicleRequest {
        public VehicleModel Vehicle { get; set; }
    }

    public class AddVehicleValidator : AbstractValidator<VehicleModel> {
        public AddVehicleValidator() {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Name should be not empty");
            RuleFor(request => request.Color).NotEmpty().WithMessage("Color should be not empty");
            RuleFor(request => request.Horsepowers).GreaterThan(100).WithMessage("There is no place for screw buckets!");
        }
    }
}