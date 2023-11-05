using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalEkoPlay.Infra.Repository;
using PortalEkoPlay.Models;

namespace PortalEkoPlay.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly INoticiaRepository _noticiaRepository;

	public HomeController(ILogger<HomeController> logger, INoticiaRepository noticiaRepository)
	{
		_logger = logger;
		_noticiaRepository = noticiaRepository;
	}

	public async Task<IActionResult> Index()
	{
		return View();
	}

}