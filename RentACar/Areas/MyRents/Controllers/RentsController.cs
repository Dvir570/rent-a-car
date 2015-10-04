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
using Microsoft.AspNet.Identity;

namespace RentACar.Areas.MyRents.Controllers
{
    [Authorize(Roles = "User")]
    public class RentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyRents/Rents
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var rents = db.Rents.Include(r => r.Bill).Include(r => r.Car).Include(r => r.User)
                .Where(r => r.UserId == userId);
            return View(await rents.ToListAsync());
        }

        // GET: MyRents/Rents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId<int>();
            Rent rent = await db.Rents.FindAsync(id);

            if (rent == null || rent.UserId != userId)
            {
                return HttpNotFound();
            }
            return View(rent);
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
