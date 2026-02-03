using System; // For Console    
using System.Collections.Generic; // For List<T>
using System.Globalization; // For CultureInfo
using System.Linq; // For LINQ methods

namespace Ficha1._4
{
    internal class AgenciaImobiliaria
    {
        private readonly List<Imovel> imoveis = new List<Imovel>(); // List to store properties

        public void InserirImovel(string endereco, float preco, string tipo)
        {
            imoveis.Add(new Imovel(endereco, preco, tipo));
        }

        public bool AlterarPrecoImovel(string endereco, float novoPreco)
        {
            var imovel = imoveis.FirstOrDefault(i => i.Endereco.Equals(endereco, StringComparison.OrdinalIgnoreCase));
            if (imovel != null)
            {
                imovel.Preco = novoPreco;
                return true;
            }
            return false;
        }

        public void ListarImoveis()
        {
            if (imoveis.Count == 0)
            {
                Console.WriteLine("Nenhum imóvel cadastrado.");
                return;
            }
            foreach (var imovel in imoveis)
            {
                Console.WriteLine(imovel);
            }
        }

        public float CalcularValorMedio()
        {
            if (imoveis.Count == 0) return 0;
            return imoveis.Average(i => i.Preco);
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu Agência Imobiliária ---");
                Console.WriteLine("1. Inserir imóvel");
                Console.WriteLine("2. Alterar preço do imóvel");
                Console.WriteLine("3. Apresentar todos os imóveis");
                Console.WriteLine("4. Calcular valor médio dos imóveis");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Endereço: ");
                        var endereco = Console.ReadLine().Trim().ToLower();
                        Console.Write("Preço em €: ");
                        var precoInput = Console.ReadLine();
                        precoInput = precoInput.Replace(',', '.'); // Ensure consistent decimal separator
                        if (!float.TryParse(precoInput, NumberStyles.Float, CultureInfo.InvariantCulture, out var preco) || preco < 0) // Valida entrada de preço caso negativo ou inválido
                        {
                            Console.WriteLine("Preço inválido.");
                            break;
                        }
                        Console.Write("Tipo: ");
                        var tipo = Console.ReadLine().Trim().ToLower();
                        InserirImovel(endereco, preco, tipo);
                        Console.WriteLine("Imóvel inserido com sucesso.");
                        break;
                    case "2":
                        Console.Write("Endereço do imóvel para alterar: ");
                        var endAlterar = Console.ReadLine().Trim().ToLower();

                        Console.Write("Novo preço em €: ");
                        var novoPrecoInput = Console.ReadLine();
                        novoPrecoInput = novoPrecoInput.Replace(',', '.');

                        if (!float.TryParse(novoPrecoInput, NumberStyles.Float, CultureInfo.InvariantCulture, out var novoPreco) || novoPreco < 0)
                        {
                            Console.WriteLine("Preço inválido.");
                            break;
                        }

                        if (AlterarPrecoImovel(endAlterar, novoPreco))
                            Console.WriteLine("Preço alterado com sucesso.");
                        else
                            Console.WriteLine("Imóvel não encontrado.");
                        break;
                    case "3":
                        ListarImoveis();
                        break;
                    case "4":
                        var valorMedio = CalcularValorMedio();
                        Console.WriteLine($"Valor médio dos imóveis: {valorMedio}€");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}