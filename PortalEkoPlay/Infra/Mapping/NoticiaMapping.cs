using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Mapping;

internal static class NoticiaMapping
{
	public static void Configure(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Noticia>(entity =>
		{
			entity.ToTable("Noticias");

			entity.HasKey(x => x.Id);

			entity.Property(x => x.Id).IsRequired();
			entity.Property(x => x.Titulo).IsRequired();
			entity.Property(x => x.Conteudo).IsRequired();
		});
	}
}