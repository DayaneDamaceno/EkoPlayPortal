using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalEkoPlay.Infra.Repository;
using PortalEkoPlay.Models;

namespace PortalEkoPlay.Controllers;

[Route("noticias")]
public class NoticiasController : Controller
{
	private readonly ILogger<NoticiasController> _logger;
	private readonly INoticiaRepository _noticiaRepository;

	public NoticiasController(ILogger<NoticiasController> logger, INoticiaRepository noticiaRepository)
	{
		_logger = logger;
		_noticiaRepository = noticiaRepository;
	}

	public async Task<IActionResult> Index()
	{
		var noticias = await _noticiaRepository.ObterTodasNoticias();
		return View(noticias);
	}
	
	[HttpGet("search")]
	public async Task<JsonResult> ObterTodasNoticias()
	{
		var noticias = await _noticiaRepository.ObterTodasNoticias();

		return Json(noticias);
	}

}