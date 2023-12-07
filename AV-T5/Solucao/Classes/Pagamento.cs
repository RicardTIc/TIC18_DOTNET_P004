public class Pagamento : IPagamento
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double ValorBruto { get; set; }
        public double Desconto { get; set; }
        public DateTime DataHora { get; set; }
    }