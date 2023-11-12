using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalEkoPlay.Infra.Entities;
using PortalEkoPlay.Infra.Repository;
using PortalEkoPlay.Models;

namespace PortalEkoPlay.Controllers;

[Route("contatos")]
public class ContatosController : Controller
{
	private readonly ILogger<ContatosController> _logger;
	private readonly IContatoRepository _contatoRepository;

	public ContatosController(ILogger<ContatosController> logger, IContatoRepository contatoRepository)
	{
		_logger = logger;
		_contatoRepository = contatoRepository;
	}

	[Route("Index")]
	public async Task<IActionResult> Index()
	{
		var contatos = await _contatoRepository.ObterTodosContatos();
		return View(contatos);
	}

	[Route("Detail/{id:guid}")]
	public async Task<IActionResult> Detail(Guid id)
	{
		var contato = await _contatoRepository.ObterContatoPorId(id);
		return View(contato);
	}
    
	[HttpPost]
	public async Task<JsonResult> Create([FromBody]Contato contato)
	{
		var sucesso = await _contatoRepository.SalvarContato(contato);
		
		return Json(new { message = "Contato criado com sucesso"});
	}
    
}