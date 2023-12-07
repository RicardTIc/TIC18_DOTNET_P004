using TIC18_DOTNET_P004;
class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> Documentos { get; set; }
    public List<float> Custos { get; set; }
    public DateTime? Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }

    public CasoJuridico(DateTime dataAbertura, float probabilidadeDeSucesso, List<Documento> documentos, List<float> custos, Cliente cliente, string status)
    {
        Abertura = dataAbertura;
        ProbabilidadeSucesso = probabilidadeDeSucesso;
        Documentos = documentos ?? new List<Documento>();
        Custos = custos ?? new List<float>();
        Encerramento = null;
        Advogados = new List<Advogado>();
        Cliente = cliente;
        Status = status;
    }

    
    public void AdicionarDocumento(Documento documento)
    {
        Documentos.Add(documento);
    }

    public void AdicionarCustos(float custos)
    {
        Custos.Add(custos);
    }
    
    public void AdicionarAdvogado(Advogado advogado)
    {
        Advogados.Add(advogado);
    }
}
