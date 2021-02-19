using Microsoft.AspNetCore.Identity;
using Project.BLL.ManagerServices.Abstracts;
using Project.DAL.DALModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ManagerServices.Concretes
{
    public class LoginManager : ILoginManager
    {

        SignInManager<AppUser> _smanager;

        public LoginManager(SignInManager<AppUser> smanager)
        {
            _smanager = smanager;
        }
        //await keyword'u sadece asenkron olarak yaratılmıs metotların icinde ve asenkron olarak hizmet yapabilen metot cagrımlarında kullanılabilir...
        public async Task<bool> SignInUser(AppUser item, bool remember)
        {
            SignInResult result=  await _smanager.PasswordSignInAsync(item.UserName,item.PasswordHash,remember,false);
            if (result.Succeeded) return true;
            return false;

        }
    }
}
