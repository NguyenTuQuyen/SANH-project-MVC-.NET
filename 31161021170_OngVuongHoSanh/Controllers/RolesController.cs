using _31161021170_OngVuongHoSanh.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31161021170_OngVuongHoSanh.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext context;
        public RolesController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();            
            return View(Roles);            
        }
        /// <summary>
        /// Create a New role
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        private ApplicationDbContext db = new ApplicationDbContext();
        private SanPhamDBContext sp = new SanPhamDBContext();
        public ActionResult AssignRoles()
        {
            ViewBag.ListUser = db.Users.
             Select(x => new SelectListItem()
             { Text = x.UserName, Value = x.UserName })
             .Distinct()
             .ToList();

            ViewBag.ListRole = db.Roles.
            Select(x => new SelectListItem()
            { Text = x.Name, Value = x.Name })
            //.Where(x=>x.Name!="Admin")
            .Distinct()
            .ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignRoles(AssignRole assignRole)
        {
            if (ModelState.IsValid)
            {
                var UserManager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));
                var user = UserManager.FindByName(assignRole.userName);
                UserManager.AddToRole(user.Id, assignRole.roleName);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListUser = db.Users.
              Select(x => new SelectListItem()
              { Text = x.UserName, Value = x.UserName })
              .Distinct()
              .ToList();

            ViewBag.ListRole = db.Roles.
            Select(x => new SelectListItem()
            { Text = x.Name, Value = x.Name })
            //.Where(x=>x.Name!="Admin")
            .Distinct()
            .ToList();

            return View();
        }
    }
}