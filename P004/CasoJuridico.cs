namespace _CasoJuridico;
using _Documento;
using _Advogado;
using _Cliente;


// Classe CasoJuridico
public class CasoJuridico{
    public DateTime Abertura { get; set; }
    public float ProbabilidadeSucesso { get; set; }
    public List<Documento> ListaDocumentos { get; set; }
    public List<float> Custos { get; set; }
    public DateTime Encerramento { get; set; }
    public List<Advogado> Advogados { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }

    // Método para iniciar um caso
    public void IniciarCaso(){
        if (Status == "Em aberto")
            Abertura = DateTime.Now;
    }

    // Método para atualizar um caso
    public void AtualizarCaso(float novaProbabilidade, DateTime novaDataEncerramento, string novoStatus){
        // Atualizar a probabilidade de sucesso
        ProbabilidadeSucesso = novaProbabilidade;

        // Atualizar a data de encerramento se o novo status for "Concluído"
        if (novoStatus == "Concluído"){
            if (novaDataEncerramento > Abertura)
                Encerramento = novaDataEncerramento;
            else
                Console.WriteLine("A data de conclusão deve ser posterior à data de abertura.");
        }
        // Atualizar o status
        Status = novoStatus;
    }

    // Método para associar advogados a um caso
    public void AssociarAdvogado(Advogado advogado){
        if (Advogados == null)
            Advogados = new List<Advogado>();
        Advogados.Add(advogado);
    }

    // Método para calcular o custo total do caso
    public float CalcularCustoTotal(){
        if (Custos == null || Custos.Count == 0)
            return 0;
        return Custos.Sum();
    }
}