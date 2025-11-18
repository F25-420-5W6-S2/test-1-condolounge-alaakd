using CondoLounge.Controllers.Base;
using CondoLounge.Data.Entities;
using CondoLounge.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Controllers
{
  
    [Authorize()]
    public class UserController : BaseController<ApplicationUser>
    {
        private IUnitOfWork _unitOfWork;
        public UserController(ILogger<BaseController<ApplicationUser>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public override ActionResult Index()
        {
            var result = ((IUserRepository)_unitOfWork.GetRepository<IUserRepository<ApplicationUser>>())
                                        .GetAll()
                                        .OrderBy(u => u.BuildingId == buildingId)
                                        .ToList();

            return View(result);
        }
    }
}
