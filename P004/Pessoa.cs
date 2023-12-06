namespace _Pessoa;

// Classe base para Pessoa (Advogado e Cliente podem herdar dessa classe)
public class Pessoa{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }
}

