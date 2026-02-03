using System;
using System.Text.RegularExpressions;

namespace Ficha1._5
{
    class Program
    {
        static bool EmailValido(string email)
        {
            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, padrao);
        }

        static bool TelefoneValido(string telefone)
        {
            return telefone.Length == 9 && telefone.All(char.IsDigit);
        }

        static void Main(string[] args)
        {
            AgendaTelefonica agenda = new AgendaTelefonica();
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=== AGENDA TELEFÓNICA ===");
                Console.WriteLine("1 - Adicionar contacto");
                Console.WriteLine("2 - Procurar contacto");
                Console.WriteLine("3 - Remover contacto");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarContato(agenda);
                        break;

                    case 2:
                        ProcurarContato(agenda);
                        break;

                    case 3:
                        RemoverContato(agenda);
                        break;

                    case 4:
                        Console.WriteLine("A sair...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPrima ENTER para continuar...");
                Console.ReadLine();

            } while (opcao != 4);
        }

        // -------- MÉTODOS DO MENU --------

        static void AdicionarContato(AgendaTelefonica agenda)
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            string telefone;
            do
            {
                Console.Write("Telefone (9 dígitos): ");
                telefone = Console.ReadLine();

                if (!TelefoneValido(telefone))
                    Console.WriteLine("Telefone inválido!");
            }
            while (!TelefoneValido(telefone));

            string email;
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();

                if (!EmailValido(email))
                    Console.WriteLine("Email inválido!");
            }
            while (!EmailValido(email));

            Contato contato = new Contato(nome, telefone, email);
            agenda.AdicionarContato(contato);

            Console.WriteLine("Contacto adicionado com sucesso!");
        }

        static void ProcurarContato(AgendaTelefonica agenda)
        {
            Console.Write("Nome do contacto a procurar: ");
            string nome = Console.ReadLine();

            Contato contato = agenda.ProcurarContato(nome);

            if (contato != null)
            {
                Console.WriteLine("Contacto encontrado:");
                Console.WriteLine($"Nome: {contato.Nome}");
                Console.WriteLine($"Telefone: {contato.Telefone}");
                Console.WriteLine($"Email: {contato.Email}");
            }
            else
            {
                Console.WriteLine("Contacto não encontrado.");
            }
        }

        static void RemoverContato(AgendaTelefonica agenda)
        {
            Console.Write("Nome do contacto a remover: ");
            string nome = Console.ReadLine();

            bool removido = agenda.RemoverContato(nome);

            if (removido)
            {
                Console.WriteLine("Contacto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Contacto não encontrado.");
            }
        }
    }
}
