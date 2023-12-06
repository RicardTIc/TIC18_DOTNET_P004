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