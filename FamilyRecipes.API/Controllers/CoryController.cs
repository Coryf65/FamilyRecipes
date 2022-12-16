using FamilyRecipes.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRecipes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoryController : ControllerBase
	{
		private readonly ILogger<CoryController> _logger;

		public CoryController(ILogger<CoryController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetDBInfo")]
		public string Get()
		{
			DataAccess dataAccess = new();
			
			return dataAccess.Test1();
		}
	}
}
