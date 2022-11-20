using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Core.Helper
{
	public interface ILogHelper
	{
		void Write(string message);
	}

	public class LogHelper : ILogHelper
	{

		private readonly ILogger<LogHelper> _logger;

		public LogHelper(ILogger<LogHelper> logger) =>	_logger = logger;

		/// <summary>
		/// Log Write method
		/// </summary>
		/// <param name="message"></param>
		public void Write(string message) => _logger.LogInformation(message);
	}



}
