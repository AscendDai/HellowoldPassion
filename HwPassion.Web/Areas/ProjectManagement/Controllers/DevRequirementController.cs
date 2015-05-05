using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HwPassion.Model;
using HwPassion.ApplicaitonService;

namespace HwPassion.Web.Areas.ProjectManagement.Controllers
{
    public class DevRequirementController : Controller
    {
        private IDevRequirementService devRequirementService;
        public DevRequirementController(IDevRequirementService devRequirementService)
        {
            this.devRequirementService = devRequirementService;
        }

        // GET: /ProjectManagement/DevRequirement/

        public ActionResult Index()
        {
            var allEntities = devRequirementService.GetAll();
            return View(allEntities);
        }

        private HwPassionDbEntities db = new HwPassionDbEntities();

        // GET: /ProjectManagement/DevRequirement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevRequirement devrequirement = db.DevRequirements.Find(id);
            if (devrequirement == null)
            {
                return HttpNotFound();
            }
            return View(devrequirement);
        }

        // GET: /ProjectManagement/DevRequirement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProjectManagement/DevRequirement/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Require,Description,CreateDateTime,CreateUser,Developor,StartDateTime,CompleteDateTime,Status")] DevRequirement devrequirement)
        {
            if (ModelState.IsValid)
            {
                devrequirement.CreateDateTime = DateTime.Now;
                devrequirement.CreateUser = "admin";
                devrequirement.Status = (int)DevRequirementStatus.Initial;

                devRequirementService.Add(devrequirement);

                return RedirectToAction("Index");
            }

            return View(devrequirement);
        }

        // GET: /ProjectManagement/DevRequirement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevRequirement devrequirement = db.DevRequirements.Find(id);
            if (devrequirement == null)
            {
                return HttpNotFound();
            }
            return View(devrequirement);
        }

        // POST: /ProjectManagement/DevRequirement/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Require,Description,CreateDateTime,CreateUser,Developor,StartDateTime,CompleteDateTime,Status")] DevRequirement devrequirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(devrequirement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devrequirement);
        }

        // GET: /ProjectManagement/DevRequirement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevRequirement devrequirement = db.DevRequirements.Find(id);
            if (devrequirement == null)
            {
                return HttpNotFound();
            }
            return View(devrequirement);
        }

        // POST: /ProjectManagement/DevRequirement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevRequirement devrequirement = db.DevRequirements.Find(id);
            db.DevRequirements.Remove(devrequirement);
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
