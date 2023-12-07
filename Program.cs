class Pessoa
{
    private string cpf;
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF 
    { 
        get => cpf; 
        set{

            if (value.Length == 11)
            {
                cpf = $"{value.Substring(0, 3)}.{value.Substring(3, 3)}.{value.Substring(6, 3)}-{value.Substring(9)}";
            }
            else
            {
                cpf = value;
            }
        } 
    }

    public Pessoa(string nome, DateTime dataNascimento, string cpf)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
    }
}

class Advogado : Pessoa
{
    public string CNA { get; set; }

    public Advogado(string nome, DateTime dataNascimento, string cpf, string cna)
        : base(nome, dataNascimento, cpf)
    {
        CNA = cna;
    }
}

class Cliente : Pessoa
{
    public string EstadoCivil { get; set; }
    public string Profissao { get; set; }

    public Cliente(string nome, DateTime dataNascimento, string cpf, string estadoCivil, string profissao)
        : base(nome, dataNascimento, cpf)
    {
        EstadoCivil = estadoCivil;
        Profissao = profissao;
    }
}

class Documento
{
    public DateTime DataModificacao { get; set; }
    public int Codigo { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }

     public Documento(DateTime dataModificacao, int codigo, string tipo, string descricao)
    {
        DataModificacao = dataModificacao;
        Codigo = codigo;
        Tipo = tipo; 
        Descricao = descricao;
    }
}

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

class Program
{
    static void Main()
    {
        Escritorio escritorio = new Escritorio();

        Advogado advogado1 = new Advogado("Advogado1", new DateTime(1990, 1, 1), "12345678901", "CNA1");
        Cliente cliente1 = new Cliente("Cliente1", new DateTime(1985, 5, 5), "98765432109", "Solteiro", "Engenheiro");
        Documento documento1 = new Documento(new DateTime(1985, 5, 5), 111, "relatório", "documental");
        CasoJuridico casoJuridico1 = new CasoJuridico(DateTime.Now.AddMonths(-1), 0.8f, new List<Documento> { documento1 }, new List<float> { 21000 }, cliente1, "Em aberto");

        casoJuridico1.AdicionarAdvogado(advogado1);

        Console.WriteLine($"Custos no Caso Jurídico:");

        

        escritorio.AdicionarCasoJuridico(casoJuridico1);
        escritorio.AdicionarAdvogado(advogado1);
        escritorio.AdicionarCliente(cliente1);

        var relatorioAdvogados = escritorio.ObterAdvogadosEntreIdades(30, 40);
        var relatorioClientes = escritorio.ObterClientesEntreIdades(25, 35);
        var relatorioClientesEstadoCivil = escritorio.ObterClientesComEstadoCivil("Solteiro");
        var relatorioClientesOrdemAlfabetica = escritorio.ObterClientesEmOrdemAlfabetica();
        var relatorioClientePorProfissao = escritorio.ObterClientesPorProfissao("Engenheiro");
        var relatorioAdvogadoClienteMesAniversario = escritorio.ObterAniversariantesDoMes(1);
        var relatorioCasoAbertoEmOrdem = escritorio.ObterCasosEmAbertoOrdenadosPorDataDeInicio();

        Console.WriteLine("Advogados entre 30 e 40 anos:");
            foreach (var adv in relatorioAdvogados)
            {
                Console.WriteLine(adv.Nome);
            }

        Console.WriteLine("Clientes entre 25 e 35 anos:");
            foreach (var cli in relatorioClientes)
            {
                Console.WriteLine(cli.Nome);
            }

        Console.WriteLine("Clientes com o Estado Civil de Solteiro:" );
            foreach (var cliEstCiv in relatorioClientesEstadoCivil)
            {
                Console.WriteLine(cliEstCiv.Nome);
            }

        Console.WriteLine("Clientes em Ordem Alfabética:");
            foreach (var cliOrdAlf in relatorioClientesOrdemAlfabetica)
            {
                Console.WriteLine(cliOrdAlf.Nome);
            }

        Console.WriteLine($"Clientes cuja profissão contenha Engenheiro:");
            foreach (var cliPorProf in relatorioClientePorProfissao)
            {
                Console.WriteLine(cliPorProf.Nome);
            }

        Console.WriteLine($"Aniversariantes do Mês 1:");
            foreach (var pessoa in relatorioAdvogadoClienteMesAniversario)
            {
                Console.WriteLine(pessoa.Nome);
            }
        Console.WriteLine("Casos Em Aberto Ordenados Por Data de Início:");
            foreach (var caso in relatorioCasoAbertoEmOrdem)
            {
                Console.WriteLine($"Data de Abertura: {caso.Abertura:dd/MM/yyyy}, Cliente: {caso.Cliente.Nome}");
            }
    }
}