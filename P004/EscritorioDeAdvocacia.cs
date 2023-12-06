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
    private List<Advogado> advogados = new List<Advogado>();
    private List<Cliente> clientes = new List<Cliente>();

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
}
