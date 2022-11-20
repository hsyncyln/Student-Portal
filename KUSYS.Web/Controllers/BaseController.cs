using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KUSYS.Web.Controllers
{
	public class BaseController : Controller
	{
  //      protected override void OnActionExecuting(ActionExecutingContext filterContext)
		//{
		//	filterContext.Result = new RedirectResult("/Home/Login?redirectUrl=");
		//	//filterContext.Result = new RedirectResult("/Home/Login?redirectUrl=" + filterContext.HttpContext.Request.Url);

		//	base.OnActionExecuting(filterContext);

		//}
	}
}
