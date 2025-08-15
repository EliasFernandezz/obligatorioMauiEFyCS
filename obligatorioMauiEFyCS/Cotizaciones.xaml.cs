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

                decimal usdUYU = Convert.ToDecimal(cotizaciones.Quotes["USDUYU"]);
                decimal usdEUR = Convert.ToDecimal(cotizaciones.Quotes["USDEUR"]);
                decimal usdBRL = Convert.ToDecimal(cotizaciones.Quotes["USDBRL"]);

                decimal brlUYU = usdUYU / usdBRL;               //En estas lineas, se calcula manualmente la cotizacion del real y el euro frente al peso uruguayo porque no se puede obtener directamente desde la API.
                decimal eurUYU = usdUYU / usdEUR;

                lblCotizacionDolar.Text += usdUYU;
                lblCotizacionEuro.Text += eurUYU;
                lblCotizacionReal.Text += brlUYU;
            }
        }
    }
}