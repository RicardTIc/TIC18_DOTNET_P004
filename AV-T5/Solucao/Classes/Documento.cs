namespace AVT5.Solucao;
public class Documento
{
    public DateTime DataHoraModificacao { get; set; }
    public int Codigo { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }

    public Documento(DateTime _dataHoraModificacao, int _codigo, string _tipo, string _descricao)
    {
        this.DataHoraModificacao = _dataHoraModificacao;
        this.Codigo = _codigo;
        this.Tipo = _tipo;
        this.Descricao = _descricao;
    }
}
