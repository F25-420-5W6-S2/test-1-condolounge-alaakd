using CondoLounge.Controllers.Base;
using CondoLounge.Data.Entities;
using CondoLounge.Data;
using Microsoft.AspNetCore.Authorization;

namespace CondoLounge.Controllers
{
        [Authorize()]
        public class BuildingController : BaseController<Building>
        {
            private IUnitOfWork _unitOfWork;
            public BuildingController(ILogger<BaseController<Building>> logger, IUnitOfWork unitOfWork) : base(logger)
            {
                _unitOfWork = unitOfWork;
            }
        }
    
}
