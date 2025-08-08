using Newtonsoft.Json;

namespace obligatorioMauiEFyCS;

public partial class Noticias : ContentPage
{
    public Noticias()
    {
        InitializeComponent();

        CargarNoticiasAsync();
    }

    public async void CargarNoticiasAsync()
    {
        string url = "https://newsdata.io/api/1/latest?apikey=pub_1edc0dcb4e2d42189bd67947c6937530&country=uy&language=es&image=1";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert("Error", "No se pudo obtener el clima.", "OK");
            }

            else
            {
                var json = await response.Content.ReadAsStringAsync();
                var noticias = JsonConvert.DeserializeObject<NoticiasModel>(json);
            }
        }


    }
}