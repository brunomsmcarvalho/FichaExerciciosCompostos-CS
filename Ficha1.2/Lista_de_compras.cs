using System;
using System.Collections.Generic;

public class Lista_De_Compras
{
    public class Compra
    {
        public DateTime Data { get; }
        public string Produto { get; }
        public float Valor { get; }

        public Compra(DateTime data, string produto, float valor)
        {
            Data = data;
            Produto = produto;
            Valor = valor;
        }
    }

    private readonly List<Compra> compras;

    public Lista_De_Compras()
    {
        compras = new List<Compra>();
    }

    public void AdicionarCompra(DateTime data, string produto, float valor)
    {
        compras.Add(new Compra(data, produto, valor));
    }

    public IReadOnlyList<Compra> ListarCompras()
    {
        return compras.AsReadOnly();
    }

    public void LimparCompras()
    {
        compras.Clear();
    }
}