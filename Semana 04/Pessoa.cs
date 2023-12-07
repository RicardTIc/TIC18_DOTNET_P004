
using System;

public abstract class Pessoa
{

    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

    protected Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = ValidarCPF(cpf) ? cpf : throw new ArgumentException("CPF inválido");
    }

    private bool ValidarCPF(string cpf)
    {
        return cpf.Length == 11 && cpf.All(char.IsDigit);
    }
}

public enum EstadoCivil
{
    Solteiro,
    Casado
}
