using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseManagementSystem.Data;
using ExpenseManagementSystem.Models;

namespace ExpenseManagementSystem.Controllers
{
    public class PersonalClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalClaim
        public async Task<IActionResult> ClaimPage()
        {
            var applicationDbContext = _context.PersonalClaims.Include(p => p.Department);
            return View(await applicationDbContext.ToListAsync());
        }

       

        // GET: PersonalClaim/Create
        public IActionResult AddClaim()
        {
            //ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id");
            return View();
        }

        // POST: PersonalClaim/Create
        
        [HttpPost]
        public async Task<IActionResult> AddClaim( PersonalClaim personalClaim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalClaim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
            return View(personalClaim);
        }

      
    }
}

//public async Task<IActionResult> Create([Bind("claimID,claimantName,claimantEmailID,DeptID,managerName,managerEmailID,accuntNumber,IFSC,description,billingDate,claimingDate,ImageFile")]

//// GET: PersonalClaim/Details/5
//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null || _context.PersonalClaims == null)
//    {
//        return NotFound();
//    }

//    var personalClaim = await _context.PersonalClaims
//        .Include(p => p.Department)
//        .FirstOrDefaultAsync(m => m.claimID == id);
//    if (personalClaim == null)
//    {
//        return NotFound();
//    }

//    return View(personalClaim);
//}


//// GET: PersonalClaim/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null || _context.PersonalClaims == null)
//    {
//        return NotFound();
//    }

//    var personalClaim = await _context.PersonalClaims.FindAsync(id);
//    if (personalClaim == null)
//    {
//        return NotFound();
//    }
//    ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
//    return View(personalClaim);
//}

//// POST: PersonalClaim/Edit/5
//// To protect from overposting attacks, enable the specific properties you want to bind to.
//// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("claimID,claimantName,claimantEmailID,DeptID,managerName,managerEmailID,accuntNumber,IFSC,description,billingDate,claimingDate,ImageFile")] PersonalClaim personalClaim)
//{
//    if (id != personalClaim.claimID)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            _context.Update(personalClaim);
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!PersonalClaimExists(personalClaim.claimID))
//            {
//                return NotFound();
//            }
//            else
//            {
//                throw;
//            }
//        }
//        return RedirectToAction(nameof(Index));
//    }
//    ViewData["DeptID"] = new SelectList(_context.Departments, "Id", "Id", personalClaim.DeptID);
//    return View(personalClaim);
//}

//// GET: PersonalClaim/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null || _context.PersonalClaims == null)
//    {
//        return NotFound();
//    }

//    var personalClaim = await _context.PersonalClaims
//        .Include(p => p.Department)
//        .FirstOrDefaultAsync(m => m.claimID == id);
//    if (personalClaim == null)
//    {
//        return NotFound();
//    }

//    return View(personalClaim);
//}

//// POST: PersonalClaim/Delete/5
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