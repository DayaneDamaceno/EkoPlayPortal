using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Repository;

public class ParceiroRepository : IParceiroRepository
{
	private readonly EkoPlayContext _context;

	public ParceiroRepository(EkoPlayContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Parceiro>> ObterTodasParceiros()
	{
		return await _context.Parceiros.AsNoTracking().ToListAsync();
	}
	
	public async Task<bool> SalvarParceiro(Parceiro parceiro)
	{
		await _context.Parceiros.AddAsync(parceiro);
		var linhasAfetadas = await _context.SaveChangesAsync();
		
		return linhasAfetadas == 1;
	}
}

public interface IParceiroRepository
{
	Task<IEnumerable<Parceiro>> ObterTodasParceiros();
	Task<bool> SalvarParceiro(Parceiro parceiro);
}