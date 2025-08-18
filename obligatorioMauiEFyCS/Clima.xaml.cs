using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;

namespace obligatorioMauiEFyCS;

public partial class Clima : ContentPage
{
	public Clima()
	{
		InitializeComponent();
		Task cargandoClima = CargarClimaActual();
        Task cargandoClimasProximos = CargarPronosticoProximoCincoDias();
    }

	public async Task CargarClimaActual()
	{
		string url = "https://api.openweathermap.org/data/2.5/weather?q=Punta del este&appid=ceea5ffdf81af36eb39e91d7e341a4d1&units=metric&lang=es";

		using (HttpClient client = new HttpClient())
		{
			string json = await client.GetStringAsync(url);
			var datos = ClimaSerializado.FromJson(json);

            ciudadLabel.Text = datos.Name;
            temperaturaLabel.Text = $"{datos.Main.Temp:F1}°C"; //F1 es un formato para que el numero se muestre fijo es decir 8.8 indica q solo 1 decimal se muestra
            descripcionLabel.Text = datos.Weather[0].Description;
            // Construir la URL del ícono
            string iconoUrl = $"http://openweathermap.org/img/wn/{datos.Weather[0].Icon}@2x.png";

            // Asignar al Image
            iconoImagen.Source = ImageSource.FromUri(new Uri(iconoUrl));
        }

	}

    public async Task CargarPronosticoProximoCincoDias()
    {
        string url = "https://api.openweathermap.org/data/2.5/forecast?q=Punta del Este&appid=ceea5ffdf81af36eb39e91d7e341a4d1&units=metric&lang=es";

        using (HttpClient client = new HttpClient())
    	{
            
            string json = await client.GetStringAsync(url);
            var datos = JsonConvert.DeserializeObject<ForecastWrapper>(json);

            var listaDeClimasAproximados = datos.List
                .Where(c => c.Weather != null && c.Weather.Length > 0)
                .GroupBy(c => DateTimeOffset.FromUnixTimeSeconds(c.Dt).Date)
                .Select(p => new { pronostico = p.First(), fecha = DateTimeOffset.FromUnixTimeSeconds(p.First().Dt).DateTime.ToString("dd/MM/yyyy"),
                dia = DateTimeOffset.FromUnixTimeSeconds(p.First().Dt).DateTime.ToString("dddd", new CultureInfo("es-ES"))}).Take(5);

            listaPronosticoProximosDias.ItemsSource = listaDeClimasAproximados;

        }
    }
}