using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Repository;

public class NoticiaRepository: INoticiaRepository
{
	private readonly EkoPlayContext _context;

	public NoticiaRepository(EkoPlayContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Noticia>> ObterTodasNoticias()
	{
		return await _context.Noticias.AsNoTracking().ToListAsync();
	}
	
	public async Task<Noticia> ObterNoticiaPorId(Guid id)
	{
		return _context.Noticias.Find(id);
	}
	
	public async Task<bool> SalvarNoticia(Noticia noticia)
	{
		await _context.AddAsync(noticia);
		var linhasAfetadas = await _context.SaveChangesAsync();
		
		return linhasAfetadas == 1;
	}
	
	public async Task<bool> EditarNoticia(Noticia noticia)
	{
		_context.Noticias.Update(noticia);
		var linhasAfetadas = await _context.SaveChangesAsync();

		return linhasAfetadas == 1;
	}
	
	public async Task<bool> ExcluirNoticia(Noticia noticia)
	{
        _context.Noticias?.Remove(noticia);
		var linhasAfetadas = await _context.SaveChangesAsync();
		
		return linhasAfetadas == 1;
	}
}

public interface INoticiaRepository
{
	Task<IEnumerable<Noticia>> ObterTodasNoticias();
	Task<Noticia> ObterNoticiaPorId(Guid id);
	Task<bool> SalvarNoticia(Noticia noticia);
	Task<bool> EditarNoticia(Noticia noticia);
	Task<bool> ExcluirNoticia(Noticia noticia);
}