public interface IPagamento
    {
        string Tipo { get; set; }
        string Descricao { get; set; }
        double ValorBruto { get; set; }
        double Desconto { get; set; }
        DateTime DataHora { get; set; }
    }