using ScreenSound.Modelos;
using System.Linq;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite a banda cuja música deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Agora digite a música da banda: ");
            string nomeMusica = Console.ReadLine()!;
            Musica musica = new Musica(banda);
            musica.Nome = nomeMusica;
            Console.Write("Agora digite o álbum que a música pertence: ");
            string tituloAlbum = Console.ReadLine()!;

            if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));                
               
                //Album album = new Album(tituloAlbum);
                album.AdicionarMusica(musica);
                Console.WriteLine($"A música {musica.Nome} do álbum {tituloAlbum} foi registrada com sucesso!");
                Thread.Sleep(4000);
                Console.Clear();
            }
            else 
            {
                Console.WriteLine($"\nO álbum {tituloAlbum} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
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
