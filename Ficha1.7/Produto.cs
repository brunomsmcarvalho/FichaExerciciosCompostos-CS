using System;
using System.Collections.Generic;
using System.Linq;

namespace Ficha1._7
{
    public class Produto
    {
        public int Codigo { get; }
        public string Nome { get; private set; }
        public float Preco { get; private set; }
        public int Stock { get; private set; }

        public Produto(int codigo, string nome, float preco, int stock = 0)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(nome));
            if (preco < 0)
                throw new ArgumentException("O preço não pode ser negativo.", nameof(preco));
            if (stock < 0)
                throw new ArgumentException("O stock não pode ser negativo.", nameof(stock));

            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Stock = stock;
        }

        public void AtualizarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("O nome não pode ser vazio.", nameof(novoNome));
            Nome = novoNome;
        }

        public void AtualizarPreco(float novoPreco)
        {
            if (novoPreco < 0)
                throw new ArgumentException("O preço não pode ser negativo.", nameof(novoPreco));
            Preco = novoPreco;
        }

        public void AdicionarStock(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("A quantidade a adicionar deve ser positiva.", nameof(quantidade));
            Stock += quantidade;
        }

        public bool RemoverStock(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("A quantidade a remover deve ser positiva.", nameof(quantidade));
            if (quantidade > Stock)
                return false;
            Stock -= quantidade;
            return true;
        }

        public override string ToString()
        {
            return $"Código: {Codigo}, Nome: {Nome}, Preço: {Preco}€, Stock: {Stock}";
        }

        public override bool Equals(object obj)
        {
            return obj is Produto produto && Codigo == produto.Codigo;
        }
    }
}