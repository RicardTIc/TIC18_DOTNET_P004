namespace AVT5.Solucao;
class Escritorio
{
    public List<Advogado> Advogados { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<CasoJuridico> CasosJuridicos { get; set; }
    public List<Pessoa> pessoas = new List<Pessoa>();
    public List<Documento> Documentos { get; set; }

    public Escritorio()
    {
        Advogados = new List<Advogado>();
        Clientes = new List<Cliente>();
        CasosJuridicos = new List<CasoJuridico>();
        Documentos = new List<Documento>();
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

    public static void Main()
    {
        Escritorio escritorio = new Escritorio();

        // Inicialização de dados (apenas exemplo)
        Advogado advogado = new Advogado(_nome: "Advogado1", _dataNascimento: new DateTime(1980, 1, 1), _CPF: "12345678901", _CNA: "123456789", _casos: new List<CasoJuridico>());
        escritorio.Advogados.Add(advogado);

        Cliente cliente = new Cliente(_nome: "Cliente1", _dataNascimento: new DateTime(1980, 1, 1), _CPF: "12345678901", _estadoCivil: "Solteiro", _profissao: "Advogado");
        escritorio.Clientes.Add(cliente);

        CasoJuridico caso = new CasoJuridico { Cliente = cliente, Advogados = new List<Advogado> { advogado } };
        escritorio.IniciarCaso(caso);

        // Teste dos relatórios (apenas exemplo)
        List<Advogado> advogadosEntreIdades = escritorio.AdvogadosEntreIdades(30, 50);
        List<Cliente> clientesEntreIdades = escritorio.ClientesEntreIdades(25, 35);
        List<Cliente> clientesPorEstadoCivil = escritorio.ClientesPorEstadoCivil("Solteiro");
        List<Cliente> clientesEmOrdemAlfabetica = escritorio.ClientesEmOrdemAlfabetica();

        int opcao = 0;
        while (opcao == 0)
        {
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("1 - Advogados entre 30 e 50 anos");
            Console.WriteLine("2 - Clientes entre 25 e 35 anos");
            Console.WriteLine("3 - Clientes por estado civil");
            Console.WriteLine("4 - Clientes em ordem alfabetica");
            Console.WriteLine("5 - Sair");
            string input = Console.ReadLine() ?? throw new Exception("Entrada inválida");
            if (input != null)
            {
                opcao = int.Parse(input);
            }
            else
            {
                throw new Exception("Entrada inválida");
            }
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Advogados entre 30 e 50 anos:");
                    foreach (var adv in advogadosEntreIdades)
                    {
                        Console.WriteLine(adv.Nome + " - " + adv.CPF + " - " + adv.CNA); ;
                    }
                    break;
                case 2:
                    Console.WriteLine("Clientes entre 25 e 35 anos:");
                    foreach (var cli in clientesEntreIdades)
                    {
                        Console.WriteLine(cli.Nome + " - " + cli.CPF + " - " + cli.DataNascimento);
                    }
                    break;
                case 3:
                    Console.WriteLine("Clientes por estado civil:");
                    foreach (var cli in clientesPorEstadoCivil)
                    {
                        Console.WriteLine(cli.Nome + " - " + cli.CPF + " - " + cli.DataNascimento);
                    }
                    break;
            }
        }
    }

}
