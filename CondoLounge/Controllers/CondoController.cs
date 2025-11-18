
using CondoLounge.Controllers.Base;
using CondoLounge.Data;
using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CondoLounge.Controllers
{
    [Authorize()]
    public class CondoController : BaseController<Condo>
    {
        private IUnitOfWork _unitOfWork;
        public CondoController(ILogger<BaseController<Condo>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
