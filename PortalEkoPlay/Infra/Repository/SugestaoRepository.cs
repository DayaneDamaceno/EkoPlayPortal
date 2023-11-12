using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Repository;

public class SugestaoRepository: ISugestaoRepository
{
	private readonly EkoPlayContext _context;

	public SugestaoRepository(EkoPlayContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Sugestao>> ObterTodasSugestoes()
	{
		return await _context.Sugestoes.AsNoTracking().ToListAsync();
	}
	
	public async Task<Sugestao> ObterSugestaoPorId(Guid id)
	{
		return _context.Sugestoes.Find(id);
	}
	
	public async Task<bool> SalvarSugestao(Sugestao sugestao)
	{
		await _context.Sugestoes.AddAsync(sugestao);
		var linhasAfetadas = await _context.SaveChangesAsync();
		
		return linhasAfetadas == 1;
	}
	
	public async Task<bool> EditarSugestao(Sugestao sugestao)
	{
		_context.Sugestoes.Update(sugestao);
		var linhasAfetadas = await _context.SaveChangesAsync();

		return linhasAfetadas == 1;
	}
	
	public async Task<bool> ExcluirSugestao(Sugestao sugestao)
	{
        _context.Sugestoes?.Remove(sugestao);
		var linhasAfetadas = await _context.SaveChangesAsync();
		
		return linhasAfetadas == 1;
	}
}

public interface ISugestaoRepository
{
	Task<IEnumerable<Sugestao>> ObterTodasSugestoes();
	Task<Sugestao> ObterSugestaoPorId(Guid id);
	Task<bool> SalvarSugestao(Sugestao sugestao);
	Task<bool> EditarSugestao(Sugestao sugestao);
	Task<bool> ExcluirSugestao(Sugestao sugestao);
}