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
    [Authorize(Roles = "Finance Manager")]
    public class FinanceManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FinanceManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Initial Page Managers
        public async Task<IActionResult> InitialPage()
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


                //p.remarkManager==statusManager &&
                //string statusManager = "Approved by Managar";
                string statusFinManager = "Yet to Update";
                var claimLists = await _context.PersonalClaims.Where(p =>  p.remarkFinanace==statusFinManager).ToListAsync();
                return View(claimLists);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

           
        }

        // Get Claim List approved by Manager
        public async Task<IActionResult> ViewClaim(int? id)
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();


                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();

                var viewClaimApplied = await _context.PersonalClaims.FirstOrDefaultAsync(m => m.claimID == id);


                if (viewClaimApplied == null)
                {
                    return NotFound();
                }

                return View(viewClaimApplied);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }

           
        }



        // GET: List to Update Claim approved by manager
        public async Task<IActionResult> updateClaimApproved(int? id)
        {
            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();

                var updateClaim = await _context.PersonalClaims.FindAsync(id);
                if (updateClaim == null)
                {
                    return NotFound();
                }
              
                return View(updateClaim);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
           
        }

      
        [HttpPost]
        public IActionResult updateClaimApproved(int id, string remarkFinanace, int stusID)
        {

            try
            {
                string loggedUser = string.Empty;
                ViewBag.loggedUser= TempData["userEmail-ID"].ToString();
                TempData.Keep();

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();

                //  var updateClaim =  _context.Database.ExecuteSqlRaw("_SPClaimUpdateManagerFor {0},{1},{2}",id,remarkManager,stusID);

                SqlConnection con = new SqlConnection("Server=DESKTOP-0F310TS\\SQLEXPRESS ; Initial Catalog = ExpensesManagementSystem; trusted_connection=true; MultipleActiveResultSets=True");
                SqlCommand com = new SqlCommand("_SPClaimUpdateFinanceManager", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@remarkFinanace", remarkFinanace);
                com.Parameters.AddWithValue("@stusID", stusID);

                con.Open();
                int n = com.ExecuteNonQuery();
                con.Close();

                return RedirectToAction(nameof(InitialPage));
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

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


                // string status = "Approved by Finance Manager";
                int status = 3;
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

                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


                int status = 5;
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


                string userName = string.Empty;
                ViewBag.userName= TempData["userName"].ToString();
                TempData.Keep();


                int status = 7;
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



