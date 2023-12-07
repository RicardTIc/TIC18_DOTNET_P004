using AVT5.Solucao;

public static class App{
    public static void Init(){
      Main();
    }
    public static void Main(){
        Escritorio escritorio = new Escritorio();
        Cart

        // Inicialização de dados (apenas exemplo)
        Advogado advogado = new Advogado(_nome: "Advogado1", _dataNascimento: new DateTime(1980, 1, 1), _CPF: "12345678901", _CNA: "123456789");
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