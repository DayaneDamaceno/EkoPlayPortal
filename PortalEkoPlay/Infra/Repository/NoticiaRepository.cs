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
		return await _context.Noticias.ToListAsync();
	}
}

public interface INoticiaRepository
{
	Task<IEnumerable<Noticia>> ObterTodasNoticias();
}