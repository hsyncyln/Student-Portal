using KUSYS.Core.Helper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.Middleware
{
	public class CustomMiddleware
	{
		private readonly RequestDelegate _next;

		public CustomMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		/// <summary>
		/// Middleware action to be used for logging operations 
		/// </summary>
		/// <param name="httpContext"></param>
		/// <param name="log"></param>
		/// <returns></returns>
		public async Task InvokeAsync(HttpContext httpContext, ILogHelper log)
		{
			log.Write(DateTime.Now.Ticks.ToString() + " " + httpContext.Request.Path);
			await _next(httpContext);
		}
	}
}
