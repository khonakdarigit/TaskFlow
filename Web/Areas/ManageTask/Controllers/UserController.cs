using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Web.Areas.ManageTask.Models;

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

        public IActionResult Profile()
        {
            var model = new UserProfileViewModel();
            model.FirstName = _user.AppUser.FirstName;
            model.LastName = _user.AppUser.LastName;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileAsync(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _user.UpdateAppUser(new ApplicationUserDto() { FirstName = model.FirstName, LastName = model.LastName });
                model.StatusMessage = "Information successfully saved!";
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> UploadProfilePicture(IFormFile profilePicture, string croppedImage)
        {
            try
            {

                if (string.IsNullOrEmpty(croppedImage))
                {
                    throw new ArgumentNullException(nameof(croppedImage), "croppedImage is null");
                }

                var base64Data = croppedImage.Split(',')[1];
                var imageBytes = Convert.FromBase64String(base64Data);

                var fileName = Guid.NewGuid().ToString() + ".jpg";
                var filePath = Path.Combine("wwwroot/img/profiles", fileName);

                await System.IO.File.WriteAllBytesAsync(filePath, imageBytes);

                var picUrl = "/img/profiles/" + fileName;
                await _user.UpdateAppUserPic(picUrl);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
