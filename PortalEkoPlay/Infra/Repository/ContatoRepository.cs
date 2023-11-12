using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Repository;

public class ContatoRepository : IContatoRepository
{
	private readonly EkoPlayContext _context;

	public ContatoRepository(EkoPlayContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Contato>> ObterTodosContatos()
	{
		return await _context.Contatos.AsNoTracking().ToListAsync();
	}

	public async Task<Contato> ObterContatoPorId(Guid id)
	{
		return _context.Contatos.Find(id);
	}
	
	public async Task<bool> SalvarContato(Contato contato)
	{
		await _context.Contatos.AddAsync(contato);
		var linhasAfetadas = await _context.SaveChangesAsync();
		
		return linhasAfetadas == 1;
	}
}

public interface IContatoRepository
{
	Task<IEnumerable<Contato>> ObterTodosContatos();
	Task<Contato> ObterContatoPorId(Guid id);
	Task<bool> SalvarContato(Contato contato);
}