using System;
using System.Collections.Generic;
using System.Text;

namespace Ficha1._11
{
    public class Agenda
    {
        private List<Pessoa> pessoas = new List<Pessoa>();

        // Armazena uma nova pessoa na agenda
        public void ArmazenaPessoa(string nome, int idade, float altura)
        {
            // Verifica se já existe pessoa com esse nome
            if (BuscaPessoa(nome) != null)
            {
                Console.WriteLine($"\nJá existe uma pessoa com o nome \"{nome}\" na agenda.");
                return;
            }

            Pessoa novaPessoa = new Pessoa(nome, idade, altura);
            pessoas.Add(novaPessoa);
            Console.WriteLine($"\nPessoa \"{nome}\" adicionada com sucesso!");
        }

        // Remove uma pessoa pelo nome
        public void RemovePessoa(string nome)
        {
            Pessoa pessoa = BuscaPessoa(nome);

            if (pessoa == null)
            {
                Console.WriteLine($"\nPessoa \"{nome}\" não encontrada na agenda.");
                return;
            }

            pessoas.Remove(pessoa);
            Console.WriteLine($"\nPessoa \"{nome}\" removida com sucesso!");
        }

        // Busca e retorna uma pessoa pelo nome (retorna null se não encontrar)
        public Pessoa BuscaPessoa(string nome)
        {
            foreach (Pessoa p in pessoas)
            {
                if (p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                    return p;
            }
            return null;
        }

        // Imprime todos os dados de todas as pessoas
        public void ImprimeAgenda()
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("\n A agenda está vazia.");
                return;
            }

            Console.WriteLine($"\n  Total de pessoas: {pessoas.Count}\n");
            Console.WriteLine("  " + new string('─', 30));

            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"  [{i + 1}]");
                Console.WriteLine(pessoas[i].ToString());
                Console.WriteLine("  " + new string('─', 30));
            }
        }

        // Retorna quantas pessoas estão na agenda
        public int TotalPessoas()
        {
            return pessoas.Count;
        }
    }
}