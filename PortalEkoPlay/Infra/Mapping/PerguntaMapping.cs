using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Mapping;

public class PerguntaMapping
{
	public static void Configure(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Pergunta>(entity =>
		{
			entity.ToTable("Perguntas");
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Dificuldade).IsRequired().HasMaxLength(255);
			entity.Property(p => p.Texto).IsRequired().HasMaxLength(255);

			entity.HasMany(p => p.Opcoes)
					.WithOne(o => o.Pergunta)
					.HasForeignKey(o => o.IdPergunta);
		});
	}
}