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
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections.Generic;
using System.Drawing.Printing;
using cloudscribe.Pagination.Models;


namespace ExpenseManagementSystem.Controllers
{
    [Authorize(Roles = "Finance Manager, Manager, Intern,Engineer")]
    public class PersonalClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IWebHostEnvironment _hostEnvironment { get; }

        public PersonalClaimController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment=hostEnvironment;
        }
        [Authorize(Roles = "Finance Manager, Manager, Intern, Engineer")]
        // Front Page
        public async Task<IActionResult> ClaimPage()
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


                var applicationDbContext = _context.PersonalClaims.Include(p => p.Department);
                return View(await applicationDbContext.ToListAsync());
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
           
        }


        [Authorize(Roles = "Finance Manager, Manager, Intern, Engineer")]
        // Add Personal Claim 
        public IActionResult AddClaim()
        {
            string loggedUser = string.Empty;
            ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
            TempData.Keep();

            string userName = string.Empty;
            ViewBag.userName= TempData["userName"].ToString();
            TempData.Keep();


            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
          
           
        }
        [Authorize(Roles = "Finance Manager, Manager, Intern, Engineer")]
        // POST  Personal Claim 
        [HttpPost]
        public async Task<IActionResult> AddClaim(PersonalClaim personalClaim)
        {
            try
            {

                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


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

        [Authorize(Roles = "Finance Manager, Manager, Intern, Engineer")]
        // GET PersonalClaim list
        public IActionResult ClaimList(int pageNumber=1, int pageSize=5)
        {
            try
            {

               


                string loggedEmail = string.Empty;
                 loggedEmail= TempData["userEmail-ID"].ToString();
                 TempData.Keep();


                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();


                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


                int ExcludeRecords = (pageSize* pageNumber)-pageSize;


                // var ListofClaims = _context.PersonalClaims.Where(e => e.claimantEmailID==loggedEmail).Skip(ExcludeRecords).Take(pageSize).ToList();

                var result = new PagedResult<PersonalClaim>
                    {
                        Data = _context.PersonalClaims.AsNoTracking().Where(e => e.claimantEmailID==loggedEmail).ToList(),
                        TotalItems= _context.PersonalClaims.Count(),
                        PageNumber =pageNumber,
                        PageSize = pageSize
                    };

                return View(result);
                // return View(ListofClaims);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

    }
}

