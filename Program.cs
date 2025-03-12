using MathNet.Numerics;
using NPOI.SS.UserModel;

class Program
{
    private static string caminhoArquivo = Path.Combine(Environment.CurrentDirectory, "C:/dev/autoglass/MusicasLinq/obj/Debug/net9.0/musicas1.xlsx");
    private static List<Musica> musicas = [];
    static void Main(string[] args)
    {
        ImportarDadosPlanilha();
        Exe2();
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

}