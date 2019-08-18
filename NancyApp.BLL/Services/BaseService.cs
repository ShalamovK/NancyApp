using NancyApp.Common.Contracts;

namespace NancyApp.BLL.Services {
    public class BaseService : IService {
        protected IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
    }
}
