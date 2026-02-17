using System;

namespace Ficha1._11
{
    public class Pessoa
    {
        private string nome;
        private int idade;
        private float altura;

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome não pode ser vazio.");
                nome = value;
            }
        }

        public int Idade
        {
            get { return idade; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A idade deve ser maior que zero.");
                idade = value;
            }
        }

        public float Altura
        {
            get { return altura; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A altura deve ser maior que zero.");
                altura = value;
            }
        }

        public Pessoa(string nome, int idade, float altura)
        {
            Nome = nome;
            Idade = idade;
            Altura = altura;
        }

        public override string ToString()
        {
            return $"  Nome  : {Nome}\n  Idade : {Idade} anos\n  Altura: {Altura:F2} m";
        }
    }
}