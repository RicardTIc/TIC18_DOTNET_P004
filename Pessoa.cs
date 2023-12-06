namespace TIC18_DOTNET_P004;

public class Pessoa{

    string? Nome {get; set;}
    DateTime DataNascimento {get; set;}
    string Cpf {get; set;}

    public Pessoa(string nome, DateTime dataNascimento, string cpf){
        Nome = nome;
        DataNascimento = dataNascimento;
        if (this.ValidarCpf()){
            Cpf = cpf;
        }
        else{
            throw new Exception("CPF inválido");
        }
    }

    bool ValidarCpf(){
        if(this.Cpf.Length != 11){
            return false;
        }
        return true;
    }

}

Pessoa daniel = new Pessoa("Daniel", new DateTime(1988, 10, 10), "12345678901");

Console.WriteLine.print(daniel.Cpf);