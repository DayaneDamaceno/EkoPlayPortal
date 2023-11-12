using PortalEkoPlay.Enum;

namespace PortalEkoPlay.Infra.Entities;

public class Sugestao
{
	public Guid Id { get; set; }
	public string Texto { get; set; }
	public StatusSugestao Status { get; set; }
	public DateTime DataSugestao { get; set; }
}
