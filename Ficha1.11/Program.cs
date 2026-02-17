using Ficha1._11;
using System;

namespace Ficha1._11
{
    class Program
    {
        static Agenda agenda = new Agenda();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                MostrarMenu();
                opcao = LerOpcao();

                switch (opcao)
                {
                    case 1:
                        MenuAdicionarPessoa();
                        break;
                    case 2:
                        MenuRemoverPessoa();
                        break;
                    case 3:
                        MenuBuscarPessoa();
                        break;
                    case 4:
                        MenuImprimirAgenda();
                        break;
                    case 0:
                        Console.WriteLine("\nA sair...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Escolha entre 0 e 4.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        // ─── MENU PRINCIPAL ─────────────────────────────────────────
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         AGENDA DE CONTACTOS          ║");
            Console.WriteLine($"║       Pessoas registadas: {agenda.TotalPessoas(),3}        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║  1 - Adicionar Pessoa                ║");
            Console.WriteLine("║  2 - Remover Pessoa                  ║");
            Console.WriteLine("║  3 - Buscar Pessoa                   ║");
            Console.WriteLine("║  4 - Imprimir Agenda                 ║");
            Console.WriteLine("║  0 - Sair                            ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
        }

        // ─── LER OPÇÃO ──────────────────────────────────────────────
        static int LerOpcao()
        {
            try { return int.Parse(Console.ReadLine()); }
            catch { return -1; }
        }

        // ─── ADICIONAR PESSOA ────────────────────────────────────────
        static void MenuAdicionarPessoa()
        {
            Console.WriteLine("\n─── ADICIONAR PESSOA ───────────────────\n");

            string nome = LerStringObrigatoria("Nome");

            int idade = 0;
            while (idade <= 0)
            {
                Console.Write("Idade : ");
                if (!int.TryParse(Console.ReadLine(), out idade) || idade <= 0)
                {
                    Console.WriteLine("Idade inválida! Insira um número inteiro maior que zero.\n");
                    idade = 0;
                }
            }

            float altura = 0;
            while (altura <= 0)
            {
                Console.Write("Altura (ex: 1.75): ");
                string input = Console.ReadLine().Replace(',', '.');
                if (!float.TryParse(input,
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out altura) || altura <= 0)
                {
                    Console.WriteLine("Altura inválida! Insira um valor maior que zero.\n");
                    altura = 0;
                }
            }

            try
            {
                agenda.ArmazenaPessoa(nome, idade, altura);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }

        // ─── REMOVER PESSOA ──────────────────────────────────────────
        static void MenuRemoverPessoa()
        {
            Console.WriteLine("\n─── REMOVER PESSOA ─────────────────────\n");
            string nome = LerStringObrigatoria("Nome a remover");
            agenda.RemovePessoa(nome);
        }

        // ─── BUSCAR PESSOA ───────────────────────────────────────────
        static void MenuBuscarPessoa()
        {
            Console.WriteLine("\n─── BUSCAR PESSOA ──────────────────────\n");
            string nome = LerStringObrigatoria("Nome a buscar");

            Pessoa encontrada = agenda.BuscaPessoa(nome);

            if (encontrada != null)
            {
                Console.WriteLine("\n" +
                    "Pessoa encontrada:\n");
                Console.WriteLine("  " + new string('─', 30));
                Console.WriteLine(encontrada.ToString());
                Console.WriteLine("  " + new string('─', 30));
            }
            else
            {
                Console.WriteLine($"\nPessoa \"{nome}\" não encontrada na agenda.");
            }
        }

        // ─── IMPRIMIR AGENDA ─────────────────────────────────────────
        static void MenuImprimirAgenda()
        {
            Console.WriteLine("\n─── AGENDA COMPLETA ────────────────────");
            agenda.ImprimeAgenda();
        }

        // ─── AUXILIAR: LER STRING NÃO VAZIA ─────────────────────────
        static string LerStringObrigatoria(string campo)
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