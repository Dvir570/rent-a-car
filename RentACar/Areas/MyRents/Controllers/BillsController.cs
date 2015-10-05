using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using RentACar.Models;
using Microsoft.AspNet.Identity;

namespace RentACar.Areas.MyRents.Controllers
{
    public class BillsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyRents/Bills
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var bills = db.Bills.Include(b => b.Rent).Where(b => b.Rent.UserId == userId);
            return View(await bills.ToListAsync());
        }

        // GET: MyRents/Bills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId<int>();
            Bill bill = await db.Bills.FindAsync(id);

            if (bill == null || bill.Rent.UserId != userId)
            {
                return HttpNotFound();
            }
            return View(bill);
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
