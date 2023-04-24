using ExpenseManagementSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpenseManagementSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       
        public IActionResult Index()
        {

            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                return View();
            }
            catch (Exception ex) 
            {
                return View(ex.Message);
            }
           
        }
       

        public async Task <IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Login", "Access");
            }
            catch(Exception ex) 
            {
                return View(ex.Message);
            }


        }

       
    }
}