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

                string loggedEmail = string.Empty;
                loggedEmail= TempData["userEmail-ID"].ToString();
                TempData.Keep();
                var ListofClaims = await _context.PersonalClaims.Where(e => e.managerEmailID==loggedEmail).ToListAsync();
              
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

        
    }
}



