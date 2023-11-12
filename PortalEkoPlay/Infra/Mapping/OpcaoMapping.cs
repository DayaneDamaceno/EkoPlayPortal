using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Mapping;

public class OpcaoMapping
{
	public static void Configure(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Opcao>(entity =>
		{
			entity.ToTable("Opcoes");
			entity.HasKey(o => o.Id);
			entity.Property(o => o.Texto).IsRequired().HasMaxLength(255);
			entity.Property(o => o.Correta).IsRequired();

			entity.HasOne(o => o.Pergunta)
					.WithMany(p => p.Opcoes)
					.HasForeignKey(o => o.IdPergunta);
		});
	}
}