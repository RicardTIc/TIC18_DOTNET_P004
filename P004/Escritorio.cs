namespace _Escritorio;
using System;
using System.Collections.Generic;
using System.Linq;
using _Pessoa;
using _Cliente;
using _Advogado;
using _CasoJuridico;


public class Escritorio{
    private List<Advogado> advogados;
    private List<Cliente> clientes;
    private List<CasoJuridico> casos;

    // Construtor e inicialização das listas
    public Escritorio(){
        advogados = new List<Advogado>();
        clientes = new List<Cliente>();
        casos = new List<CasoJuridico>();
    }

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
        return advogados.Cast<Pessoa>().Concat(clientes.Cast<Pessoa>()).Where(p => p.DataNascimento.Month == mes).ToList();
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

    // Método auxiliar para calcular a idade
    private int CalculaIdade(DateTime dataNascimento){
        int idade = DateTime.Now.Year - dataNascimento.Year;
        if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day)){
            idade--;
        }
        return idade;
    }
}