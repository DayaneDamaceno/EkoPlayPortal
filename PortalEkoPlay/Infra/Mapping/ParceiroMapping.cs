using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Mapping;

public static class ParceiroMapping
{
	public static void Configure(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Parceiro>(entity =>
		{
			entity.ToTable("Parceiros");
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
			entity.Property(p => p.Email).IsRequired().HasMaxLength(100);
        });
	}
}