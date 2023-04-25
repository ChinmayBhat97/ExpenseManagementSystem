using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseManagementSystem.Data;
using ExpenseManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace ExpenseManagementSystem.Controllers
{
    [Authorize(Roles ="Manager")]
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Initial Page Managers
        public async Task<IActionResult> FrontPage()
        {

            try
            {

                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                string loggedEmail = string.Empty;
                loggedEmail= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                int status = 1;
                var ListofClaims = await _context.PersonalClaims.Where(e => e.managerEmailID==loggedEmail && e.stusID==status).ToListAsync();
              
                return View( ListofClaims);
            }
            catch (Exception Ex)
            {
                return View(Ex.Message);
            }
         
        }

        // Get Claim List applied by Employees
        public async Task<IActionResult> ViewClaim(int? id)
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                var viewClaimApplied = await _context.PersonalClaims.FirstOrDefaultAsync(m => m.claimID == id);


                if (viewClaimApplied == null)
                {

                    return NotFound();
                }

                return View(viewClaimApplied);
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }

           
        }



       // GET: List to Update Claim
        public async Task<IActionResult> updateClaimApplied(int? id)
        {

            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                var editClaim = await _context.PersonalClaims.FindAsync(id);
                if (editClaim == null)
                {
                    return NotFound();
                }

                return View(editClaim);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

       // POST update claims applied
       [HttpPost]
        public IActionResult updateClaimApplied(int id,string remarkManager, int stusID)
        {
         
                try
                {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                //  var updateClaim =  _context.Database.ExecuteSqlRaw("_SPClaimUpdateManagerFor {0},{1},{2}",id,remarkManager,stusID);

                SqlConnection con = new SqlConnection("Server=DESKTOP-0F310TS\\SQLEXPRESS ; Initial Catalog = ExpensesManagementSystem; trusted_connection=true; MultipleActiveResultSets=True");
                SqlCommand com = new SqlCommand("_SPClaimUpdateManagerFor", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id",id);
                com.Parameters.AddWithValue("@remarksManager", remarkManager);
                com.Parameters.AddWithValue("@stusID", stusID);

                con.Open();
                int n = com.ExecuteNonQuery();
                con.Close();



                return RedirectToAction(nameof(FrontPage));
                }
                catch (Exception ex) 
                {
                    return View(ex.Message);
                }
                
        }

        public async Task<IActionResult> ClaimsApproved()
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();


                int status = 2;
                var claimLists = await _context.PersonalClaims.Where(p => p.stusID==status).ToListAsync();
                return View(claimLists);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        public async Task<IActionResult> ClaimsPartialApproved()
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                int status = 4;
                var claimLists = await _context.PersonalClaims.Where(p => p.stusID==status).ToListAsync();
                return View(claimLists);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public async Task<IActionResult> ClaimsRejected()
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                int status = 6;
                var claimLists = await _context.PersonalClaims.Where(p => p.stusID==status).ToListAsync();
                if (claimLists.Count()==0)
                {
                    ViewBag.noRecords= "No records found for rejected claims.";

                }
                return View(claimLists);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}



