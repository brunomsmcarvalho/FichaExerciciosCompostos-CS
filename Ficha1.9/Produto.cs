using System;
using System.Globalization;

namespace Ficha1._9
{
    public class Produto
    {
        private string nome;
        private Fabricante fabricante;
        private decimal preco;

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Erro: O nome do produto não pode ser vazio!");
                    return;
                }
                nome = value;
            }
        }

        public Fabricante Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }

        public decimal Preco
        {
            get { return preco; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Erro: O preço deve ser positivo!");
                    return;
                }
                preco = value;
            }
        }

        public Produto(string nome, Fabricante fabricante, decimal preco)
        {
            Nome = nome;
            Fabricante = fabricante;
            Preco = preco;
        }

        public void ExibirInformacoes()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar o símbolo €

            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              INFORMAÇÕES DO PRODUTO                    ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║ Produto: {Nome.PadRight(46)}║");
            Console.WriteLine($"║ Preço: {Preco.ToString("C", CultureInfo.GetCultureInfo("pt-PT")).PadRight(48)}║");
            Console.WriteLine($"║ Fabricante: {Fabricante.Nome.PadRight(43)}║");
            Console.WriteLine($"║ Endereço: {Fabricante.Endereco.PadRight(45)}║");
            Console.WriteLine($"║ Cidade: {Fabricante.Cidade.PadRight(47)}║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        }

        public override string ToString()
        {
            return $"{Nome} - {Preco:C} (Fabricante: {Fabricante.Nome})";
        }
    }
}