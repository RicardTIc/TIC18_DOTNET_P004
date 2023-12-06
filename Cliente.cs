namespace TIC18_DOTNET_P004;

public class Cliente:Pessoa{
    string EstadoCivil {get; set;}
    string Profissao {get; set;}

    public Cliente(string nome, DateTime dataNascimento, string cpf, string estadoCivil, string profissao):base(nome, dataNascimento, cpf){
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }

}
