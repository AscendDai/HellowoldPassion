using HwPassion.ApplicaitonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HwPassion.Web.Areas.ProjectManagement.Controllers
{
    /// <summary>
    /// 开发需求列表
    /// </summary>
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

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
