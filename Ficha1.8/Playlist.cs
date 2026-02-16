using System;
using System.Collections.Generic;
using System.Threading;

namespace Ficha1._8
{
	public class Playlist
	{
		public List<Musica> Musicas { get; set; }
		public string Dono { get; set; }

		public Playlist(string dono)
		{
			Dono = dono;
			Musicas = new List<Musica>();
		}

		// Método para adicionar músicas
		public void AdicionarMusica(Musica musica)
		{
			Musicas.Add(musica);
			Console.WriteLine($"Música '{musica.Nome}' adicionada à playlist de {Dono}");
		}

		// Método para tocar uma música
		public void TocarMusica(Musica musica)
		{
			Console.WriteLine($"A tocar: {musica}");
		}

		// Método para reprodução aleatória
		public void ReproduzirAleatoria()
		{
			if (Musicas.Count == 0)
			{
				Console.WriteLine("A playlist está vazia!");
				return;
			}

			Console.WriteLine($"\n{"=".PadRight(60, '=')}");
			Console.WriteLine($"  Reprodução Aleatória - Playlist de {Dono}");
			Console.WriteLine($"  Total de músicas: {Musicas.Count}");
			Console.WriteLine($"{"=".PadRight(60, '=')}");
			Console.WriteLine();

			// Cria uma cópia da lista para embaralhar
			List<Musica> musicasAleatorias = new List<Musica>(Musicas);

			// Embaralha a lista usando algoritmo Fisher-Yates
			Random random = new Random();
			int n = musicasAleatorias.Count;
			while (n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				Musica temp = musicasAleatorias[k];
				musicasAleatorias[k] = musicasAleatorias[n];
				musicasAleatorias[n] = temp;
			}

			// Reproduz cada música com pausa entre elas
			for (int i = 0; i < musicasAleatorias.Count; i++)
			{
				Console.Write($"{i + 1}. ");
				TocarMusica(musicasAleatorias[i]);

				// Pausa de 3 segundos entre músicas (exceto na última)
				if (i < musicasAleatorias.Count - 1)
				{
					Console.WriteLine("\nA reproduzir, aguarde, oiça o som com calma e tranquilidade...");
					Thread.Sleep(4000); // 3000 milissegundos = 3 segundos
					Console.WriteLine();
				}
			}

			Console.WriteLine($"\n{"=".PadRight(60, '=')}");
			Console.WriteLine("Reprodução concluída!");
			Console.WriteLine($"{"=".PadRight(60, '=')}");
			Console.WriteLine();
		}

		// Método auxiliar para listar músicas
		public void ListarMusicas()
		{
			if (Musicas.Count == 0)
			{
				Console.WriteLine("A playlist está vazia!");
				return;
			}

			Console.WriteLine($"\nPlaylist de {Dono}:");
			Console.WriteLine(new string('-', 60));
			for (int i = 0; i < Musicas.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {Musicas[i]}");
			}
			Console.WriteLine(new string('-', 60));
		}
	}
}