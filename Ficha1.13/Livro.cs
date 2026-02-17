using System;

namespace Ficha1._13
{
    public class Livro
    {
        // ─── CAMPOS PRIVADOS ─────────────────────────────────────────
        private string titulo;
        private string autor;
        private int anoPublicacao;
        private bool disponibilidade;

        // ─── PROPRIEDADES ─────────────────────────────────────────────
        public string Titulo
        {
            get { return titulo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O título não pode ser vazio.");
                titulo = value;
            }
        }

        public string Autor
        {
            get { return autor; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O autor não pode ser vazio.");
                autor = value;
            }
        }

        public int AnoPublicacao
        {
            get { return anoPublicacao; }
            set
            {
                if (value < 1000 || value > DateTime.Now.Year)
                    throw new ArgumentException($"O ano de publicação deve estar entre 1000 e {DateTime.Now.Year}.");
                anoPublicacao = value;
            }
        }

        public bool Disponibilidade
        {
            get { return disponibilidade; }
            set { disponibilidade = value; }
        }

        // ─── CONSTRUTOR ───────────────────────────────────────────────
        public Livro(string titulo, string autor, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            Disponibilidade = true; // Por defeito, livro está disponível
        }

        // ─── MÉTODOS ──────────────────────────────────────────────────
        public override string ToString()
        {
            string status = Disponibilidade ? "Disponível" : "Emprestado";
            return $"  \"{Titulo}\" - {Autor} ({AnoPublicacao}) [{status}]";
        }
    }
}