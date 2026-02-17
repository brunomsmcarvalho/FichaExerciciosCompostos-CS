using System;

namespace Ficha1._13
{
    public class Menu
    {
        private Biblioteca biblioteca = new Biblioteca();

        // ─── PONTO DE ENTRADA DO PROGRAMA ────────────────────────────
        public void Iniciar()
        {
            int opcao;

            do
            {
                MostrarMenu();
                opcao = LerOpcao();

                switch (opcao)
                {
                    case 1:
                        MenuAdicionarLivro();
                        break;
                    case 2:
                        MenuRemoverLivro();
                        break;
                    case 3:
                        MenuEmprestarLivro();
                        break;
                    case 4:
                        MenuDevolverLivro();
                        break;
                    case 5:
                        MenuListarLivros();
                        break;
                    case 0:
                        Console.WriteLine("\nEncerrando o sistema da biblioteca...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Escolha entre 0 e 5.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        // ─── MENU PRINCIPAL ───────────────────────────────────────────
        private void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║        SISTEMA DE GESTÃO DE BIBLIOTECA       ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine($"║  Total de livros: {biblioteca.TotalLivros(),3}                        ║");
            Console.WriteLine($"║  Disponíveis    : {biblioteca.LivrosDisponiveis(),3}                        ║");
            Console.WriteLine($"║  Emprestados    : {biblioteca.LivrosEmprestados(),3}                        ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine("║  1 - Adicionar Livro                         ║");
            Console.WriteLine("║  2 - Remover Livro                           ║");
            Console.WriteLine("║  3 - Emprestar Livro                         ║");
            Console.WriteLine("║  4 - Devolver Livro                          ║");
            Console.WriteLine("║  5 - Listar Todos os Livros                  ║");
            Console.WriteLine("║  0 - Sair                                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
        }

        // ─── ADICIONAR LIVRO ──────────────────────────────────────────
        private void MenuAdicionarLivro()
        {
            Console.WriteLine("\n─── ADICIONAR LIVRO ────────────────────────────\n");

            string titulo = LerStringObrigatoria("Título do livro");
            string autor = LerStringObrigatoria("Autor do livro");

            int ano = 0;
            while (ano < 1000 || ano > DateTime.Now.Year)
            {
                Console.Write($"Ano de publicação (1000-{DateTime.Now.Year}): ");
                if (!int.TryParse(Console.ReadLine(), out ano) || ano < 1000 || ano > DateTime.Now.Year)
                {
                    Console.WriteLine($"Ano inválido! Insira um ano entre 1000 e {DateTime.Now.Year}.\n");
                    ano = 0;
                }
            }

            biblioteca.AdicionarLivro(titulo, autor, ano);
        }

        // ─── REMOVER LIVRO ────────────────────────────────────────────
        private void MenuRemoverLivro()
        {
            Console.WriteLine("\n─── REMOVER LIVRO ──────────────────────────────\n");
            string titulo = LerStringObrigatoria("Título do livro a remover");
            biblioteca.RemoverLivro(titulo);
        }

        // ─── EMPRESTAR LIVRO ──────────────────────────────────────────
        private void MenuEmprestarLivro()
        {
            Console.WriteLine("\n─── EMPRESTAR LIVRO ────────────────────────────\n");
            string titulo = LerStringObrigatoria("Título do livro a emprestar");
            biblioteca.EmprestarLivro(titulo);
        }

        // ─── DEVOLVER LIVRO ───────────────────────────────────────────
        private void MenuDevolverLivro()
        {
            Console.WriteLine("\n─── DEVOLVER LIVRO ─────────────────────────────\n");
            string titulo = LerStringObrigatoria("Título do livro a devolver");
            biblioteca.DevolverLivro(titulo);
        }

        // ─── LISTAR LIVROS ────────────────────────────────────────────
        private void MenuListarLivros()
        {
            Console.WriteLine("\n─── LISTA DE LIVROS ────────────────────────────");
            biblioteca.ListarLivros();
        }

        // ─── AUXILIARES ───────────────────────────────────────────────
        private int LerOpcao()
        {
            try { return int.Parse(Console.ReadLine()); }
            catch { return -1; }
        }

        private string LerStringObrigatoria(string campo)
        {
            string valor = "";
            while (string.IsNullOrWhiteSpace(valor))
            {
                Console.Write($"{campo}: ");
                valor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(valor))
                    Console.WriteLine($"O campo \"{campo}\" não pode ser vazio!\n");
            }
            return valor.Trim();
        }
    }
}