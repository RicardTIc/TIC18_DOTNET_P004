namespace AVT5.Solucao;
class Escritorio
{
    public List<Advogado> Advogados { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<CasoJuridico> CasosJuridicos { get; set; }
    public List<Pessoa> pessoas = new List<Pessoa>();
    public List<Documento> Documentos { get; set; }
    public List<PlanoConsultoria> PlanoConsultoria { get; set; }

    public Escritorio()
    {
        Advogados = new List<Advogado>();
        Clientes = new List<Cliente>();
        CasosJuridicos = new List<CasoJuridico>();
        Documentos = new List<Documento>();
        PlanoConsultoria = new List<PlanoConsultoria>();
    }

    public void IniciarCaso(CasoJuridico caso)
    {
        caso.Abertura = DateTime.Now;
        caso.Status = "Em aberto";
        CasosJuridicos.Add(caso);
    }

    public void AtualizarCaso(CasoJuridico caso)
    {
        if (caso.Status == "Concluído" && caso.Encerramento <= caso.Abertura)
        {
            throw new InvalidOperationException("A data de conclusão deve ser posterior à data de início.");
        }
        else
        {
            caso.Status = "Concluído";
            caso.Encerramento = DateTime.Now;
        }
    }

    // Relatórios
    public List<Advogado> AdvogadosEntreIdades(int idadeMinima, int idadeMaxima)
    {
        return Advogados.Where(a => (DateTime.Now.Year - a.DataNascimento.Year) >= idadeMinima && (DateTime.Now.Year - a.DataNascimento.Year) <= idadeMaxima).ToList();
    }

    public List<Cliente> ClientesEntreIdades(int idadeMinima, int idadeMaxima)
    {
        return Clientes.Where(c => (DateTime.Now.Year - c.DataNascimento.Year) >= idadeMinima && (DateTime.Now.Year - c.DataNascimento.Year) <= idadeMaxima).ToList();
    }

    public List<Cliente> ClientesPorEstadoCivil(string estadoCivil)
    {
        return Clientes.Where(c => c.EstadoCivil.Equals(estadoCivil, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Cliente> ClientesEmOrdemAlfabetica()
    {
        return Clientes.OrderBy(c => c.Nome).ToList();
    }

    public List<Cliente> ClientePorProfissão(string profissao)
    {
        return Clientes.Where(c => c.Profissao.Equals(profissao, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Pessoa> AdvogadosEClientesMesAniversario(int mes)
    {
        pessoas.AddRange(Advogados.Where(a => a.DataNascimento.Month == mes).ToList());
        pessoas.AddRange(Clientes.Where(c => c.DataNascimento.Month == mes).ToList());
        return pessoas;
    }

    public List<CasoJuridico> CasosAbertosPorData()
    {
        return CasosJuridicos.Where(c => c.Status == "Em aberto").ToList();
    }

    public List<Advogado> AdvogadosDecrescentePorCasos()
    {
        return Advogados.OrderByDescending(a => a.CasosJuridicos.Count).ToList();
    }

    public List<CasoJuridico> RelatorioCustosComPalavraNaDescricao(string palavraChave)
    {
        return CasosJuridicos.Where(c => c.Custos.Any(custo => custo.Item2.Contains(palavraChave, StringComparison.OrdinalIgnoreCase))).ToList();
    }

    public List<Documento> TopDezDocumentos()
    {
        return Documentos.OrderByDescending(d => d.Tipo).Take(10).ToList();
    }
}

