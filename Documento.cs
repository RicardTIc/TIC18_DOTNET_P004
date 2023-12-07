class Documento
{
    public DateTime DataModificacao { get; set; }
    public int Codigo { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }

     public Documento(DateTime dataModificacao, int codigo, string tipo, string descricao)
    {
        DataModificacao = dataModificacao;
        Codigo = codigo;
        Tipo = tipo; 
        Descricao = descricao;
    }
}
