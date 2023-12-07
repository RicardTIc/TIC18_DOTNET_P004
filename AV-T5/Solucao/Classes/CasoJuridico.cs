    namespace AVT5.Solucao;
public class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> Documentos { get; set; }
    public List<(float, string)> Custos { get; set; }
    public DateTime? Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente? Cliente { get; set; }
    public string Status { get; set; }

    public CasoJuridico()
    {
        Documentos = new List<Documento>();
        Custos = new List<(float, string)>();
        Advogados = new List<Advogado>();
        Status = "Em aberto";
    }
}
