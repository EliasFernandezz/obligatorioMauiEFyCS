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

                tituloNoticia1.Text = noticias.Results[0].Title;
                tituloNoticia2.Text = noticias.Results[1].Title;
                tituloNoticia3.Text = noticias.Results[2].Title;
                tituloNoticia4.Text = noticias.Results[3].Title;
                tituloNoticia5.Text = noticias.Results[4].Title;
                tituloNoticia6.Text = noticias.Results[5].Title;

                imagenNoticia1.Source = noticias.Results[0].ImageUrl;
                imagenNoticia2.Source = noticias.Results[1].ImageUrl;
                imagenNoticia3.Source = noticias.Results[2].ImageUrl;
                imagenNoticia4.Source = noticias.Results[3].ImageUrl;
                imagenNoticia5.Source = noticias.Results[4].ImageUrl;
                imagenNoticia6.Source = noticias.Results[5].ImageUrl;

                descripcionNoticia1.Text = noticias.Results[0].Description;
                descripcionNoticia2.Text = noticias.Results[1].Description;
                descripcionNoticia3.Text = noticias.Results[2].Description;
                descripcionNoticia4.Text = noticias.Results[3].Description;
                descripcionNoticia5.Text = noticias.Results[4].Description;
                descripcionNoticia6.Text = noticias.Results[5].Description;

            }
        }

    }
}