using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel.Design;

namespace Ficha1._6
{
    public class GestorDeTarefas
    {
        private List<Tarefa> tarefas = new List<Tarefa>();

        public void AdicionarTarefa(string descricao, DateTime data)
        {
            tarefas.Add(new Tarefa(descricao, data));
        }

        public void ListarTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Não há tarefas registadas.");
                return;
            }

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa);
            }
        }

        public void RemoverTarefaPorId(int id)
        {
            var tarefa = tarefas.Find(t => t.Id == id);

            if (tarefa != null)
            {
                tarefas.Remove(tarefa);
                Console.WriteLine("Tarefa removida com sucesso!");
            }
            else
            {
                Console.WriteLine("ID não encontrado.");
            }
        }

        public void ListarTarefasDeHoje()
        {
            bool existe = false;

            foreach (var tarefa in tarefas)
            {
                if (tarefa.DeveSerExecutadaHoje())
                {
                    Console.WriteLine(tarefa);
                    existe = true;
                }
            }

            if (!existe)
            {
                Console.WriteLine("Não há tarefas para hoje.");
            }
        }
    }
}