using DemoArchitecture.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DemoArchitecture.Controllers
{
	public class EmailsController : Controller
	{
		private readonly ILogger<EmailsController> _logger;

		public EmailsController(ILogger<EmailsController> logger)
		{
			_logger = logger;
		}

		public IActionResult EmailForm()
		{
			return View();
		}

		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
