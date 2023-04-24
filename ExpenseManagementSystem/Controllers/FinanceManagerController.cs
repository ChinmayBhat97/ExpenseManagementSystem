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
    [Authorize(Roles = "Finanace Manager")]
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
                var claimLists = _context.PersonalClaims.Include(p => p.ClaimStatus).Include(p => p.Department);
                return View(await claimLists.ToListAsync());
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
        public async Task<IActionResult> updateClaimApproved(int id, string remarkManager, int stusID)
        {

            try
            {
                //  var updateClaim =  _context.Database.ExecuteSqlRaw("_SPClaimUpdateManagerFor {0},{1},{2}",id,remarkManager,stusID);

                SqlConnection con = new SqlConnection("Server=DESKTOP-0F310TS\\SQLEXPRESS ; Initial Catalog = ExpensesManagementSystem; trusted_connection=true; MultipleActiveResultSets=True");
                SqlCommand com = new SqlCommand("_SPClaimUpdateManagerFor", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", id);
                com.Parameters.AddWithValue("@remarksManager", remarkManager);
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


    }
}



