namespace TIC18_DOTNET_P004;

public class CasoJuridico{
    public Cliente Cliente {get; set;}
    public Advogado Advogado {get; set;}
    public string Descricao {get; set;}
    public DateTime DataAbertura {get; set;}
    public DateTime DataEncerramento {get; set;}
    public string Situacao {get; set;}

    public CasoJuridico(Cliente cliente, Advogado advogado, string descricao, DateTime dataAbertura, DateTime dataEncerramento, string situacao){
        Cliente = cliente;
        Advogado = advogado;
        Descricao = descricao;
        DataAbertura = dataAbertura;
        DataEncerramento = dataEncerramento;
        Situacao = situacao;
    }
    
}   
