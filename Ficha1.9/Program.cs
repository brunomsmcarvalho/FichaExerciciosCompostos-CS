using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ficha1._9
{
    class Program
    {
        static List<Fabricante> fabricantes = new List<Fabricante>();
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            bool sair = false;

            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       BEM-VINDO AO GESTOR DE PRODUTOS                  ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            while (!sair)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarFabricante();
                        break;

                    case "2":
                        CriarProduto();
                        break;

                    case "3":
                        ListarFabricantes();
                        break;

                    case "4":
                        ListarProdutos();
                        break;

                    case "5":
                        ExibirDetalhesProduto();
                        break;

                    case "0":
                        sair = true;
                        Console.WriteLine("\nObrigado por usar o Gestor de Produtos!");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    MENU PRINCIPAL                      ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1 - Criar Fabricante                                  ║");
            Console.WriteLine("║  2 - Criar Produto                                     ║");
            Console.WriteLine("║  3 - Listar Fabricantes                                ║");
            Console.WriteLine("║  4 - Listar Produtos                                   ║");
            Console.WriteLine("║  5 - Exibir Detalhes de um Produto                     ║");
            Console.WriteLine("║  0 - Sair                                              ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
        }

        static void CriarFabricante()
        {
            Console.Clear();
            Console.WriteLine("\n═══ CRIAR FABRICANTE ═══\n");

            Console.Write("Nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Console.Write("Cidade: ");
            string cidade = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("\nNome é obrigatório!");
                return;
            }

            Fabricante novoFabricante = new Fabricante(nome, endereco, cidade);
            fabricantes.Add(novoFabricante);

            Console.WriteLine($"\nFabricante '{nome}' criado com sucesso!");
        }

        static void CriarProduto()
        {
            Console.Clear();

            if (fabricantes.Count == 0)
            {
                Console.WriteLine("\nErro: Nenhum fabricante cadastrado!");
                Console.WriteLine("Por favor, crie um fabricante primeiro (opção 1).");
                return;
            }

            Console.WriteLine("\n═══ CRIAR PRODUTO ═══\n");

            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            decimal preco;
            string precoInput = Console.ReadLine();

            // Aceita tanto vírgula quanto ponto como separador decimal
            while (!decimal.TryParse(precoInput.Replace('.', ','), NumberStyles.Any, CultureInfo.GetCultureInfo("pt-PT"), out preco))
            {
                Console.Write("Valor inválido! Digite o preço novamente: ");
                precoInput = Console.ReadLine();
            }

            Console.WriteLine("\nFabricantes disponíveis:");
            for (int i = 0; i < fabricantes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {fabricantes[i].Nome}");
            }

            Console.Write("\nEscolha o número do fabricante: ");
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > fabricantes.Count)
            {
                Console.Write("Escolha inválida! Digite novamente: ");
            }

            Fabricante fabricanteSelecionado = fabricantes[escolha - 1];

            if (string.IsNullOrWhiteSpace(nome) || preco <= 0)
            {
                Console.WriteLine("\nDados inválidos! Nome não pode ser vazio e preço deve ser positivo.");
                return;
            }

            Produto novoProduto = new Produto(nome, fabricanteSelecionado, preco);
            produtos.Add(novoProduto);

            Console.WriteLine($"\nProduto '{nome}' criado com sucesso!");
        }

        static void ListarFabricantes()
        {
            Console.Clear();

            if (fabricantes.Count == 0)
            {
                Console.WriteLine("\nNenhum fabricante cadastrado!");
                return;
            }

            Console.WriteLine("\n═══ LISTA DE FABRICANTES ═══\n");
            Console.WriteLine(new string('-', 60));
            for (int i = 0; i < fabricantes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {fabricantes[i]}");
            }
            Console.WriteLine(new string('-', 60));
        }

        static void ListarProdutos()
        {
            Console.Clear();

            if (produtos.Count == 0)
            {
                Console.WriteLine("\nNenhum produto cadastrado!");
                return;
            }

            Console.WriteLine("\n═══ LISTA DE PRODUTOS ═══\n");
            Console.WriteLine(new string('-', 60));
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {produtos[i]}");
            }
            Console.WriteLine(new string('-', 60));
        }

        static void ExibirDetalhesProduto()
        {
            Console.Clear();

            if (produtos.Count == 0)
            {
                Console.WriteLine("\nNenhum produto cadastrado!");
                return;
            }

            Console.WriteLine("\n═══ DETALHES DO PRODUTO ═══\n");
            Console.WriteLine("Produtos disponíveis:");
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {produtos[i].Nome}");
            }

            Console.Write("\nEscolha o número do produto: ");
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > produtos.Count)
            {
                Console.Write("Escolha inválida! Digite novamente: ");
            }

            produtos[escolha - 1].ExibirInformacoes();
        }

    }
}