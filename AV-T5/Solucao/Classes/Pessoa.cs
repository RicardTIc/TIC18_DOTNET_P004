namespace AVT5.Solucao;
public class Pessoa
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }

        public Pessoa(string _nome, DateTime _dataNascimento, string _CPF)
        {
            this.Nome = _nome;
            this.DataNascimento = _dataNascimento;
            this.CPF = _CPF;
        }
    }

public class Advogado : Pessoa
{
    public string CNA { get; set; }
    public List<CasoJuridico> CasosJuridicos { get; set; }

    public Advogado(string _nome, DateTime _dataNascimento, string _CPF, string _CNA, List<CasoJuridico> _casos) : base(_nome, _dataNascimento, _CPF)
    {
        this.CNA = _CNA;
        this.CasosJuridicos = _casos;
    }

    public class Cliente : Pessoa
    {
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public PlanoConsultoria PlanoDeConsultoria { get; set; }
        public List<IPagamento> Pagamentos { get; set; }

        public Cliente(string _nome, DateTime _dataNascimento, string _CPF, string _estadoCivil, string _profissao) : base(_nome, _dataNascimento, _CPF)
        {
            this.EstadoCivil = _estadoCivil;
            this.Profissao = _profissao;
            this.Pagamentos = new List<IPagamento>();
        }
    }


