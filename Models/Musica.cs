class Musica
{
    public long Id { get; protected set; }
    public DateTime DataLancamento { get; protected set; }
    public string Nome { get; protected set; }
    public string Artista { get; protected set; }
    public string Album { get; protected set; }
    public string Genero { get; protected set; }
    public double Duracao { get; protected set; }
    public string Gravadora { get; protected set; }
    public string Pais { get; protected set; }
    public string Idioma { get; protected set; }

    public Musica(long id, DateTime dataLancamento, string nome, string artista, string album, string genero, double duracao, string gravadora, string pais, string idioma)
    {
        SetId(id);
        SetDataLancamento(dataLancamento);
        SetNome(nome);
        SetArtista(artista);
        SetAlbum(album);
        SetGenero(genero);
        SetDuracao(duracao);
        SetGravadora(gravadora);
        SetPais(pais);
        SetIdioma(idioma);
    }
    public void SetIdioma(string idioma)
    {
        if (string.IsNullOrEmpty(idioma) || idioma.Length > 255)
        {
            throw new Exception("Idioma Inválido");
        }
        Idioma = idioma;
    }
    public void SetPais(string pais)
    {
        if (string.IsNullOrEmpty(pais) || pais.Length > 255)
        {
            throw new Exception("Pais Inválido");
        }
        Pais = pais;
    }
    public void SetGravadora(string gravadora)
    {
        if (string.IsNullOrEmpty(gravadora) || gravadora.Length > 255)
        {
            throw new Exception("Gravadora Inválida");
        }
        Gravadora = gravadora;
    }
    public void SetDuracao(double duracao)
    {
        if (duracao < 0)
        {
            throw new Exception("Duração Inválida");
        }
        Duracao = duracao;
    }
    public void SetGenero(string genero)
    {
        if (string.IsNullOrEmpty(genero) || genero.Length > 255)
        {
            throw new Exception("Gênero Inválido");
        }
        Genero = genero;
    }
    public void SetAlbum(string album)
    {
        if (string.IsNullOrEmpty(album) || album.Length > 255)
        {
            throw new Exception("Álbum Inválido");
        }
        Album = album;
    }
    public void SetArtista(string artista)
    {
        if (string.IsNullOrEmpty(artista) || artista.Length > 255)
        {
            throw new Exception("Artista Inválido");
        }
        Artista = artista;
    }
    public void SetNome(string nome)
    {
        if (string.IsNullOrEmpty(nome) || nome.Length > 255)
        {
            throw new Exception("Nome Inválido");
        }
        Nome = nome;
    }
    public void SetDataLancamento(DateTime dataLancamento)
    {
        if (dataLancamento == DateTime.MinValue || dataLancamento > DateTime.Now)
        {
            throw new Exception("Data de Lançamento inválida");
        }
        DataLancamento = dataLancamento;
    }
    public void SetId(long id)
    {
        if (id < 0)
        {
            throw new Exception("Id inválido");
        }
        Id = id;
    }
}