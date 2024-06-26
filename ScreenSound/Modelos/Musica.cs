﻿namespace ScreenSound.Modelos;


internal class Musica : IAvaliavel
{
    private List<Avaliacao> notas = new List<Avaliacao>();

    public Musica(Banda artista)
    {
        Artista = artista;
    }

    public Musica(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public Banda Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista.Nome}";

    public double Media
    {
        get       
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome da música: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }
}