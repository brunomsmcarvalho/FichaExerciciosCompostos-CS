using System;
using System.Collections.Generic;

namespace Ficha1._10
{
    class Program
    {
        // Lista para armazenar os livros
        static List<Livro> biblioteca = new List<Livro>();

        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                MostrarMenu();
                opcao = LerOpcao();

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        ListarLivros();
                        break;
                    case 3:
                        Console.WriteLine("\nA sair do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.\n");
                        break;
                }

                if (opcao != 3)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 3);
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║    SISTEMA DE GESTÃO DE LIVROS     ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar Livro");
            Console.WriteLine("2 - Listar Livros");
            Console.WriteLine("3 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
        }

        static int LerOpcao()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return -1;
            }
        }

        static void AdicionarLivro()
        {
            Console.WriteLine("\n--- ADICIONAR NOVO LIVRO ---\n");

            string titulo = "";
            string autor = "";

            // Ler título com validação
            while (string.IsNullOrWhiteSpace(titulo))
            {
                Console.Write("Título do livro: ");
                titulo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(titulo))
                {
                    Console.WriteLine("O título não pode ser vazio! Tente novamente.\n");
                }
            }

            // Ler autor com validação
            while (string.IsNullOrWhiteSpace(autor))
            {
                Console.Write("Autor do livro: ");
                autor = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(autor))
                {
                    Console.WriteLine("O autor não pode ser vazio! Tente novamente.\n");
                }
            }

            // Criar o livro
            try
            {
                Livro novoLivro = new Livro(titulo, autor);
                biblioteca.Add(novoLivro);
                Console.WriteLine("\nLivro adicionado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro ao adicionar livro: {ex.Message}");
            }
        }

        static void ListarLivros()
        {
            Console.WriteLine("\n--- LISTA DE LIVROS ---\n");

            if (biblioteca.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                Console.WriteLine($"Total de livros: {biblioteca.Count}\n");

                for (int i = 0; i < biblioteca.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {biblioteca[i].ToString()}");
                }
            }
        }
    }
}