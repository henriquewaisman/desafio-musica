﻿using MathNet.Numerics;
using MathNet.Numerics.Statistics;
using NPOI.SS.UserModel;
using Org.BouncyCastle.Asn1.X509;

class Program
{
    private static string caminhoArquivo = Path.Combine(Environment.CurrentDirectory, "C:/dev/autoglass/MusicasLinq/obj/Debug/net9.0/musicas1.xlsx");
    private static List<Musica> musicas = [];
    static void Main(string[] args)
    {
        ImportarDadosPlanilha();
        Exe5();
    }
    public static void ImportarDadosPlanilha()
    {
        try
        {
            IWorkbook pastaTrabalho = WorkbookFactory.Create(caminhoArquivo);

            ISheet planilha = pastaTrabalho.GetSheetAt(0);

            for (int i = 1; i < planilha.PhysicalNumberOfRows; i++)
            {
                IRow linha = planilha.GetRow(i);
                long id = (long)linha.GetCell(0).NumericCellValue;
                DateTime dataLancamento = linha.GetCell(1).DateCellValue ?? DateTime.Now;
                string nome = linha.GetCell(2).StringCellValue;
                string artista = linha.GetCell(3).StringCellValue;
                string album = linha.GetCell(4).StringCellValue;
                string genero = linha.GetCell(5).StringCellValue;
                double duracao = linha.GetCell(6).NumericCellValue;
                string gravadora = linha.GetCell(7).StringCellValue;
                string pais = linha.GetCell(8).StringCellValue;
                string idioma = linha.GetCell(9).StringCellValue;

                Musica musica = new(id, dataLancamento, nome, artista, album, genero, duracao, gravadora, pais, idioma);

                musicas.Add(musica);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Exe1()
    {
        var maiorDuracao = musicas.Max(m => m.Duracao);
        Console.WriteLine($"A musica com maior duração dura {maiorDuracao:F2} minutos");
    }
    public static void Exe2()
    {
        var numArtistas = musicas.DistinctBy(m => m.Artista).Count();
        Console.WriteLine($"Temos {numArtistas} artistas diferentes cadastrados em nossa base.");
    }
    public static void Exe3()
    {
        var albunsPorMesEAno = musicas.GroupBy(g => new
        {
            Mes = g.DataLancamento.Month,
            Ano = g.DataLancamento.Year,
            formato = g.DataLancamento.ToString("MMMM/yyyy")

        }).OrderBy(o => o.Key.Ano).ThenBy(o => o.Key.Mes).Select(s => new
        {
            formato = s.Key.formato,
            Quantidade = s.Count()
        });

        foreach (var album in albunsPorMesEAno)
        {
            Console.WriteLine($"{album.formato}: {album.Quantidade} álbuns");
        }
    }
    public static void Exe4A()
    {
        var rankGenero = musicas.GroupBy(m => m.Genero)
        .Select(m => new
        {
            genero = m.Key,
            quantidade = m.Count()
        }).OrderByDescending(m => m.quantidade)
        .Take(5)
        .ToList();
        foreach (var genero in rankGenero)
        {
            Console.WriteLine($"{genero.genero} - {genero.quantidade}");
        }
    }
    public static void Exe4B()
    {
        var maisMusicas = musicas.GroupBy(m => m.Album)
        .Select(m => new
        {
            album = m.Key,
            quantidade = m.Count()
        }).OrderByDescending(m => m.quantidade)
        .Take(3)
        .ToList();
        foreach (var album in maisMusicas)
        {
            Console.WriteLine($"{album.album} - {album.quantidade} musicas");
        }
    }
    public static void Exe4C()
    {
        var topPaises = musicas.GroupBy(m => m.Pais)
        .Select(m => new
        {
            pais = m.Key,
            quantidade = m.Count()
        }).OrderByDescending(m => m.quantidade)
        .Take(3)
        .ToList();
        foreach (var pais in topPaises)
        {
            Console.WriteLine($"{pais.pais} - {pais.quantidade}");
        }
    }
    public static void Exe5()
    {
        var qtdGravadoras = musicas.GroupBy(m => m.Gravadora).Count();
        var topGravadoras = musicas.GroupBy(m => m.Gravadora)
        .Select(m => new
        {
            nome = m.Key,
            qtdMusicas = m.Count()
        })
        .OrderByDescending(m => m.qtdMusicas)
        .Take(5)
        .ToList();

        Console.WriteLine($"A quantidade de gravadoras na base é {qtdGravadoras}");
        foreach (var gravadora in topGravadoras)
        {
            Console.WriteLine($"{gravadora.nome} - {gravadora.qtdMusicas} músicas");
        }
    }
}