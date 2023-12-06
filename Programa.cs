class Program
{
    static void Main()
    {
    // Criar instâncias de Advogado
        Advogado advogado1 = new Advogado { Nome = "Advogado1", DataNascimento = new DateTime(1980, 1, 1), CPF = "123456789", CNA = "123" };
        Advogado advogado2 = new Advogado { Nome = "Advogado2", DataNascimento = new DateTime(1985, 5, 5), CPF = "987654321", CNA = "456" };

        // Criar instâncias de Cliente
        Cliente cliente1 = new Cliente { Nome = "Cliente1", DataNascimento = new DateTime(1990, 5, 10), CPF = "111111111", EstadoCivil = "Solteiro", Profissao = "Engenheiro" };
        Cliente cliente2 = new Cliente { Nome = "Cliente2", DataNascimento = new DateTime(1988, 3, 20), CPF = "222222222", EstadoCivil = "Casado", Profissao = "Médico" };

        // Criar instâncias de Documento
        Documento documento1 = new Documento { DataModificacao = DateTime.Now, Codigo = 1, Tipo = "Contrato", Descricao = "Contrato de Prestação de Serviços" };
        Documento documento2 = new Documento { DataModificacao = DateTime.Now, Codigo = 2, Tipo = "Notificação", Descricao = "Notificação Extrajudicial" };

        // Criar instâncias de CasoJuridico
        CasoJuridico caso1 = new CasoJuridico
        {
            Advogados = new List<Advogado> { advogado1 },
            Cliente = cliente1,
            Abertura = new DateTime(2022, 1, 1),
            Status = "Em aberto",
            Documentos = new List<Documento> { documento1 }
        };

        CasoJuridico caso2 = new CasoJuridico
        {
            Advogados = new List<Advogado> { advogado1, advogado2 },
            Cliente = cliente2,
            Abertura = new DateTime(2022, 2, 1),
            Encerramento = new DateTime(2022, 3, 1),
            Status = "Concluído",
            Documentos = new List<Documento> { documento2 }
        };

        // Criar instâncias de GerenciadorCasoJuridico e Relatorios
        GerenciadorCasoJuridico gerenciador = new GerenciadorCasoJuridico();
        Relatorios relatorios = new Relatorios();

        // Realizar chamadas aos métodos e consultas LINQ para gerar relatórios personalizados

        // Exemplo de chamada para iniciar um caso
        gerenciador.IniciarCaso(caso1);

        // Exemplo de chamada para atualizar um caso
        gerenciador.AtualizarCaso(caso1);

        // Exemplo de chamada para relatório de advogados com idade entre 35 e 40 anos
        var advogadosIdade35a40 = relatorios.AdvogadosEntreIdades(new List<Advogado> { advogado1, advogado2 }, 35, 40);
        
        Console.WriteLine("\nAdvogados com idade entre 35 e 40 anos:");
        foreach (var advogado in advogadosIdade35a40)
        {
            Console.WriteLine($"{advogado.Nome}, {advogado.DataNascimento}");
        }

        // Você pode continuar adicionando mais chamadas conforme necessário para atender aos requisitos do seu sistema.
    }
}
