using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ExpenseManagementSystem.Models;
using ExpenseManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Controllers
{
    public class AccessController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccessController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;

            if(claimsUser.Identity.IsAuthenticated )
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost] 
        public async Task <IActionResult> Login(string emailID, string pwd,Employee employee )
        {
            var checkUser = _context.Employees.Any(u => u.empEmailID==emailID);
            var checkPWD = _context.Employees.Any(j=>j.passWord==pwd);
            var role = _context.Employees.Where(m => m.empEmailID==emailID).Select(n => n.designation).SingleOrDefault();
            TempData["userEmail-ID"] = emailID;

            if ((checkUser && checkPWD)==true)
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,emailID),
                    new Claim(ClaimTypes.Role, role)
                    //new Claim("OtherProperties","Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh= true,
                    IsPersistent =employee.keepLoggedIn=true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity)/*, properties*/);

                return RedirectToAction("Index", "Home");
            }

            ViewData["validateMessage"]="User not found";

            return View();
        }
    }
}


//var checkUsername = _context.Users.Any(u => u.userName == user.userName);
//if (checkUsername == true)
//{
//    ViewBag.userName=$"User name {user.userName} already in exist.Try with different User name.";
//    return View();
//}