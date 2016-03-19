using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Api_Practise.Models;
using System.Web.Helpers;
using System.Web.Security;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Api_Practise.Controllers
{
    public class FootballersMVCController : Controller
    {
        private Api_PractiseContext db = new Api_PractiseContext();

        // GET: FootballersMVC
        public ActionResult Index()
        {
            return View(db.Footballers.ToList());
        }

        // GET: FootballersMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footballers footballers = db.Footballers.Find(id);
            if (footballers == null)
            {
                return HttpNotFound();
            }
            return View(footballers);
        }

        // GET: FootballersMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FootballersMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FootballersID,kitnumber,club,position,nationality,name,Password,ConfirmPassword,username")] Footballers footballers)
        {
            if (ModelState.IsValid)
            {
                // before saving to databse 
                // need to hash password
                // add confirm password
                // make username unique
                var HashedPassword = Crypto.HashPassword(footballers.Password);
                footballers.Password = HashedPassword;
                footballers.ConfirmPassword = HashedPassword;
                db.Footballers.Add(footballers);
                
                    db.SaveChanges();
                
                //catch (DbEntityValidationException dbEx)
                //{
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            Trace.TraceInformation("Property: {0} Error: {1}",
                //                                    validationError.PropertyName,
                //                                    validationError.ErrorMessage);
                //        }
                //    }
                //}
                return RedirectToAction("Index");
            }

            return View(footballers);
        }

        // GET: FootballersMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footballers footballers = db.Footballers.Find(id);
            if (footballers == null)
            {
                return HttpNotFound();
            }
            return View(footballers);
        }

        // POST: FootballersMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FootballersID,kitnumber,club,position,nationality,name,Password")] Footballers footballers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(footballers);
        }

        // GET: FootballersMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Footballers footballers = db.Footballers.Find(id);
            if (footballers == null)
            {
                return HttpNotFound();
            }
            return View(footballers);
        }

        // POST: FootballersMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Footballers footballers = db.Footballers.Find(id);
            db.Footballers.Remove(footballers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get
        public ActionResult SignIn()
        {
            return View();
        }

        // post

        [HttpPost]
        public ActionResult SignIn(Footballers footballers)
        {
            try
            {
                Footballers userIndatabase = db.Footballers.Where(u => u.username == footballers.username).FirstOrDefault();
                bool verify = Crypto.VerifyHashedPassword(userIndatabase.Password, footballers.Password);
                if (verify)
                {
                    
                    FormsAuthentication.SetAuthCookie(footballers.username, false);
                    Session["userId"] = userIndatabase.FootballersID;
                    // return View("partialshared");
                    return RedirectToAction("Index", "Home");
                   
                }
              
            }
            catch
            {
                return RedirectToAction("SignIn");
            }

            return RedirectToAction("Index", "Home");
            

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie (not necessary for your current problem but i would recommend you do it anyway)
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);

             FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string UserName)
        {

            var user = Membership.GetUser(UserName);

            return Json(user == null);
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
