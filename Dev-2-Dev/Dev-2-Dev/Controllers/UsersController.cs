using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Dev_2_Dev.Models;
using Dev_2_Dev.ViewModels;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;

namespace Dev_2_Dev.Controllers
{
    public class UsersController : Controller
    {
        private Dev2DevEntities db = new Dev2DevEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.ProjectTo<UserViewModel>().ToList(); // maps the User model to the UserViewModel
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            var userViewModel = Mapper.Map<User,UserViewModel>(user);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Twitter,Linkedin,Facebook,AboutMe")] UserViewModel userViewModel)
            
        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<UserViewModel,User>(userViewModel);
                user.AspNetUserId = HttpContext.User.Identity.GetUserName();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userViewModel);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,Twitter,Linkedin,Facebook,AboutMe")] UserViewModel userViewModel)

            //TODO: Check against changed User ID.

        {
            if (ModelState.IsValid)
            {
                var user = Mapper.Map<UserViewModel, User>(userViewModel);
                user.AspNetUserId = HttpContext.User.Identity.GetUserId();
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.Find(id);
            var userViewModel = Mapper.Map<User, UserViewModel>(user);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
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
