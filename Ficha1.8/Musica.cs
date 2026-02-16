using System;

namespace Ficha1._8
{

	public class Musica
	{
		public string Nome { get; set; }
		public string Autor { get; set; }
		public string Album { get; set; }

		public Musica(string nome, string autor, string album)
		{
			Nome = nome;
			Autor = autor;
			Album = album;
		}

		public override string ToString()
		{
			return $"{Nome} - {Autor} (Álbum: {Album})";

		}
	}
}