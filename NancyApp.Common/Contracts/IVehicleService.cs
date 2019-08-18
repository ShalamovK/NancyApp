using NancyApp.Common.Dtos;
using System;

namespace NancyApp.Common.Contracts {
    public interface IVehicleService {
        VehicleDto Get(Guid id);
        ServiceResponse SaveVehicle(VehicleDto vehicle);
    }
}
