using obligatorioMauiEFyCS;
using QuickType;
using SQLite;
using System.Data.SqlClient;

namespace obligatorioMauiEFyCS;

public partial class Cine : ContentPage
{
    private List<Result> listaOriginal = new List<Result>(); // lista original de las peliculas estrenadas
    public Cine()
    {
        InitializeComponent();
        Task cargandoEstrenos = CargarEstrenos();
    }
    
    public async Task CargarEstrenos()
    {
        try
        {
            string url = "https://api.themoviedb.org/3/trending/movie/week?api_key=3f57063ae2b1971b4002bb2c2959bc39&language=es-ES";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                var datos = CineSerializado.FromJson(json);

                foreach (var peliculas in datos.Results)
                {
                    peliculas.PosterPath = "https://image.tmdb.org/t/p/w500" + peliculas.PosterPath;
                }

                listaOriginal = datos.Results.ToList(); 
                EstrenosList.ItemsSource = listaOriginal;
            }
        }
        catch (Exception unaExcepcion)
        {
            await DisplayAlert("Error: ", "No se pudieron cargar los estrenos: " + unaExcepcion.Message, "OK");
        }
    }

    private Dictionary<string, long> nombreIdDeGenero = new Dictionary<string, long>
    {
        {"accion", 28},
        {"aventura", 12},
        {"animacion", 16},
        {"comedia", 35},
        {"crimen", 80},
        {"documental", 99},
        {"drama", 18},
        {"fantasia", 14},
        {"historia", 36},
        {"terror", 27},
        {"musical", 10402},
        {"misterio", 9648},
        {"romance", 10749},
        {"ciencia ficcion", 878},
        {"guerra medieval", 10752}

    };

    public async void OnFiltrarPeliculasPorGeneroYPalabra(object sender, EventArgs e)
    {
        string generoPorUsuario = GeneroEntry.Text.Trim().ToLower(); // trim para eliminar espacios al inicio y final de la busqueda;

        if (string.IsNullOrEmpty(generoPorUsuario))
        {
            EstrenosList.ItemsSource = listaOriginal; // si no hay texto o incluso una palabra o cualquier palabra que no este relacionada a un genero se muestra las peliculas sin filtrar
            return; 
        }
        await buscarEstrenosPorGeneroOPalabra(generoPorUsuario);
    }


    public async Task buscarEstrenosPorGeneroOPalabra(string pPalabra)
    {
        pPalabra = pPalabra.ToLower();

        if (nombreIdDeGenero.TryGetValue(pPalabra, out long generoId))
        {
            
            var peliculasFiltradas = listaOriginal.Where(pelicula => pelicula.GenreIds.Contains(generoId)).ToList();

            if (peliculasFiltradas.Count == 0)
            {
                await DisplayAlert("Aviso", "No se encontraron estrenos de peliculas con el genero: " + pPalabra, "OK"); 
            }

            EstrenosList.ItemsSource = peliculasFiltradas;

        }
        else
        {

            var estrenosFiltrados = listaOriginal.Where(estreno => estreno.Title != null && estreno.Title.ToLower().Contains(pPalabra) ||
            (estreno.Overview != null && estreno.Overview.ToLower().Contains(pPalabra))).ToList();


            if (estrenosFiltrados.Count == 0)
            {
                await DisplayAlert("Aviso", "No se encontraron estrenos de peliculas con esta palabra: " + pPalabra, "OK");
            }

            EstrenosList.ItemsSource = estrenosFiltrados;
        }
    }

    

}

