using System;


namespace Ficha1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Playlist minhaPlaylist = null;
            bool sair = false;

            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          BEM-VINDO AO GESTOR DE PLAYLISTS              ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            while (!sair)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        minhaPlaylist = CriarPlaylist();
                        break;

                    case "2":
                        AdicionarMusica(minhaPlaylist);
                        break;

                    case "3":
                        ListarMusicas(minhaPlaylist);
                        break;

                    case "4":
                        ReproduzirAleatoria(minhaPlaylist);
                        break;

                    case "5":
                        CarregarPlaylistExemplo(ref minhaPlaylist);
                        break;

                    case "0":
                        sair = true;
                        Console.WriteLine("\nObrigado por usar o Gestor de Playlists!");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("\n╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                    MENU PRINCIPAL                      ║");
            Console.WriteLine("╠════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  1 - Criar Nova Playlist                               ║");
            Console.WriteLine("║  2 - Adicionar Música                                  ║");
            Console.WriteLine("║  3 - Listar Músicas da Playlist                        ║");
            Console.WriteLine("║  4 - Reproduzir Modo Aleatório                         ║");
            Console.WriteLine("║  5 - Carregar Playlist de Exemplo                      ║");
            Console.WriteLine("║  0 - Sair                                              ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
        }

        static Playlist CriarPlaylist()
        {
            Console.Clear();
            Console.WriteLine("\n═══ CRIAR NOVA PLAYLIST ═══\n");
            Console.Write("Digite o nome do dono da playlist: ");
            string dono = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dono))
            {
                Console.WriteLine("\nNome inválido! Usando 'Utilizador' como padrão.");
                dono = "Utilizador";
            }

            Playlist novaPlaylist = new Playlist(dono);
            Console.WriteLine($"\nPlaylist de {dono} criada com sucesso!");

            return novaPlaylist;
        }

        static void AdicionarMusica(Playlist playlist)
        {
            Console.Clear();

            if (playlist == null)
            {
                Console.WriteLine("\nErro: Nenhuma playlist foi criada ainda!");
                Console.WriteLine("   Por favor, crie uma playlist primeiro (opção 1).");
                return;
            }

            Console.WriteLine("\n═══ ADICIONAR MÚSICA ═══\n");

            Console.Write("Nome da música: ");
            string nome = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Álbum: ");
            string album = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(autor))
            {
                Console.WriteLine("\nNome e Autor são obrigatórios!");
                return;
            }

            Musica novaMusica = new Musica(nome, autor, album);
            playlist.AdicionarMusica(novaMusica);
        }

        static void ListarMusicas(Playlist playlist)
        {
            Console.Clear();

            if (playlist == null)
            {
                Console.WriteLine("\nErro: Nenhuma playlist foi criada ainda!");
                Console.WriteLine("   Por favor, crie uma playlist primeiro (opção 1).");
                return;
            }

            Console.WriteLine("\n═══ LISTA DE MÚSICAS ═══");
            playlist.ListarMusicas();
        }


        static void ReproduzirAleatoria(Playlist playlist)
        {
            Console.Clear();

            if (playlist == null)
            {
                Console.WriteLine("\nErro: Nenhuma playlist foi criada ainda!");
                Console.WriteLine("   Por favor, crie uma playlist primeiro (opção 1).");
                return;
            }

            playlist.ReproduzirAleatoria();  // ← Chama o método SEM passar argumentos
        }


        static void CarregarPlaylistExemplo(ref Playlist playlist)
        {
            Console.Clear();
            Console.WriteLine("\n═══ CARREGAR PLAYLIST DE EXEMPLO ═══\n");

            playlist = new Playlist("Demo User");

            Musica m1 = new Musica("Bohemian Rhapsody", "Queen", "A Night at the Opera");
            Musica m2 = new Musica("Imagine", "John Lennon", "Imagine");
            Musica m3 = new Musica("Hotel California", "Eagles", "Hotel California");
            Musica m4 = new Musica("Stairway to Heaven", "Led Zeppelin", "Led Zeppelin IV");
            Musica m5 = new Musica("Smells Like Teen Spirit", "Nirvana", "Nevermind");

            playlist.AdicionarMusica(m1);
            playlist.AdicionarMusica(m2);
            playlist.AdicionarMusica(m3);
            playlist.AdicionarMusica(m4);
            playlist.AdicionarMusica(m5);

            Console.WriteLine($"\nPlaylist de exemplo carregada com {playlist.Musicas.Count} músicas!");
        }
    }
}