using Microsoft.AspNetCore.Mvc;
using PortalEkoPlay.Infra.Entities;
using PortalEkoPlay.Infra.Repository;

namespace PortalEkoPlay.Controllers;

[Route("parceiros")]
public class ParceirosController : Controller
{
	private readonly ILogger<ParceirosController> _logger;
	private readonly IParceiroRepository _parceiroRepository;

	public ParceirosController(ILogger<ParceirosController> logger, IParceiroRepository parceiroRepository)
	{
		_logger = logger;
		_parceiroRepository = parceiroRepository;
	}

	[Route("Index")]
	public async Task<IActionResult> Index()
	{
		var parceiros = await _parceiroRepository.ObterTodasParceiros();
		return View(parceiros);
	}
	
	
	[HttpPost]
	public async Task<JsonResult> Create([FromBody]Parceiro parceiro)
	{
		var sucesso = await _parceiroRepository.SalvarParceiro(parceiro);
		
		return Json(new { message = "Parceiro criado com sucesso"});
	}
	
	[HttpGet("search")]
	public async Task<JsonResult> GetAll()
	{
		var parceiros = await _parceiroRepository.ObterTodasParceiros();
		return Json(parceiros);
	}
}