namespace Ficha1._1
{
    public class Produto
    {
        public string Nome { get; private set; } // Auto-implemented property with private setter
        public float Preco { get; private set; }
        public int Stock { get; private set; }

        public Produto(string nome, float preco, int stock)
        {
            Nome = nome;
            Preco = preco;
            Stock = stock;
        }

        public Produto(string nome, float preco) : this(nome, preco, 0)
        {
        }

        public void AdicionarStock(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("A quantidade a adicionar deve ser positiva.", nameof(quantidade)); //nameof para indicar o nome do parâmetro que causou a exceção
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

        public int ConsultarStock()
        {
            return Stock;
        }
    }
}