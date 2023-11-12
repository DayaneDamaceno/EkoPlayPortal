using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalEkoPlay.Infra.Entities;
using PortalEkoPlay.Infra.Repository;
using PortalEkoPlay.Models;

namespace PortalEkoPlay.Controllers;

[Route("sugestoes")]
public class SugestoesController : Controller
{
	private readonly ILogger<SugestoesController> _logger;
	private readonly ISugestaoRepository _sugestaoRepository;

	public SugestoesController(ILogger<SugestoesController> logger, ISugestaoRepository sugestaoRepository)
	{
		_logger = logger;
		_sugestaoRepository = sugestaoRepository;
	}

	[Route("Index")]
	public async Task<IActionResult> Index()
	{
		var sugestoes = await _sugestaoRepository.ObterTodasSugestoes();
		return View(sugestoes);
	}
	
	[Route("AceitarView")]
	public IActionResult AceitarView()
	{
		return View();
	}
	
	[Route("RecusarView/{id:guid}")]
	public async Task<IActionResult> RecusarView(Guid id)
	{
		var sugestao = await _sugestaoRepository.ObterSugestaoPorId(id);
		return View(sugestao);
	}
    
	
	[HttpPost]
	public async Task<JsonResult> Create([FromBody]Sugestao sugestao)
	{
		var sucesso = await _sugestaoRepository.SalvarSugestao(sugestao);
		
		return Json(new { message = "Sugestão criada com sucesso"});
	}
	
	[HttpPost, Route("aceitar")]
	public async Task<IActionResult> Aceitar(Sugestao sugestao)
	{
		var sucesso = await _sugestaoRepository.EditarSugestao(sugestao);
		
		return RedirectToAction("Index");
	}
	
	[HttpPost, Route("recusar")]
	public async Task<IActionResult> Recusar(Sugestao sugestao)
	{
		var sucesso = await _sugestaoRepository.ExcluirSugestao(sugestao);
		
		return RedirectToAction("Index");
	}
	
	

}