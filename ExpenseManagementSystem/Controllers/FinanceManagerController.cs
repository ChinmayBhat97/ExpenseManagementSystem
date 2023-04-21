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
                //ViewData["stusID"] = new SelectList(_context.ClaimStatuses, "Id", "Id", personalClaim.stusID);
                //ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
                return View(updateClaim);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
           
        }

      
        [HttpPost]
        public async Task<IActionResult> updateClaimApproved(int id,  PersonalClaim personalClaim)
        {
           

            //if (ModelState.IsValid)
            //{
                try
                {
                    _context.Update(personalClaim);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) 
                {
                    return View(ex.Message);
                }
                
                
            
            //ViewData["stusID"] = new SelectList(_context.ClaimStatuses, "Id", "Id", personalClaim.stusID);
            //ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
            
        }

        
    }
}



//// GET: Managers/Create
//public IActionResult Create()
//{
//    ViewData["stusID"] = new SelectList(_context.ClaimStatuses, "Id", "Id");
//    ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id");
//    return View();
//}

//// POST: Managers/Create
//// To protect from overposting attacks, enable the specific properties you want to bind to.
//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("claimID,claimantName,claimantEmailID,DeptID,managerName,managerEmailID,accuntNumber,IFSC,description,billingDate,claimingDate,stusID,ImageName,claimAmount,remarkManager,remarkFinanace")] PersonalClaim personalClaim)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Add(personalClaim);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }
//    ViewData["stusID"] = new SelectList(_context.ClaimStatuses, "Id", "Id", personalClaim.stusID);
//    ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
//    return View(personalClaim);
//}



//// GET: Managers/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null || _context.PersonalClaims == null)
//    {
//        return NotFound();
//    }

//    var personalClaim = await _context.PersonalClaims
//        .Include(p => p.ClaimStatus)
//        .Include(p => p.Department)
//        .FirstOrDefaultAsync(m => m.claimID == id);
//    if (personalClaim == null)
//    {
//        return NotFound();
//    }

//    return View(personalClaim);
//}

//// POST: Managers/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    if (_context.PersonalClaims == null)
//    {
//        return Problem("Entity set 'ApplicationDbContext.PersonalClaims'  is null.");
//    }
//    var personalClaim = await _context.PersonalClaims.FindAsync(id);
//    if (personalClaim != null)
//    {
//        _context.PersonalClaims.Remove(personalClaim);
//    }

//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}

//private bool PersonalClaimExists(int id)
//{
//    return (_context.PersonalClaims?.Any(e => e.claimID == id)).GetValueOrDefault();
//}