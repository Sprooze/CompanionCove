using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanionCove.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
		
	}
}
