namespace AVT5.Solucao;
public interface IPagamento
{
    public string Tipo { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public double Desconto { get; set; }
    public DateTime DataHora { get; set; }

   public void RealizarPagamento(double valor){

   }   
}
