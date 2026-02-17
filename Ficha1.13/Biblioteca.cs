using System;
using System.Collections.Generic;

namespace Ficha1._13
{
    public class Biblioteca
    {
        // ─── CAMPO PRIVADO ────────────────────────────────────────────
        private List<Livro> livros = new List<Livro>();

        // ─── ADICIONAR LIVRO ──────────────────────────────────────────
        public void AdicionarLivro(string titulo, string autor, int anoPublicacao)
        {
            // Verifica se já existe livro com o mesmo título
            if (BuscarLivroPorTitulo(titulo) != null)
            {
                Console.WriteLine($"\nJá existe um livro com o título \"{titulo}\" na biblioteca.");
                return;
            }

            try
            {
                Livro novoLivro = new Livro(titulo, autor, anoPublicacao);
                livros.Add(novoLivro);
                Console.WriteLine($"\nLivro \"{titulo}\" adicionado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nErro ao adicionar livro: {ex.Message}");
            }
        }

        // ─── REMOVER LIVRO ────────────────────────────────────────────
        public void RemoverLivro(string titulo)
        {
            Livro livro = BuscarLivroPorTitulo(titulo);

            if (livro == null)
            {
                Console.WriteLine($"\nLivro \"{titulo}\" não encontrado na biblioteca.");
                return;
            }

            livros.Remove(livro);
            Console.WriteLine($"\nLivro \"{titulo}\" removido com sucesso!");
        }

        // ─── EMPRESTAR LIVRO ──────────────────────────────────────────
        public void EmprestarLivro(string titulo)
        {
            Livro livro = BuscarLivroPorTitulo(titulo);

            if (livro == null)
            {
                Console.WriteLine($"\nLivro \"{titulo}\" não encontrado na biblioteca.");
                return;
            }

            if (!livro.Disponibilidade)
            {
                Console.WriteLine($"\nO livro \"{titulo}\" já está emprestado.");
                return;
            }

            livro.Disponibilidade = false;
            Console.WriteLine($"\nLivro \"{titulo}\" emprestado com sucesso!");
        }

        // ─── DEVOLVER LIVRO ───────────────────────────────────────────
        public void DevolverLivro(string titulo)
        {
            Livro livro = BuscarLivroPorTitulo(titulo);

            if (livro == null)
            {
                Console.WriteLine($"\nLivro \"{titulo}\" não encontrado na biblioteca.");
                return;
            }

            if (livro.Disponibilidade)
            {
                Console.WriteLine($"\nO livro \"{titulo}\" já está disponível (não está emprestado).");
                return;
            }

            livro.Disponibilidade = true;
            Console.WriteLine($"\nLivro \"{titulo}\" devolvido com sucesso!");
        }

        // ─── LISTAR TODOS OS LIVROS ───────────────────────────────────
        public void ListarLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("\n  A biblioteca está vazia.");
                return;
            }

            Console.WriteLine($"\n  Total de livros: {livros.Count}");
            Console.WriteLine("  " + new string('─', 60));

            // Listar livros disponíveis
            var disponiveis = livros.FindAll(l => l.Disponibilidade);
            if (disponiveis.Count > 0)
            {
                Console.WriteLine("\nLIVROS DISPONÍVEIS:");
                foreach (Livro livro in disponiveis)
                {
                    Console.WriteLine(livro.ToString());
                }
            }

            // Listar livros emprestados
            var emprestados = livros.FindAll(l => !l.Disponibilidade);
            if (emprestados.Count > 0)
            {
                Console.WriteLine("\nLIVROS EMPRESTADOS:");
                foreach (Livro livro in emprestados)
                {
                    Console.WriteLine(livro.ToString());
                }
            }

            Console.WriteLine("  " + new string('─', 60));
        }

        // ─── BUSCAR LIVRO (MÉTODO AUXILIAR PRIVADO) ──────────────────
        private Livro BuscarLivroPorTitulo(string titulo)
        {
            foreach (Livro livro in livros)
            {
                if (livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                    return livro;
            }
            return null;
        }

        // ─── OBTER TOTAL DE LIVROS ────────────────────────────────────
        public int TotalLivros()
        {
            return livros.Count;
        }

        // ─── OBTER LIVROS DISPONÍVEIS ─────────────────────────────────
        public int LivrosDisponiveis()
        {
            return livros.FindAll(l => l.Disponibilidade).Count;
        }

        // ─── OBTER LIVROS EMPRESTADOS ─────────────────────────────────
        public int LivrosEmprestados()
        {
            return livros.FindAll(l => !l.Disponibilidade).Count;
        }
    }
}