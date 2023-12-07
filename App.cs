namespace TIC18_DOTNET_P004;

public class App
{
     static void Main(){
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
