namespace AVT5.Solucao;

public interface IPagamento
{
    TipoPagamento Tipo { get; set; }
    string Descricao { get; set; }
    double ValorBruto { get; set; }
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
    public double ValorBruto { get; set; }
    public double Desconto { get; set; } = 5
    public DateTime DataHora { get; set; } 

    public CartaoCredito(string descricao, double valorBruto){
        Descricao = descricao;
        ValorBruto = valorBruto;
        DataHora = DateTime.Now;
    }
    
    public void RealizarPagamento(double valor){
        Console.WriteLine($"Pagamento de {valor} realizado com cartão de crédito!");
   }
}

public class Pix : IPagamento{

    public string Descricao { get; set; }
    public double ValorBruto { get; set; }
    public double Desconto { get; set; } = 20
    public DateTime DataHora { get; set; } 

    public Pix(string descricao, double valorBruto){
        Descricao = descricao;
        ValorBruto = valorBruto;
        DataHora = DateTime.Now;
    }
    
    public void RealizarPagamento(double valor){
      Console.WriteLine($"Pagamento de {valor} realizado por pix!");
   }
}

public class DinheiroEspecie : IPagamento{

    public string Descricao { get; set; }
    public double ValorBruto { get; set; }
    public double Desconto { get; set; } = 20
    public DateTime DataHora { get; set; }

    public DinheiroEspecie(string descricao, double valorBruto){
        Descricao = descricao;
        ValorBruto = valorBruto;
        DataHora = DateTime.Now;
    }
    
    public void RealizarPagamento(double valor){
      Console.WriteLine($"Pagamento de {valor} realizado com dinheiro em espécie!");
   }
}

