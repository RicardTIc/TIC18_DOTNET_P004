class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; }

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

    public CasoJuridico()
    {
        Documentos = new List<Documento>();
        Custos = new List<float>();
        Advogados = new List<Advogado>();
    }
}

class Escritorio
{
    private List<Advogado> advogados = new List<Advogado>();
    private List<Cliente> clientes = new List<Cliente>();
    private List<CasoJuridico> casosJuridicos = new List<CasoJuridico>();

    public void AdicionarAdvogado(Advogado advogado)
    {
        advogados.Add(advogado);
    }

    public void AdicionarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
    }

    // Implementar métodos para adicionar e remover casos jurídicos, documentos, etc.

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

    // Implementar outros métodos conforme necessário para os relatórios
}