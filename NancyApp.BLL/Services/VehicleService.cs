using NancyApp.Common;
using NancyApp.Common.Contracts;
using NancyApp.Common.Dtos;
using NancyApp.Common.Entities;
using System;

namespace NancyApp.BLL.Services {
    public class VehicleService : BaseService, IVehicleService {
        public VehicleService(IUnitOfWork unitOfWork)
            : base(unitOfWork) {
        }

        public VehicleDto Get(Guid id) {
            Vehicle vehicle = _unitOfWork.GetGenericRepository<Guid, Vehicle>().GetById(id);
            if (vehicle == null)
                return null;

            return new VehicleDto {
                Color = vehicle.Color,
                Horsepowers = vehicle.Horsepowers,
                Name = vehicle.Name
            };
        }

        public ServiceResponse SaveVehicle(VehicleDto vehicleDto) {
            Vehicle vehicle = new Vehicle {
                Id = Guid.NewGuid(),
                Color = vehicleDto.Color,
                Horsepowers = vehicleDto.Horsepowers,
                Name = vehicleDto.Name
            };

            _unitOfWork.GetGenericRepository<Guid, Vehicle>().Add(vehicle);
            _unitOfWork.Commit();

            return new ServiceResponse {
                IsSuccessful = true,
                Message = "vehicle saved"
            };
        }
    }
}
