using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Mapping;

public class ContatoMapping
{
	public static void Configure(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Contato>(entity =>
		{
			entity.ToTable("Contatos");

			entity.HasKey(x => x.Id);

			entity.Property(x => x.Id)
					.IsRequired();

			entity.Property(x => x.Nome).IsRequired();
			entity.Property(x => x.Email).IsRequired();
			entity.Property(x => x.Assunto);
			entity.Property(x => x.Mensagem).IsRequired();
			entity.Property(x => x.DataCriacao)
					.IsRequired()
					.HasDefaultValueSql("CURRENT_TIMESTAMP");
		});
	}
}