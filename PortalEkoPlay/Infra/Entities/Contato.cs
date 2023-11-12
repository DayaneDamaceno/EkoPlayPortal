namespace PortalEkoPlay.Infra.Entities;

public class Contato
{
	public Guid Id { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string Assunto { get; set; }
	public string Mensagem { get; set; }
	public DateTime DataCriacao { get; set; }
}
