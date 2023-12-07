namespace TIC18_DOTNET_P004;

public class Pessoa{

    public string? Nome {get; set;}
    public DateTime DataNascimento {get; set;}
    public string Cpf {get; set;}

    public Pessoa(string nome, DateTime dataNascimento, string cpf){
        Nome = nome;
        DataNascimento = dataNascimento;
        if (ValidarCpf(cpf)){
            Cpf = cpf;
        }
        else{
            throw new Exception("CPF inválido");
        }
    }

    public bool ValidarCpf(string? cpf){
        return cpf?.Length == 11;
    }

}
