namespace TIC18_DOTNET_P004;

public class Advogado:Pessoa{
    string Cna {get; set;}

    public Advogado(string nome, DateTime dataNascimento, string cpf, string cna):base(nome, dataNascimento, cpf){
        Cna = cna;
    }
}
