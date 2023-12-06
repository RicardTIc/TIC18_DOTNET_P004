public string CNA { get; set; }


    public List<CasoJuridico> CasosJuridicos { get; set; }

    public Advogado(string nome, DateTime dataNascimento, string cpf, string cna)
        : base(nome, dataNascimento, cpf)
    {
        CNA = cna;
        CasosJuridicos = new List<CasoJuridico>();
    }