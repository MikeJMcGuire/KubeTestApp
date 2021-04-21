using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeTestApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase
	{
		private readonly ILogger<TestController> _logger;

		public TestController(ILogger<TestController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		[Route("[action]")]
		public ActionResult HealthCheck()
		{
			return new ObjectResult(string.Format("OK ({0})", DateTime.Now.Second));
		}
	}
}
