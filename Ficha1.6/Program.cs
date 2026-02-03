using Ficha1._6;
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        GestorDeTarefas gestor = new GestorDeTarefas();
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== GESTOR DE TAREFAS ===");
            Console.WriteLine("1 - Adicionar tarefa");
            Console.WriteLine("2 - Remover tarefa");
            Console.WriteLine("3 - Listar todas as tarefas");
            Console.WriteLine("4 - Listar tarefas de hoje");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    AdicionarTarefaMenu(gestor);
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Tarefas registadas:");
                    gestor.ListarTarefas();

                    int id;
                    bool idValido;

                    do
                    {
                        Console.Write("\nDigite o ID da tarefa a remover: ");
                        idValido = int.TryParse(Console.ReadLine(), out id);

                        if (!idValido)
                        {
                            Console.WriteLine("ID inválido! Introduza um número.");
                        }

                    } while (!idValido);

                    gestor.RemoverTarefaPorId(id);
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    gestor.ListarTarefas();
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    gestor.ListarTarefasDeHoje();
                    Console.ReadKey();
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("A sair...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }

        } while (opcao != 0);
    }

    static void AdicionarTarefaMenu(GestorDeTarefas gestor)
    {
        Console.Write("Descrição da tarefa: ");
        string descricao = Console.ReadLine();

        DateTime data;
        bool dataValida;

        string[] formatosAceites =
        {
        "dd/MM/yyyy",
        "dd-MM-yyyy",
        "ddMMyyyy"
    };

        do
        {
            Console.Write("Data de conclusão (dd/MM/yyyy): ");
            string input = Console.ReadLine();

            dataValida = DateTime.TryParseExact(
                input,
                formatosAceites,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out data
            );

            if (!dataValida)
            {
                Console.WriteLine("Formato de data inválido!");
                Console.WriteLine("Exemplos: 25/01/2026 | 25-01-2026 | 25012026");
                continue;
            }

            if (data.Date < DateTime.Today)
            {
                Console.WriteLine("A data não pode ser anterior ao dia de hoje!");
                dataValida = false;
            }

        } while (!dataValida);

        gestor.AdicionarTarefa(descricao, data);
        Console.WriteLine("\nTarefa adicionada com sucesso!");
    }
}