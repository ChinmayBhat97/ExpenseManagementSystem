using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ExpenseManagementSystem.Models;


namespace ExpenseManagementSystem.Controllers
{
    public class AccessController : Controller
    {
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
        public async Task <IActionResult> Login(VMLogin vMLogin)
        {
            if (vMLogin.empEmailID =="chinmay29@gamil.com" && vMLogin.passWord=="Chinmay29$")
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,vMLogin.empEmailID),
                    new Claim(ClaimTypes.Role ,"Example Role")
                    //new Claim("OtherProperties","Example Role")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh= true,
                    IsPersistent = vMLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),properties );

                return RedirectToAction("Index", "Home");
            }

            ViewData["validateMessage"]="User not found";

            return View();
        }
    }
}
