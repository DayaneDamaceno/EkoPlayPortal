using PortalEkoPlay.Enum;

namespace PortalEkoPlay.Infra.Entities;

public class Pergunta
{
	public int Id { get; set; }
	public Dificuldade Dificuldade { get; set; }
	public string Texto { get; set; }

	public ICollection<Opcao> Opcoes { get; set; }
}