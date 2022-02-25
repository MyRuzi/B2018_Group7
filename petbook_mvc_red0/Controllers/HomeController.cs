using petbook_mvc_red0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace petbook_mvc_red0.Controllers
{
    public class HomeController : Controller
    {
        PetbookEntities1 db = new PetbookEntities1();

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User us)
        {
            var obj = db.Users.Where(x => x.user_email.Equals(us.user_email) && x.password.Equals(us.password)).FirstOrDefault();
            {
                return RedirectToAction("Homepage");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult FoundPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FoundPage(Found fp)
        {
            db.Founds.Add(fp);
            db.SaveChanges();
            return RedirectToAction("Homepage");
        }

        [HttpGet]
        public ActionResult LostPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LostPage(Lost lp)
        {
            db.Losts.Add(lp);
            db.SaveChanges();
            return RedirectToAction("Homepage");
        }

        [HttpGet]
        public ActionResult AdoptionPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdoptionPage(Adoption ap)
        {
            db.Adoptions.Add(ap);
            db.SaveChanges();
            return RedirectToAction("Homepage");
        }

        public ActionResult Homepage()
        {
            var fd = found_details();
            var ld = lost_details();
            var ad = adoption_details();
            MultiData data = new MultiData();
            data.adoption_details = ad;
            data.found_details = fd;
            data.lost_details = ld;

            return View(data);
        }

        public List<Found> found_details()
        {
            return db.Founds.ToList();
        }

        public List<Lost> lost_details()
        {
            return db.Losts.ToList();
        }

        public List<Adoption> adoption_details()
        {
            return db.Adoptions.ToList();
        }
    }
    }