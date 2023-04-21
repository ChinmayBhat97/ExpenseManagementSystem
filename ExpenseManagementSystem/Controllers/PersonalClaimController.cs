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
       
        // GET: PersonalClaim
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


       
        // GET: PersonalClaim/Create
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
            //ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id");
           
        }

        // POST: PersonalClaim/Create
        [HttpPost]
        public async Task<IActionResult> AddClaim(PersonalClaim personalClaim)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
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

                _context.Add(personalClaim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ClaimPage));
                //}
                ////ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
                //return View(personalClaim);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

          
        }


        // GET: PersonalClaim
        public async Task<IActionResult> ClaimList()
        {
            try
            {
                string loggedEmail = string.Empty;
                 loggedEmail= TempData["userEmail-ID"].ToString();
                TempData.Keep();
                //var ListofClaims = await _context.PersonalClaims.Where(e =>e.claimantEmailID ==str);
                var ListofClaims = await _context.PersonalClaims.Where(e =>e.claimantEmailID==loggedEmail).ToListAsync();
                //var ListofClaims = await _context.PersonalClaims.FromSqlRaw("_SP_forClaimList").ToListAsync();

                return View(ListofClaims);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

    }
}

