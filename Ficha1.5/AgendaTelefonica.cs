using System.Collections.Generic;

namespace Ficha1._5
{
    public class AgendaTelefonica
    {
        private List<Contato> contatos;
        // Constructor
        public AgendaTelefonica()
        {
            contatos = new List<Contato>();
        }
        // Methods
        public void AdicionarContato(Contato contato)
        {
            contatos.Add(contato);
        }
        // Remove contact by name
        public bool RemoverContato(string nome)
        {
            Contato contato = contatos.Find(c => c.Nome == nome);

            if (contato != null)
            {
                contatos.Remove(contato);
                return true;
            }

            return false;
        }
        // Search contact by name
        public Contato ProcurarContato(string nome)
        {
            return contatos.Find(c => c.Nome == nome);
        }
    }
}