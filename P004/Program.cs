using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        EscritorioAdvocacia escritorio = new EscritorioAdvocacia();

        List<Advogado> advogados = new List<Advogado>
        {
            new Advogado("José", new DateTime(1985, 10, 15), "12345678901", "CNA123"),
            new Advogado("Maria", new DateTime(1990, 5, 20), "98765432101", "CNA456")
        };

        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente("João", new DateTime(1988, 3, 25), "11122333444", EstadoCivil.Solteiro, "Engenheiro"),
            new Cliente("Ana", new DateTime(1995, 8, 10), "55566677788", EstadoCivil.Casado, "Médico")
        };

        // Adicionando advogados e clientes ao escritório
        foreach (var advogado in advogados)
        {
            escritorio.AdicionarAdvogado(advogado);
        }

        foreach (var cliente in clientes)
        {
            escritorio.AdicionarCliente(cliente);
        }

        // Relatório 1: Advogados com idade entre 30 e 40 anos
        Console.WriteLine("Relatório 1: Advogados com idade entre 30 e 40 anos");
        var advogadosPorIdade = escritorio.ObterAdvogadosPorIdade(30, 40);
        ImprimirAdvogados(advogadosPorIdade);

        // Relatório 2: Clientes com idade entre 25 e 35 anos
        Console.WriteLine("\nRelatório 2: Clientes com idade entre 25 e 35 anos");
        var clientesPorIdade = escritorio.ObterClientesPorIdade(25, 35);
        ImprimirClientes(clientesPorIdade);

        // Relatório 3: Clientes solteiros
        Console.WriteLine("\nRelatório 3: Clientes solteiros");
        var clientesSolteiros = escritorio.ObterClientesPorEstadoCivil(EstadoCivil.Solteiro);
        ImprimirClientes(clientesSolteiros);

        // Relatório 4: Clientes em ordem alfabética
        Console.WriteLine("\nRelatório 4: Clientes em ordem alfabética");
        var clientesOrdemAlfabetica = escritorio.ObterClientesOrdemAlfabetica();
        ImprimirClientes(clientesOrdemAlfabetica);

        // Relatório 5: Clientes cuja profissão contenha texto informado pelo usuário
        Console.Write("\nRelatório 5: Informe um texto para buscar por profissão: ");
        string textoProfissao = Console.ReadLine();
        var clientesPorProfissao = escritorio.ObterClientesPorProfissao(textoProfissao);
        ImprimirClientes(clientesPorProfissao);

        // Relatório 6: Advogados e Clientes aniversariantes do mês informado
        Console.Write("\nRelatório 6: Informe o mês para buscar aniversariantes (1 a 12): ");
        if (int.TryParse(Console.ReadLine(), out int mesAniversario))
        {
            var aniversariantes = escritorio.ObterAniversariantesDoMes(mesAniversario);
            ImprimirAniversariantes(aniversariantes);
        }
        else
        {
            Console.WriteLine("Mês inválido.");
        }
    }

    static void ImprimirAdvogados(IEnumerable<Advogado> advogados)
    {
        foreach (var advogado in advogados)
        {
            Console.WriteLine($"Advogado: {advogado.Nome}, CPF: {advogado.CPF}, CNA: {advogado.CNA}");
        }
    }

    static void ImprimirClientes(IEnumerable<Cliente> clientes)
    {
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Cliente: {cliente.Nome}, CPF: {cliente.CPF}, Estado Civil: {cliente.EstadoCivil}, Profissão: {cliente.Profissao}");
        }
    }

    static void ImprimirAniversariantes(IEnumerable<Pessoa> aniversariantes)
    {
        foreach (var pessoa in aniversariantes)
        {
            Console.WriteLine($"Aniversariante: {pessoa.Nome}, CPF: {pessoa.CPF}");
        }
    }
}
