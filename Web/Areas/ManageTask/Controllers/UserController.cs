using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.ManageTask.Controllers
{
    [Area("ManageTask")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(
            IUser user)
        {
            _user = user;
        }
        public IActionResult Index()
        {
            return View(_user.AppUserDto);
        }
    }
}
