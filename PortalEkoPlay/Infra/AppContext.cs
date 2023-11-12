using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;
using PortalEkoPlay.Infra.Mapping;

namespace PortalEkoPlay.Infra;

public partial class EkoPlayContext : DbContext
{
	public virtual DbSet<Noticia>? Noticias { get; set; }
	public virtual DbSet<Contato>? Contatos { get; set; }

	public EkoPlayContext() { }

	public EkoPlayContext(DbContextOptions<EkoPlayContext> options)
			: base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		NoticiaMapping.Configure(modelBuilder);
		ContatoMapping.Configure(modelBuilder);

		OnModelCreatingPartial(modelBuilder);
	}
        
	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}