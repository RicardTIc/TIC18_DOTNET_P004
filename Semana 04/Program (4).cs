using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        EscritorioAdvocacia escritorio = new EscritorioAdvocacia();

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Listar Advogados por Idade");
            Console.WriteLine("2. Listar Clientes por Idade");
            Console.WriteLine("3. Listar Clientes por Estado Civil");
            Console.WriteLine("4. Listar Clientes em Ordem Alfabética");
            Console.WriteLine("5. Listar Clientes por Profissão");
            Console.WriteLine("6. Listar Aniversariantes do Mês");
            Console.WriteLine("7. Listar Casos em Aberto por Data de Início");
            Console.WriteLine("8. Listar Advogados por Quantidade de Casos Concluídos");
            Console.WriteLine("9. Listar Casos por Palavra-Chave na Descrição do Custo");
            Console.WriteLine("10. Listar Top 10 Tipos de Documentos Mais Inseridos");
            Console.WriteLine("0. Sair");


            Console.Write("Opção: ");
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        escritorio.ListarAdvogadosPorIdade();
                        break;
                    case 2:
                        escritorio.ListarClientesPorIdade();
                        break;
                    case 3:
                        escritorio.ListarClientesPorEstadoCivil();
                        break;
                    case 4:
                        escritorio.ListarClientesOrdemAlfabetica();
                        break;
                    case 5:
                        escritorio.ListarClientesPorProfissao();
                        break;
                    case 6:
                        escritorio.ListarAniversariantesDoMes();
                        break;
                    case 7:
                        escritorio.ListarCasosEmAberto();
                        break;
                    case 8:
                        escritorio.ListarAdvogadosPorQuantidadeCasosConcluidos();
                        break;
                    case 9:
                        
                        break;
                    case 10:
                        escritorio.ListarTop10TiposDocumentosMaisInseridos();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }
    }

}
