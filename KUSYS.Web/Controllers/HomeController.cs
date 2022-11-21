using KUSYS.Core.Dto;
using KUSYS.Core.Helper;
using KUSYS.Core.Implementations;
using KUSYS.Core.Services;
using KUSYS.Domain.DBContext;
using KUSYS.Domain.Entities;
using KUSYS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace KUSYS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IUserService _userService;
        public HomeController(IUserService userService) => _userService = userService;

		public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult Login()
        {
            return PartialView("_Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Login(UserLoginModel model)
        {
            if (!ModelState.IsValid) {
                return PartialView("_Login",model);
			}

			// TODO: Kullanıcı adı ve şifre kontrolü yapılmalı
            // Geçici olarak kullanıcı adı == password ise true olarak ayarlandı
			var isAuthanticated = model.UserName == model.Password ? true : false; 

			if (isAuthanticated)
            {
				var user = _userService.GetUser(model.UserName);

                if(user != null)
                {
                    GlobalHelper.UserDto = user;

					if (user.UserType == UserType.Admin)
						return RedirectToAction("Home","Admin");
					else
						return RedirectToAction("Home", "User");
				}
			}

			return PartialView("_Login");
        }

    }
}