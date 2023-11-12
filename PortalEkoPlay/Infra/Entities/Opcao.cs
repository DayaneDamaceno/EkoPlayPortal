namespace PortalEkoPlay.Infra.Entities;

public class Opcao
{
	public int Id { get; set; }
	public int IdPergunta { get; set; }
	public string Texto { get; set; }
	public bool Correta { get; set; }
	
	public Pergunta Pergunta { get; set; }
}