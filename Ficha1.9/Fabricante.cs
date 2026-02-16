using System;

namespace Ficha1._9
{
    public class Fabricante
    {
        private string nome; // Campo privado para armazenar o nome do fabricante
        private string endereco;
        private string cidade;

        public string Nome // Propriedade pública para acessar o nome do fabricante
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Erro: O nome do fabricante não pode ser vazio!");
                    return;
                }
                nome = value;
            }
        }

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public Fabricante(string nome, string endereco, string cidade)
        {
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
        }

        public override string ToString() // Sobrescreve o método ToString para exibir as informações do fabricante
        {
            return $"{Nome} - {Endereco}, {Cidade}";
        }
    }
}
