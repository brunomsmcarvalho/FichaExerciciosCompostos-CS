using System;

namespace Ficha1._10
{
    public class Livro
    {
        // Campos privados (backing fields)
        private string titulo;
        private string autor;

        // Propriedade Titulo com encapsulamento
        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O título não pode ser vazio.");
                }
                titulo = value;
            }
        }

        // Propriedade Autor com encapsulamento
        public string Autor
        {
            get { return autor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("O autor não pode ser vazio.");
                }
                autor = value;
            }
        }

        // Construtor padrão
        public Livro()
        {
        }

        // Construtor com parâmetros
        public Livro(string titulo, string autor)
        {
            Titulo = titulo; // Usa a propriedade para aplicar validação
            Autor = autor;   // Usa a propriedade para aplicar validação
        }

        // Método para exibir informações do livro
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
        }

        // Override do método ToString
        public override string ToString()
        {
            return $"'{Titulo}' por {Autor}";
        }
    }
}