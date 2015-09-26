using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentACar.Models;

namespace RentACar.Areas.ControlPanel.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ControlPanel/Roles
        public async Task<ActionResult> Index()
        {
            return View(await db.Roles.OrderBy(m => m.Id).ToListAsync());
        }

        // GET: ControlPanel/Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlPanel/Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] MyRole myRole)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(myRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", new { Message = "Created a new role.", MessageType = "Success" });
        }

        // GET: ControlPanel/Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyRole myRole = db.Roles.Find(id);
            if (myRole == null)
            {
                return HttpNotFound();
            }
            return View(myRole);
        }

        // POST: ControlPanel/Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] MyRole myRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { Message = "Role has been successfully changed.", MessageType = "Success" });
            }
            return View(myRole);
        }

        // GET: ControlPanel/Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyRole myRole = db.Roles.Find(id);
            if (myRole == null)
            {
                return HttpNotFound();
            }
            return View(myRole);
        }

        // POST: ControlPanel/Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var role = db.Roles.Find(id);

            if (role.Users.Count > 0)
            {
                return RedirectToAction("Index", new { Message = "Users are assigned to role " + role.Name + ".", MessageType = "Error" });
            }

            MyRole myRole = db.Roles.Find(id);
            db.Roles.Remove(myRole);
            db.SaveChanges();
            
            return RedirectToAction("Index", new { Message = "Role has been successfully deleted.", MessageType = "Success" });
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
