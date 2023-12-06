namespace TIC18_DOTNET_P004;

public class Documento{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public string Tipo { get; set; }
    public string Caminho { get; set; }

    public Documento(string nome, string descricao, DateTime dataCriacao, DateTime dataAlteracao, string tipo, string caminho)
    {
        Nome = nome;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        DataAlteracao = dataAlteracao;
        Tipo = tipo;
        Caminho = caminho;
    }
}
