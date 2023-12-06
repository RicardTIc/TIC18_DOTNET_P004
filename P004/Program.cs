using System;
using System.Collections.Generic;
using System.Linq;
using _Pessoa;
using _Cliente;
using _Advogado;
using _CasoJuridico;
using _Escritorio;
using _Documento;

    class Program{
    static void Main()
    {
        Escritorio escritorio = new Escritorio(); // Inicializa o escritório com instâncias de advogados, clientes, casos, etc.

        int opcao;
        do
        {
            Console.WriteLine("==== Menu ====");
            Console.WriteLine("1. Advogados com idade entre dois valores");
            Console.WriteLine("2. Clientes com idade entre dois valores");
            Console.WriteLine("3. Clientes com estado civil informado pelo usuário");
            Console.WriteLine("4. Clientes em ordem alfabética");
            Console.WriteLine("5. Clientes cuja profissão contenha texto informado pelo usuário");
            Console.WriteLine("6. Advogados e Clientes aniversariantes do mês informado");
            Console.WriteLine("7. Casos com o status 'Em aberto', em ordem crescente pela data de início");
            Console.WriteLine("8. Advogados em ordem decrescente pela quantidade de casos com status 'Concluído'");
            Console.WriteLine("9. Casos que possuam custo com uma determinada palavra na descrição");
            Console.WriteLine("10. Top 10 tipos de documentos mais inseridos nos casos");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        // Chame o método AdvogadosComIdadeEntre e exiba os resultados
                        Console.Write("Digite a idade mínima: ");
                        if (int.TryParse(Console.ReadLine(), out int idadeMinima)){
                            Console.Write("Digite a idade máxima: ");
                            if (int.TryParse(Console.ReadLine(), out int idadeMaxima)){
                                List<Advogado> advogadosIdadeEntre = escritorio.AdvogadosComIdadeEntre(idadeMinima, idadeMaxima);
                                if (advogadosIdadeEntre.Count > 0){
                                    Console.WriteLine("Advogados com idade entre {0} e {1}:", idadeMinima, idadeMaxima);
                                    foreach (Advogado advogado in advogadosIdadeEntre){
                                        Console.WriteLine($"Nome: {advogado.Nome}, Idade: {idadeMaxima - advogado.DataNascimento.Year}");
                                    }
                                }
                                else
                                    Console.WriteLine("Nenhum advogado encontrado com a idade especificada.");
                            }
                            else
                                Console.WriteLine("Idade máxima inválida. Tente novamente.");
                        }
                        else
                            Console.WriteLine("Idade mínima inválida. Tente novamente.");
                        break;
                    case 2:
                        // Chame o método ClientesComIdadeEntre e exiba os resultados
                        Console.WriteLine("Digite a idade mínima: ");
                        if (int.TryParse(Console.ReadLine(), out idadeMinima)){
                            Console.WriteLine("Digite a idade máxima: ");
                            if (int.TryParse(Console.ReadLine(), out int idadeMaxima)){
                                List<Cliente> clientesIdadeEntre = escritorio.ClientesComIdadeEntre(idadeMinima, idadeMaxima);
                                if (clientesIdadeEntre.Count > 0){
                                    Console.WriteLine("Clientes com idade entre {0} e {1}:", idadeMinima, idadeMaxima);
                                    foreach (Cliente cliente in clientesIdadeEntre){
                                        Console.WriteLine($"Nome: {cliente.Nome}, Idade: {idadeMaxima - cliente.DataNascimento.Year}");
                                    }
                                }
                                else
                                    Console.WriteLine("Nenhum cliente encontrado com a idade especificada.");
                            }
                            else
                                Console.WriteLine("Idade máxima inválida. Tente novamente.");
                        }
                        else
                            Console.WriteLine("Idade mínima inválida. Tente novamente.");

                        break;
                    case 3:
                        // Chame o método ClientesComEstadoCivil e exiba os resultados
                        break;
                    case 4:
                        // Chame o método ClientesOrdemAlfabetica e exiba os resultados
                        break;
                    case 5:
                        // Chame o método ClientesComProfissaoContendo e exiba os resultados
                        break;
                    case 6:
                        // Chame o método AniversariantesDoMes e exiba os resultados
                        break;
                    case 7:
                        // Chame o método CasosEmAbertoOrdenadosPorData e exiba os resultados
                        break;
                    case 8:
                        // Chame o método AdvogadosOrdenadosPorCasosConcluidos e exiba os resultados
                        break;
                    case 9:
                        // Chame o método CasosComCustoNaDescricao e exiba os resultados
                        break;
                    case 10:
                        // Chame o método Top10TiposDocumentosMaisInseridos e exiba os resultados
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
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

            Console.WriteLine();
        } while (opcao != 0);
    }

        private static void AdvogadosComIdadeEntre()
        {
            throw new NotImplementedException();
        }
    }
