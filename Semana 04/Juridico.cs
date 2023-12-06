public class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public int ProbabilidadeSucesso { get; set; }
    public List<Documento> Documentos { get; set; }
    public decimal Custos { get; set; }
    public DateTime? Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }
}