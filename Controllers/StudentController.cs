using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCAPP_TRAVELUPTASK.Models;
using System.Web.UI;
using System.Web.Services.Description;

namespace MVCAPP_TRAVELUPTASK.Controllers
{
    public class StudentController : Controller
    {
        private TESTMVCEntities2 db = new TESTMVCEntities2();

        // GET: Student
        public async Task<ActionResult> Index()
        {
            return View(await db.TBLSTUDENTs.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLSTUDENT tBLSTUDENT = await db.TBLSTUDENTs.FindAsync(id);
            if (tBLSTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(tBLSTUDENT);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "STUD_ID,STUD_NO,STUD_NAME,STUD_DOB,STUD_MOB,STUD_CITY,STUD_COUNTRY")] TBLSTUDENT tBLSTUDENT)
        {
            try
            {

                if (db.TBLSTUDENTs.Any(a => a.STUD_ID.Equals(tBLSTUDENT.STUD_ID)))
                {
                    ModelState.AddModelError(nameof(tBLSTUDENT.STUD_ID), "ID already exists!!");
                    
                }

                if (db.TBLSTUDENTs.Any(a => a.STUD_NO.Equals(tBLSTUDENT.STUD_NO) && a.STUD_ID != tBLSTUDENT.STUD_ID))
                {
                    ModelState.AddModelError(nameof(tBLSTUDENT.STUD_NO), "Student Number already exists!!");
                }          


                if (ModelState.IsValid)
                {
                    db.TBLSTUDENTs.Add(tBLSTUDENT);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Student", "Create"));
            }
          

            return View(tBLSTUDENT);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLSTUDENT tBLSTUDENT = await db.TBLSTUDENTs.FindAsync(id);
            if (tBLSTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(tBLSTUDENT);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "STUD_ID,STUD_NO,STUD_NAME,STUD_DOB,STUD_MOB,STUD_CITY,STUD_COUNTRY")] TBLSTUDENT tBLSTUDENT)
        {
            try
            {
               // if (db.TBLSTUDENTs.Any(a => a.STUD_ID.Equals(tBLSTUDENT.STUD_ID)))
              //  {
                //    ModelState.AddModelError(nameof(tBLSTUDENT.STUD_ID), "ID already exists!!");

               // }

               // if (db.TBLSTUDENTs.Any(a => a.STUD_NO.Equals(tBLSTUDENT.STUD_NO) && a.STUD_ID != tBLSTUDENT.STUD_ID))
               // {
                   // ModelState.AddModelError(nameof(tBLSTUDENT.STUD_NO), "Student Number already exists!!");
              //  }

                if (ModelState.IsValid)
                {
                    db.Entry(tBLSTUDENT).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Student", "Edit"));
            }

            return View(tBLSTUDENT);
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLSTUDENT tBLSTUDENT = await db.TBLSTUDENTs.FindAsync(id);
            if (tBLSTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(tBLSTUDENT);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TBLSTUDENT tBLSTUDENT = await db.TBLSTUDENTs.FindAsync(id);
            db.TBLSTUDENTs.Remove(tBLSTUDENT);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
