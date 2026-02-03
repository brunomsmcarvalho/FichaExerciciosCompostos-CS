using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Ficha1._7
{

    public class GestorProdutos
    {
        private readonly List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException(nameof(produto));
            if (produtos.Any(p => p.Codigo == produto.Codigo))
                throw new InvalidOperationException("Já existe um produto com este código.");
            produtos.Add(produto);
        }

        public void ApresentarProdutos()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto registado.");
                return;
            }
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }
        }

        public List<Produto> ConsultarPorQuantidade(int quantidade)
        {
            return produtos.Where(p => p.Stock == quantidade).ToList();
        }

        public List<Produto> ConsultarPorNome(string nome)
        {
            return produtos.Where(p => p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Produto ConsultarPorCodigo(int codigo)
        {
            return produtos.FirstOrDefault(p => p.Codigo == codigo);
        }
        public List<Produto> ProdutosComStockInferiorA(int quantidade)
        {
            return produtos.Where(p => p.Stock <= quantidade).ToList();
        }
    }
}
