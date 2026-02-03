using System;
using System.Globalization;
using System.Threading;
using Ficha1._7;

namespace Ficha1._7
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var gestor = new GestorProdutos();

            while (true)
            {
                Console.WriteLine("\n--- Menu Gestor de Produtos ---");
                Console.WriteLine("1. Adicionar produto");
                Console.WriteLine("2. Apresentar todos os produtos");
                Console.WriteLine("3. Consultar produtos por quantidade");
                Console.WriteLine("4. Consultar produtos por nome");
                Console.WriteLine("5. Consultar produto por código");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();

                        Console.Write("Código: ");
                        if (!int.TryParse(Console.ReadLine(), out int codigo))
                        {
                            Console.WriteLine("Código inválido.");
                            break;
                        }

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Preço: ");
                        float preco = LerFloat();

                        Console.Write("Stock: ");
                        if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                        {
                            Console.WriteLine("Stock inválido.");
                            break;
                        }

                        try
                        {
                            gestor.AdicionarProduto(new Produto(codigo, nome, preco, stock));
                            Console.WriteLine("Produto adicionado com sucesso.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("\nLista de produtos disponíveis:");
                        gestor.ApresentarProdutos();
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Mostrar produtos com stock inferior ou igual a: ");
                        if (!int.TryParse(Console.ReadLine(), out int quantidade))
                        {
                            Console.WriteLine("Quantidade inválida.");
                            break;
                        }

                        var produtosInferior = gestor.ProdutosComStockInferiorA(quantidade);
                        if (produtosInferior.Count == 0)
                            Console.WriteLine("Nenhum produto encontrado.");
                        else
                            produtosInferior.ForEach(p => Console.WriteLine(p));
                        break;

                    case "4":
                        Console.Clear();
                        Console.Write("Nome do produto para consulta: ");
                        string nomeConsulta = Console.ReadLine();

                        var porNome = gestor.ConsultarPorNome(nomeConsulta);
                        if (porNome.Count == 0)
                            Console.WriteLine("Nenhum produto encontrado.");
                        else
                            porNome.ForEach(p => Console.WriteLine(p));
                        break;

                    case "5":
                        Console.Clear();
                        Console.Write("Código do produto para consulta: ");
                        if (!int.TryParse(Console.ReadLine(), out int codigoConsulta))
                        {
                            Console.WriteLine("Código inválido.");
                            break;
                        }

                        var produto = gestor.ConsultarPorCodigo(codigoConsulta);
                        if (produto == null)
                            Console.WriteLine("Produto não encontrado.");
                        else
                            Console.WriteLine(produto);
                        break;

                    case "0":
                        Console.WriteLine("Adeus, um beijo e um queijo!!");
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static float LerFloat()
        {
            while (true)
            {
                string input = Console.ReadLine().Replace(',', '.');

                if (float.TryParse(
                    input,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out float valor) && valor >= 0)
                {
                    return valor;
                }

                Console.Write("Preço inválido. Tente novamente: ");
            }
        }
    }
}
