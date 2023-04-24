using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseManagementSystem.Data;
using ExpenseManagementSystem.Models;
using System.Text.Unicode;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ExpenseManagementSystem.Controllers
{
    [Authorize(Roles = "Finanace Manager, Manager, Intern")]
    public class PersonalClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IWebHostEnvironment _hostEnvironment { get; }

        public PersonalClaimController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment=hostEnvironment;
        }
        [Authorize(Roles = "Finanace Manager, Manager, Intern")]
        // Front Page
        public async Task<IActionResult> ClaimPage()
        {
            try
            {
              

                var applicationDbContext = _context.PersonalClaims.Include(p => p.Department);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
           
        }


        [Authorize(Roles = "Finanace Manager, Manager, Intern")]
        // Add Personal Claim 
        public IActionResult AddClaim()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
          
           
        }
        [Authorize(Roles = "Finanace Manager, Manager, Intern")]
        // POST  Personal Claim 
        [HttpPost]
        public async Task<IActionResult> AddClaim(PersonalClaim personalClaim)
        {
            try
            {
               
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(personalClaim.ImageFile.FileName);
                string extension = Path.GetExtension(personalClaim.ImageFile.FileName);
                personalClaim.ImageName=fileName = fileName + DateTime.Now.ToString("yymmddssff")+ extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await personalClaim.ImageFile.CopyToAsync(fileStream);
                }

                personalClaim.stusID=1;
                personalClaim.claimingDate=DateTime.Now.Date;
                personalClaim.remarkManager= "Yet to Update";
                personalClaim.remarkFinanace= "Yet to Update";


                _context.Add(personalClaim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ClaimPage));
               
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

          
        }

        [Authorize(Roles = "Finanace Manager, Manager, Intern")]
        // GET PersonalClaim list
        public async Task<IActionResult> ClaimList()
        {
            try
            {
                string loggedEmail = string.Empty;
                 loggedEmail= TempData["userEmail-ID"].ToString();
                TempData.Keep();
              
                var ListofClaims = await _context.PersonalClaims.Where(e =>e.claimantEmailID==loggedEmail).ToListAsync();
               

                return View(ListofClaims);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

    }
}

