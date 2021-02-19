using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.CoreUI.Models.DataVM;
using Project.DAL.DALModel;

namespace Project.CoreUI.Controllers
{
    public class AccountController : Controller
    {

        IUserManagerSpecial _ums;
        ILoginManager _ilm;

        public AccountController(IUserManagerSpecial ums, ILoginManager ilm)
        {
            _ums = ums;
            _ilm = ilm;
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(AppUserVM avm)
        {


            AppUser newUser = new AppUser { UserName = avm.UserName, Email = avm.Email, PasswordHash = avm.Password };
            if (await _ums.AddUser(newUser)) return RedirectToAction("RegisterSuccess");

            return View(avm);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM item)
        {
            bool result = await _ilm.SignInUser(new AppUser { UserName = item.UserName, PasswordHash = item.Password }, item.RememberMe);

            if (result) return RedirectToAction("CategoryList", "Category");

            return View();
        }
    }
}
