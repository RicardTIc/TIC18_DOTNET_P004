namespace TIC18_DOTNET_P004;

class Escritorio
{
    private List<Advogado> advogados = new List<Advogado>();
    private List<Cliente> clientes = new List<Cliente>();
    private List<CasoJuridico> casoJuridico = new List<CasoJuridico>();
    private List<CasoJuridico> todosOsCasosJuridicos = new List<CasoJuridico>();
    private List<CasoJuridico> todosOsCasos = new List<CasoJuridico>();
    private List<Cliente> todosOsClientes = new List<Cliente>();
    private List<Advogado> todosOsAdvogados = new List<Advogado>();

    public void AdicionarCasoJuridico(CasoJuridico casojuridico)
    {
        todosOsCasosJuridicos.Add(casojuridico);
        casoJuridico.Add(casojuridico);
    }

    public void AdicionarAdvogado(Advogado advogado)
    {
        todosOsAdvogados.Add(advogado);
        advogados.Add(advogado);
    }

    public void AdicionarCliente(Cliente cliente)
    {
        todosOsClientes.Add(cliente);
        clientes.Add(cliente);
    }

    public List<Advogado> ObterAdvogadosEntreIdades(int idadeMinima, int idadeMaxima)
    {
        DateTime dataAtual = DateTime.Now;
        return advogados.Where(a => (dataAtual.Year - a.DataNascimento.Year) >= idadeMinima
                                  && (dataAtual.Year - a.DataNascimento.Year) <= idadeMaxima).ToList();
    }

    public List<Cliente> ObterClientesEntreIdades(int idadeMinima, int idadeMaxima)
    {
        DateTime dataAtual = DateTime.Now;
        return clientes.Where(c => (dataAtual.Year - c.DataNascimento.Year) >= idadeMinima
                                  && (dataAtual.Year - c.DataNascimento.Year) <= idadeMaxima).ToList();
    }

    public List<Cliente> ObterClientesComEstadoCivil(string estadoCivilDesejado)
    {

        var clientesFiltrados = todosOsClientes
            .Where(cliente => cliente.EstadoCivil.Equals(estadoCivilDesejado, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return clientesFiltrados;

    }

    public List<Cliente> ObterClientesEmOrdemAlfabetica()
    {
        var clientesOrdenados = todosOsClientes.OrderBy(cliente => cliente.Nome).ToList();
        return clientesOrdenados;
    }

    public List<Cliente> ObterClientesPorProfissao(string textoInformado)
    {
        var clientesFiltrados = todosOsClientes
            .Where(cliente => cliente.Profissao.Contains(textoInformado, StringComparison.OrdinalIgnoreCase))
            .ToList();

        return clientesFiltrados;
    }

    public List<Pessoa> ObterAniversariantesDoMes(int mesInformado)
    {
        var aniversariantes = todosOsAdvogados
            .Where(advogado => advogado.DataNascimento.Month == mesInformado)
            .Cast<Pessoa>()
            .Union(todosOsClientes.Where(cliente => cliente.DataNascimento.Month == mesInformado))
            .ToList();

        return aniversariantes;
    }

    public List<CasoJuridico> ObterCasosEmAbertoOrdenadosPorDataDeInicio()
    {
        var casosEmAbertoOrdenados = todosOsCasos
            .Where(caso => caso.Status.Equals("Em aberto", StringComparison.OrdinalIgnoreCase))
            .OrderBy(caso => caso.Abertura)
            .ToList();

        return casosEmAbertoOrdenados;
    }

}

