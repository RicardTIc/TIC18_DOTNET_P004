namespace TIC18_DOTNET_P004;

public class Cliente:Pessoa{
    public string EstadoCivil {get; set;}
    public string Profissao {get; set;}

    public Cliente(string nome, DateTime dataNascimento, string cpf, string estadoCivil, string profissao):base(nome, dataNascimento, cpf){
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }

}
