namespace DriveEasyLog.Domain;

public class Motorista
{   
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Cnh { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Guid UserId { get; set; } // FK para o Identity
    public User? User { get; set; } // Navegação para o Identity
    public float LatAtual { get; set; }
    public float LngAtual { get; set; }
    public DateTime UltimaAtualizacaoGps { get; set; }
    public Veiculo? Veiculo { get; set; }
    public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    public ICollection<Viagem> Viagens { get; set; } = new List<Viagem>();
}
