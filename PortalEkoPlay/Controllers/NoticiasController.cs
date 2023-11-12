using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalEkoPlay.Infra.Entities;
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

	[Route("Index")]
	public async Task<IActionResult> Index()
	{
		var noticias = await _noticiaRepository.ObterTodasNoticias();
		return View(noticias);
	}
	
	[Route("CreateView")]
	public IActionResult CreateView()
	{
		return View();
	}
	
	[Route("EditView/{id:guid}")]
	public async Task<IActionResult> EditView(Guid id)
	{
		var noticia = await _noticiaRepository.ObterNoticiaPorId(id);
		return View(noticia);
	}
	
	[Route("DeleteView/{id:guid}")]
	public async Task<IActionResult> DeleteView(Guid id)
	{
		var noticia = await _noticiaRepository.ObterNoticiaPorId(id);
		return View(noticia);
	}
	
	[HttpPost, Route("Create")]
	public async Task<IActionResult> Create(Noticia noticia)
	{
		var sucesso = await _noticiaRepository.SalvarNoticia(noticia);
		
		return RedirectToAction("Index");
	}
	
	[HttpPost, Route("Edit")]
	public async Task<IActionResult> Edit(Noticia noticia)
	{
		var sucesso = await _noticiaRepository.EditarNoticia(noticia);
		
		return RedirectToAction("Index");
	}
	
	[HttpPost, Route("Delete")]
	public async Task<IActionResult> Delete(Noticia noticia)
	{
		var sucesso = await _noticiaRepository.ExcluirNoticia(noticia);
		
		return RedirectToAction("Index");
	}
	
	[HttpGet("search")]
	public async Task<JsonResult> ObterTodasNoticias()
	{
		var noticias = await _noticiaRepository.ObterTodasNoticias();

		return Json(noticias);
	}
	
	[HttpGet("search/{id:guid}")]
	public async Task<JsonResult> ObterTodasNoticias(Guid id)
	{
		var noticia = await _noticiaRepository.ObterNoticiaPorId(id);

		return Json(noticia);
	}

}