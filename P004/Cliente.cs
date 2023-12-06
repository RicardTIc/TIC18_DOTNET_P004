namespace _Cliente;
using _Pessoa;

// Classe Cliente herda de Pessoa
public class Cliente : Pessoa
{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }
}