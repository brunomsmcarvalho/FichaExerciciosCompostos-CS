using System;

namespace Ficha1._4
{
    internal class Imovel
    {
        public string Endereco { get; set; }
        public float Preco { get; set; }
        public string Tipo { get; set; }

        public Imovel(string endereco, float preco, string tipo)
        {
            Endereco = endereco;
            Preco = preco;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"Endereço: {Endereco}, Preço: {Preco}€, Tipo: {Tipo}";
        }
    }
}