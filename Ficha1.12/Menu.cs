using System;

namespace Ficha1._12
{
    public class Menu
    {
        private ContaBancaria conta;

        // ─── PONTO DE ENTRADA DO PROGRAMA ────────────────────────────
        public void Iniciar()
        {
            CriarConta();

            int opcao;
            do
            {
                MostrarMenu();
                opcao = LerOpcao();

                switch (opcao)
                {
                    case 1:
                        MenuDepositar();
                        break;
                    case 2:
                        MenuLevantar();
                        break;
                    case 3:
                        MenuAlterarTitular();
                        break;
                    case 4:
                        conta.ImprimirHistorico();
                        break;
                    case 5:
                        Console.WriteLine($"\n  {conta}");
                        break;
                    case 0:
                        Console.WriteLine("\nEncerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("\n✗ Opção inválida! Escolha entre 0 e 5.");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        // ─── CRIAÇÃO DA CONTA ─────────────────────────────────────────
        private void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║        ABERTURA DE CONTA BANCÁRIA        ║");
            Console.WriteLine("╚══════════════════════════════════════════╝\n");

            // Número da conta
            int numeroConta = 0;
            while (numeroConta <= 0)
            {
                Console.Write("Insira o número da conta: ");
                if (!int.TryParse(Console.ReadLine(), out numeroConta) || numeroConta <= 0)
                {
                    Console.WriteLine("Número de conta inválido!\n");
                    numeroConta = 0;
                }
            }

            // Titular
            string titular = LerStringObrigatoria("Titular da Conta");

            // Depósito inicial (facultativo)
            Console.Write("\nDeseja depositar um valor inicial (s/n)? ");
            string resposta = Console.ReadLine().Trim().ToLower();

            if (resposta == "s")
            {
                float deposito = LerValorPositivo("Qual é o valor que vai depositar");
                conta = new ContaBancaria(numeroConta, titular, deposito);
            }
            else
            {
                conta = new ContaBancaria(numeroConta, titular);
            }

            Console.WriteLine("\nConta criada com sucesso!");
            Console.WriteLine($"\nDados da conta:\n  {conta}\n");
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        // ─── MENU PRINCIPAL ───────────────────────────────────────────
        private void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           BANCO - CONTA BANCÁRIA         ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine($"║  {conta,-42}║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1 - Depositar (Crédito)                 ║");
            Console.WriteLine("║  2 - Levantar  (Débito)                  ║");
            Console.WriteLine("║  3 - Alterar Titular                     ║");
            Console.WriteLine("║  4 - Ver Histórico de Movimentos         ║");
            Console.WriteLine("║  5 - Consultar Dados da Conta            ║");
            Console.WriteLine("║  0 - Sair                                ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
        }

        // ─── DEPOSITAR ────────────────────────────────────────────────
        private void MenuDepositar()
        {
            Console.WriteLine("\n─── DEPOSITAR ──────────────────────────────\n");
            try
            {
                float valor = LerValorPositivo("Introduza o valor para depositar");
                conta.Creditar(valor);
                Console.WriteLine($"\n {conta}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }

        // ─── LEVANTAR ─────────────────────────────────────────────────
        private void MenuLevantar()
        {
            Console.WriteLine("\n─── LEVANTAR ───────────────────────────────\n");
            try
            {
                float valor = LerValorPositivo("Introduza o valor para levantar");
                conta.Debitar(valor);
                Console.WriteLine($"\n{conta}");
                Console.WriteLine($"  (Taxa de débito de 1,00 € aplicada)");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
        }

        // ─── ALTERAR TITULAR ──────────────────────────────────────────
        private void MenuAlterarTitular()
        {
            Console.WriteLine("\n─── ALTERAR TITULAR ────────────────────────\n");
            Console.WriteLine($"  Titular atual: {conta.Titular}");
            try
            {
                string novoNome = LerStringObrigatoria("Novo nome do titular");
                conta.Titular = novoNome;
                Console.WriteLine($"\nTitular alterado com sucesso!\n  {conta}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
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

        private float LerValorPositivo(string mensagem)
        {
            float valor = 0;
            while (valor <= 0)
            {
                Console.Write($"{mensagem}: ");
                string input = Console.ReadLine().Replace(',', '.');
                if (!float.TryParse(input,
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out valor) || valor <= 0)
                {
                    Console.WriteLine("Valor inválido! Insira um número maior que zero.\n");
                    valor = 0;
                }
            }
            return valor;
        }
    }
}
