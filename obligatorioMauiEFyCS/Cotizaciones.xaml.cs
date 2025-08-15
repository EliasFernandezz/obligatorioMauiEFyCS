using Newtonsoft.Json;
using obligatorioMauiEFyCSCotizaciones;

namespace obligatorioMauiEFyCS;

public partial class Cotizaciones : ContentPage
{
    public Cotizaciones()
    {
        InitializeComponent();
        CargarCotizacionesAsync();
    }

    CotizacionesModel? cotizaciones;
    public async void CargarCotizacionesAsync()
    {
        string url = "http://apilayer.net/api/live?access_key=298b719d8db2a209fba8081cebee3440&currencies=UYU,EUR,BRL&source=USD&format=1";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert("Error", "No se pudo obtener las cotizaciones.", "OK");
            }

            else
            {
                var json = await response.Content.ReadAsStringAsync();
                cotizaciones = JsonConvert.DeserializeObject<CotizacionesModel>(json);

                double usdUYU = cotizaciones.Quotes["USDUYU"];
                double usdEUR = cotizaciones.Quotes["USDEUR"];
                double usdBRL = cotizaciones.Quotes["USDBRL"];

                usdUYU = Math.Round(usdUYU, 2);
                double brlUYU = Math.Round(usdUYU / usdBRL, 2);
                double eurUYU = Math.Round(usdUYU / usdEUR, 2);

                lblCotizacionDolar.Text += usdUYU;
                lblCotizacionEuro.Text += eurUYU;
                lblCotizacionReal.Text += brlUYU;
            }
        }
    }
}