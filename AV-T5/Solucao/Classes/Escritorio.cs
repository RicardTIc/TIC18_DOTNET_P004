namespace AVT5.Solucao;
public class Escritorio
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
    public static void Init()
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
        List<Cliente> clientesPorProfissao = escritorio.ClientePorProfissão("Advogado");
        List<Pessoa> advogadosEClientesMesAniversario = escritorio.AdvogadosEClientesMesAniversario(1);
        List<CasoJuridico> casosAbertosPorData = escritorio.CasosAbertosPorData();
        List<Advogado> advogadosDecrescentePorCasos = escritorio.AdvogadosDecrescentePorCasos();
        List<Documento> topDezDocumentos = escritorio.TopDezDocumentos();

        int opcao;
        bool escolha = true;

        while (escolha == true)
        {
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("1 - Advogados entre 30 e 50 anos");
            Console.WriteLine("2 - Clientes entre 25 e 35 anos");
            Console.WriteLine("3 - Clientes por estado civil");
            Console.WriteLine("4 - Clientes em ordem alfabetica");
            Console.WriteLine("5 - Clientes cuja profissão contenha texto informado pelo usuário");
            Console.WriteLine("6 - Advogados e Clientes aniversariantes do mês informado");
            Console.WriteLine("7 - Casos com o status “Em aberto”, em ordem crescente pela data de início.");
            Console.WriteLine("8 - Advogados em ordem decrescente pela quantidade de casos com status “Concluído”");
            Console.WriteLine("9 - Casos que possuam custo com uma determinada palavra na descrição.");
            Console.WriteLine("10 - Top 10 tipos de documentos mais inseridos nos casos");
            Console.WriteLine("0 - Sair");

            opcao = Convert.ToInt32(Console.ReadLine());
            
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Advogados entre 30 e 50 anos:");
                    foreach (var adv in advogadosEntreIdades)
                    {
                        Console.WriteLine(adv.Nome + " - " + adv.CPF + " - " + adv.CNA);
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
                case 4:
                    Console.WriteLine("Clientes em ordem alfabetica:");
                    foreach (var cli in clientesEmOrdemAlfabetica)
                    {
                        Console.WriteLine(cli.Nome + " - " + cli.CPF + " - " + cli.DataNascimento);
                    }
                    break;
                case 5:
                    Console.WriteLine("Cliente por profissão:");
                    foreach (var cli in clientesPorProfissao)
                    {
                        Console.WriteLine(cli);
                    }
                    break;
                case 6:
                    Console.WriteLine("Pessoas por mês de aniversário:");
                    foreach (var pessoa in escritorio.AdvogadosEClientesMesAniversario(1))
                    {
                        Console.WriteLine(pessoa.Nome + " - " + pessoa.CPF + " - " + pessoa.DataNascimento);
                    }
                    break;
                case 7:
                    Console.WriteLine("Casos abertos por data:");
                    foreach (var _caso in escritorio.CasosAbertosPorData())
                    {
                        Console.WriteLine(_caso);
                    }
                    break;
                case 8:
                    Console.WriteLine("Pessoas por mês de aniversário:");
                    foreach (var pessoa in escritorio.AdvogadosEClientesMesAniversario(1))
                    {
                        Console.WriteLine(pessoa);
                    }
                    break;
                case 9:
                    Console.WriteLine("Custos com palavra na descrição:");
                    foreach (var _caso in escritorio.RelatorioCustosComPalavraNaDescricao("advogado"))
                    {
                        Console.WriteLine(_caso);
                    }
                    break;
                case 10:
                    Console.WriteLine("Top 10 documentos:");
                    foreach (var _caso in escritorio.TopDezDocumentos())
                    {
                        Console.WriteLine(_caso);
                    }
                    break;
                case 0:
                    escolha = false;
                    break;
                default:
                    Console.WriteLine("Opcão inválida. Tente novamente.");
                    break;
            }
        }
    }
}


