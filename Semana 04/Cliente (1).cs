public class Cliente : Pessoa
{
    public EstadoCivil EstadoCivil { get; set; }
    public string Profissao { get; set; }

    public List<CasoJuridico> CasosJuridicos { get; set; }

    public Cliente(string nome, DateTime dataNascimento, string cpf, EstadoCivil estadoCivil, string profissao)
        : base(nome, dataNascimento, cpf)
    {
        EstadoCivil = estadoCivil;
        Profissao = profissao;
        CasosJuridicos = new List<CasoJuridico>();
    }

}
