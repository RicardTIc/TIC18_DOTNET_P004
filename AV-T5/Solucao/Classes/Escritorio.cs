namespace AVT5.Solucao;
class Escritorio
{
    public List<Advogado> Advogados { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<CasoJuridico> CasosJuridicos { get; set; }

    public Escritorio()
    {
        Advogados = new List<Advogado>();
        Clientes = new List<Cliente>();
        CasosJuridicos = new List<CasoJuridico>();
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

    

}
