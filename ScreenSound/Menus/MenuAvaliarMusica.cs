using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuAvaliarMusica : Menu
    {
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            base.Executar(bandasRegistradas);

            ExibirTituloDaOpcao("Avaliar música");
            Console.Write("Digite a banda cuja a música deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!;

            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];                
                Console.Write($"Digite o álbum que a música pertence: ");
                string tituloAlbum = Console.ReadLine()!;
                if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
                    {
                    Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                    Console.WriteLine($"Digite a música : ");
                    string nomeDaMusica = Console.ReadLine()!;
                    if (album.Musicas.Any(a => a.Nome.Equals(nomeDaMusica)))
                     {
                        Musica musica = album.Musicas.First(a => a.Nome.Equals(nomeDaMusica));
                        Console.WriteLine($"Qual a nota que o música{nomeDaMusica} merece: ");
                        Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                        musica.AdicionarNota(nota);
                        Console.WriteLine($"\na nota {nota.Nota} foi registrada com sucesso para a música{nomeDaMusica}");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }

                }

            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();

            }
        }

    }
}
