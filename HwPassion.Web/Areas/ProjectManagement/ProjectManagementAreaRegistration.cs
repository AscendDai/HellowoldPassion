using System.Web.Mvc;

namespace HwPassion.Web.Areas.ProjectManagement
{
    public class ProjectManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ProjectManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ProjectManagement_default",
                "ProjectManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
