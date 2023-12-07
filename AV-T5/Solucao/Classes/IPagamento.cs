namespace AVT5.Solucao;

public interface IPagamento
{
    TipoPagamento Tipo { get; set; }
    string Descricao { get; set; }
    double Valor { get; set; }
    double Desconto { get; set; }
    DateTime DataHora { get; set; }

    public enum TipoPagamento{
    CartaoCredito,
    Pix,
    DinheiroEmEspecie
    }

    public void RealizarPagamento(double valor){

    }
}

public class CartaoCredito : IPagamento{

    public string Descricao { get; set; }
    public double Valor { get; set; }
    public double Desconto { get; set; } = 5
    public DateTime DataHora { get; set; } 

    public CartaoCredito(){
        
    }
    
    public void RealizarPagamento(string descricao, double valor){
        Descricao = descricao;
        Valor = valor;
        DataHora = DateTime.Now;
        var ValorResultado = valor - (valor * (Desconto / 100.0));
        Console.WriteLine(
            $"Pagamento de {ValorResultado} realizado no cartão de crédito com 5% de desconto!"
        );
   }
}

public class Pix : IPagamento{

    public string Descricao { get; set; }
    public double Valor { get; set; }
    public double Desconto { get; set; } = 20
    public DateTime DataHora { get; set; } 

    public Pix(){
       
    }
    
    public void RealizarPagamento(string descricao, double valor){
        Descricao = descricao;
        Valor = valor;
        DataHora = DateTime.Now;
        var ValorResultado = valor - (valor * (Desconto / 100.0));
        Console.WriteLine(
            $"Pagamento de {ValorResultado} realizado no PIX com 20% de desconto!"
        );
   }
}

public class DinheiroEspecie : IPagamento{

    public string Descricao { get; set; }
    public double ValorBruto { get; set; }
    public double Desconto { get; set; } = 20
    public DateTime DataHora { get; set; }

    public DinheiroEspecie(string descricao, double valor){
        Descricao = descricao;
        Valor = valor;
        DataHora = DateTime.Now;
    }
    
    public void RealizarPagamento(string descricao, double valor){
        Descricao = descricao;
        Valor = valor;
        DataHora = DateTime.Now;
        var ValorResultado = valor - (valor * (Desconto / 100.0));
        Console.WriteLine(
            $"Pagamento de {ValorResultado} realizado com dinheiro em espécie com 20% de desconto!"
        );
   }
}

