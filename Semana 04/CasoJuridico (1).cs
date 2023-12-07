public class CasoJuridico
{
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> Documentos { get; set; }
    public List<(float, string)> Custos { get; set; }
    public DateTime Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }
     public void IniciarCaso()
    {
        if (Status == "Em aberto")
        {
            Abertura = DateTime.Now;
            Status = "Em andamento";
            Console.WriteLine("Caso iniciado com sucesso.");
        }
        else
        {
            Console.WriteLine("O caso já está em andamento ou foi concluído/arquivado.");
        }
    }

    public void AtualizarCaso(float probabilidadeSucesso, List<(float, string)> custos)
    {
        if (Status == "Em andamento")
        {
            ProbabilidadeSucesso = probabilidadeSucesso;
            Custos = custos;
            Console.WriteLine("Caso atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine("O caso não está em andamento.");
        }
    }

    public void ConcluirCaso(DateTime dataConclusao)
    {
        if (Status == "Em andamento")
        {
            if (dataConclusao > Abertura)
            {
                Encerramento = dataConclusao;
                Status = "Concluído";
                Console.WriteLine("Caso concluído com sucesso.");
            }
            else
            {
                Console.WriteLine("A data de conclusão deve ser posterior à data de início.");
            }
        }
        else
        {
            Console.WriteLine("O caso não está em andamento.");
        }
    }

    public void ArquivarCaso()
    {
        if (Status == "Concluído")
        {
            Status = "Arquivado";
            Console.WriteLine("Caso arquivado com sucesso.");
        }
        else
        {
            Console.WriteLine("O caso não está concluído.");
        }
    }

    public CasoJuridico()
    {   
        Documentos = new List<Documento>();
        Custos = new List<(float, string)>();
        Advogados = new List<Advogado>();
    }
}
