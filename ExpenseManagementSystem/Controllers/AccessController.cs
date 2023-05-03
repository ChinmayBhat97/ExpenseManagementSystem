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

            try
            {
                ClaimsPrincipal claimsUser = HttpContext.User;

                if (claimsUser.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

            
        }

        [HttpPost] 
        public async Task <IActionResult> Login(string emailID, string pwd,Employee employee )
        {
            try
            {
                var checkUser = _context.Employees.Any(u => u.empEmailID==emailID);
                var checkPWD = _context.Employees.Any(j => j.passWord==pwd);
                var role = _context.Employees.Where(m => m.empEmailID==emailID).Select(n => n.designation).SingleOrDefault();
                var usrName = _context.Employees.Where(m => m.empEmailID==emailID).Select(n => n.empUserName).SingleOrDefault();
                TempData["tagEmail-ID"] = emailID;
                TempData["userEmail-ID"] = emailID;

                TempData["userName"]=usrName;
                ViewBag.UserRole= role;

                if ((checkUser && checkPWD)==true)
                {
                    List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,emailID),
                    new Claim(ClaimTypes.Role, role)
                   
                };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh= false,
                        IsPersistent =employee.keepLoggedIn=false
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(claimsIdentity), properties);

                    return RedirectToAction("Index", "Home");
                }

                ViewData["validateMessage"]="Invalid credentials, kindly check and try again!.";

                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }


            
        }
    }
}


