using System;
using System.Collections.Generic;
using System.Text;

namespace Ficha1._6
{
    public class Tarefa
    {
        private static int contadorId = 1; // gera IDs automáticos

        public int Id { get; private set; }
        public string Descricao { get; set; }
        public DateTime DataConclusao { get; set; }

        public Tarefa(string descricao, DateTime dataConclusao)
        {
            Id = contadorId++;
            Descricao = descricao;
            DataConclusao = dataConclusao;
        }

        public bool DeveSerExecutadaHoje()
        {
            return DataConclusao.Date == DateTime.Today;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Descricao} | Data: {DataConclusao:dd/MM/yyyy}";
        }
    }
}
