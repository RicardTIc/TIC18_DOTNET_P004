using System;
using System.Collections.Generic;
using System.Linq;
using _Pessoa;
using _Cliente;
using _Advogado;

// Classe Documento
public class Documento{
    public DateTime DataModificacao { get; set; }
    public int Codigo { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }
}

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

public class Escritorio{
    private List<Advogado> advogados;
    private List<Cliente> clientes;
    private List<CasoJuridico> casos;

    // Construtor e inicialização das listas

    // Método para obter advogados com idade entre dois valores usando expressão lambda
    public List<Advogado> AdvogadosComIdadeEntre(int idadeMinima, int idadeMaxima){
        return advogados.Where(a => CalculaIdade(a.DataNascimento) >= idadeMinima &&
                                     CalculaIdade(a.DataNascimento) <= idadeMaxima).ToList();
    }

    // Método para obter clientes com idade entre dois valores usando expressão lambda
    public List<Cliente> ClientesComIdadeEntre(int idadeMinima, int idadeMaxima){
        return clientes.Where(c => CalculaIdade(c.DataNascimento) >= idadeMinima &&
                                    CalculaIdade(c.DataNascimento) <= idadeMaxima).ToList();
    }

    // Método para obter clientes com estado civil informado usando LINQ
    public List<Cliente> ClientesComEstadoCivil(string estadoCivil){
        return clientes.Where(c => c.EstadoCivil == estadoCivil).ToList();
    }

    // Método para obter clientes em ordem alfabética usando LINQ
    public List<Cliente> ClientesOrdemAlfabetica(){
        return clientes.OrderBy(c => c.Nome).ToList();
    }

    // Método para obter clientes cuja profissão contenha texto informado usando LINQ
    public List<Cliente> ClientesComProfissaoContendo(string texto){
        return clientes.Where(c => c.Profissao.Contains(texto)).ToList();
    }

    // Método para obter advogados e clientes aniversariantes do mês informado usando expressão lambda
    public List<Pessoa> AniversariantesDoMes(int mes){
        return advogados.Concat(clientes).Where(p => p.DataNascimento.Month == mes).ToList();
    }

    // Adicione métodos semelhantes para os outros relatórios

    // Método auxiliar para calcular a idade
    private int CalculaIdade(DateTime dataNascimento){
        int idade = DateTime.Now.Year - dataNascimento.Year;
        if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
            idade--;                                
        return idade;
    }

    // Método para obter casos com status "Em aberto" em ordem crescente pela data de início usando LINQ
    public List<CasoJuridico> CasosEmAbertoOrdenadosPorData(){
        return casos.Where(c => c.Status == "Em aberto")
                    .OrderBy(c => c.Abertura)
                    .ToList();
    }

    // Método para obter advogados em ordem decrescente pela quantidade de casos com status "Concluído" usando LINQ
    public List<Advogado> AdvogadosOrdenadosPorCasosConcluidos(){
        return advogados.OrderByDescending(a => casos.Count(c => c.Status == "Concluído" && c.Advogados.Contains(a)))
                        .ToList();
    }

    // Adicione métodos semelhantes para os outros relatórios

    // Método para obter casos que possuam custo com uma determinada palavra na descrição usando LINQ
    public List<CasoJuridico> CasosComCustoNaDescricao(string palavra){
        return casos.Where(c => c.Custos != null && c.Custos.Any(custo => custo.ToString().Contains(palavra)))
                    .ToList();
    }

    // Método para obter os top 10 tipos de documentos mais inseridos nos casos usando LINQ
    public List<string> Top10TiposDocumentosMaisInseridos(){
        var tiposDocumentos = casos.SelectMany(c => c.ListaDocumentos.Select(d => d.Tipo));
        var contagemTipos = tiposDocumentos.GroupBy(tipo => tipo)
                                         .OrderByDescending(group => group.Count())
                                         .Take(10)
                                         .Select(group => group.Key)
                                         .ToList();
        return contagemTipos;
    }
}
