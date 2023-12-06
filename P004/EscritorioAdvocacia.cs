using System;
using System.Collections.Generic;
using System.Linq;

public class AdvogadoExistenteException : Exception
{
    public AdvogadoExistenteException(string message) : base(message) { }
}

public class ClienteExistenteException : Exception
{
    public ClienteExistenteException(string message) : base(message) { }
}

public class EscritorioAdvocacia
{
    private EntityManagement<Advogado> advogadoManagement = new EntityManagement<Advogado>();
    private EntityManagement<Cliente> clienteManagement = new EntityManagement<Cliente>();
    private EntityManagement<CasoJuridico> casoJuridicoManagement = new EntityManagement<CasoJuridico>();
    private List<Advogado> advogados = new List<Advogado>();
    private List<Cliente> clientes = new List<Cliente>();

    public void InserirCasoJuridico(CasoJuridico casoJuridico)
    {
        casoJuridicoManagement.AddEntity(casoJuridico);
        Console.WriteLine($"Caso Jurídico aberto para o cliente {casoJuridico.Cliente.Nome} inserido com sucesso.");
    }

    public void RemoverCasoJuridico(CasoJuridico casoJuridico)
    {
        casoJuridicoManagement.RemoveEntity(casoJuridico);
        Console.WriteLine($"Caso Jurídico para o cliente {casoJuridico.Cliente.Nome} removido com sucesso.");
    }



    public void AdicionarAdvogado(Advogado advogado)
    {
        try
        {
            if (advogados.Any(a => a.CPF == advogado.CPF) || advogados.Any(a => a.CNA == advogado.CNA))
            {
                throw new AdvogadoExistenteException("CPF ou CNA já existentes. Advogado não adicionado.");
            }

            advogados.Add(advogado);
            Console.WriteLine($"Advogado {advogado.Nome} adicionado com sucesso.");
        }
        catch (AdvogadoExistenteException ex)
        {
            Console.WriteLine($"Erro ao adicionar advogado: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido ao adicionar advogado: {ex.Message}");
        }
    }


    public void AdicionarCliente(Cliente cliente)
    {
        try
        {
            if (clientes.Any(c => c.CPF == cliente.CPF))
            {
                throw new ClienteExistenteException("CPF já existente. Cliente não adicionado.");
            }

            clientes.Add(cliente);
            Console.WriteLine($"Cliente {cliente.Nome} adicionado com sucesso.");
        }
        catch (ClienteExistenteException ex)
        {
            Console.WriteLine($"Erro ao adicionar cliente: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido ao adicionar cliente: {ex.Message}");
        }
    }

    public IEnumerable<Advogado> ObterAdvogadosPorIdade(int idadeMinima, int idadeMaxima)
    {
        return advogados.Where(a => CalcularIdade(a.DataNascimento) >= idadeMinima && CalcularIdade(a.DataNascimento) <= idadeMaxima);
    }


    public IEnumerable<Cliente> ObterClientesPorIdade(int idadeMinima, int idadeMaxima)
    {
        return clientes.Where(c => CalcularIdade(c.DataNascimento) >= idadeMinima && CalcularIdade(c.DataNascimento) <= idadeMaxima);
    }


    public IEnumerable<Cliente> ObterClientesPorEstadoCivil(EstadoCivil estadoCivil)
    {
        return clientes.Where(c => c.EstadoCivil == estadoCivil);
    }


    public IEnumerable<Cliente> ObterClientesOrdemAlfabetica()
    {
        return clientes.OrderBy(cliente => cliente.Nome);
    }



    public IEnumerable<Cliente> ObterClientesPorProfissao(string textoProfissao)
    {
        return clientes.Where(cliente => cliente.Profissao.Contains(textoProfissao, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Pessoa> ObterAniversariantesDoMes(int mes)
    {
        var aniversariantes = advogados
            .Select(a => (Pessoa)a) // Converte Advogado para Pessoa
            .Concat(clientes)
            .Where(pessoa => pessoa.DataNascimento.Month == mes)
            .OrderBy(pessoa => pessoa.DataNascimento.Day);

        return aniversariantes;
    }




    private int CalcularIdade(DateTime dataNascimento)
    {
        var hoje = DateTime.Now;
        var idade = hoje.Year - dataNascimento.Year;

        if (hoje.Month < dataNascimento.Month || (hoje.Month == dataNascimento.Month && hoje.Day < dataNascimento.Day))
        {
            idade--;
        }

        return idade;
    }

    public IEnumerable<CasoJuridico> ObterCasosEmAberto()
    {
        return casoJuridicoManagement.GetAllEntities().Where(c => c.Status == "Em aberto").OrderBy(c => c.Abertura);
    }
    public IEnumerable<Advogado> ObterAdvogadosPorQuantidadeCasosConcluidos()
    {
        return advogadoManagement.GetAllEntities().OrderByDescending(a => a.CasosJuridicos.Count(c => c.Status == "Concluído"));
    }
    public IEnumerable<CasoJuridico> ObterCasosPorDescricaoCusto(string palavraChave)
    {
        return casoJuridicoManagement.GetAllEntities().Where(c => c.Custos.Any(cost => cost.Item2.Contains(palavraChave, StringComparison.OrdinalIgnoreCase)));
    }
    public IEnumerable<string> ObterTop10TiposDocumentosMaisInseridos()
    {
        var tiposDocumentos = casoJuridicoManagement.GetAllEntities()
            .SelectMany(c => c.Documentos.Select(d => d.Tipo))
            .GroupBy(tipo => tipo)
            .OrderByDescending(group => group.Count())
            .Take(10)
            .Select(group => group.Key);

        return tiposDocumentos;
    }

    public void ListarAdvogadosPorIdade()
    {
        Console.Write("Informe a idade mínima: ");
        if (int.TryParse(Console.ReadLine(), out int idadeMinima))
        {
            Console.Write("Informe a idade máxima: ");
            if (int.TryParse(Console.ReadLine(), out int idadeMaxima))
            {
                var advogadosPorIdade = ObterAdvogadosPorIdade(idadeMinima, idadeMaxima);

                Console.WriteLine("\nAdvogados com idade entre {0} e {1} anos:\n", idadeMinima, idadeMaxima);

                foreach (var advogado in advogadosPorIdade)
                {
                    Console.WriteLine($"Nome: {advogado.Nome}, Idade: {CalcularIdade(advogado.DataNascimento)} anos, CPF: {advogado.CPF}, CNA: {advogado.CNA}");
                }
            }
            else
            {
                Console.WriteLine("Idade máxima inválida.");
            }
        }
        else
        {
            Console.WriteLine("Idade mínima inválida.");
        }
    }
    private void ImprimirAdvogados(IEnumerable<Advogado> advogados)
    {
        Console.WriteLine("\nAdvogados:\n");

        foreach (var advogado in advogados)
        {
            Console.WriteLine($"Advogado: {advogado.Nome}, CPF: {advogado.CPF}, CNA: {advogado.CNA}");
        }
    }

    private void ImprimirClientes(IEnumerable<Cliente> clientes)
    {
        Console.WriteLine("\nClientes:\n");

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Cliente: {cliente.Nome}, CPF: {cliente.CPF}, Estado Civil: {cliente.EstadoCivil}, Profissão: {cliente.Profissao}");
        }
    }

    private void ImprimirAniversariantes(IEnumerable<Pessoa> aniversariantes)
    {
        Console.WriteLine("\nAniversariantes do Mês:\n");

        foreach (var pessoa in aniversariantes)
        {
            Console.WriteLine($"Aniversariante: {pessoa.Nome}, CPF: {pessoa.CPF}");
        }
    }
}
