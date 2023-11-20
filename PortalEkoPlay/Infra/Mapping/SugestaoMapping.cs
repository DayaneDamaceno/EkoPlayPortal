using Microsoft.EntityFrameworkCore;
using PortalEkoPlay.Infra.Entities;

namespace PortalEkoPlay.Infra.Mapping;

public static class SugestaoMapping
{
	public static void Configure(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Sugestao>(entity =>
		{
			entity.ToTable("Sugestoes");
			entity.HasKey(s => s.Id);
			entity.Property(s => s.Texto).IsRequired().HasMaxLength(255);
			entity.Property(s => s.Status).IsRequired();
			entity.Property(s => s.DataSugestao).HasColumnName("data_sugestao").HasDefaultValueSql("CURRENT_TIMESTAMP");
		});
	}
}