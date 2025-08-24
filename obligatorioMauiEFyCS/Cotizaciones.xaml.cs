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
        string ultimaFecha = Preferences.Get("ultimaCotizacionDiaria", "");

        if (ultimaFecha == DateTime.Today.ToString("yyyy-MM-dd"))
        {
            double usdUYU = Preferences.Get("dolar_peso", 0.0);
            double eurUYU = Preferences.Get("euro_peso", 0.0);
            double brlUYU = Preferences.Get("real_peso", 0.0);

            lblCotizacionDolar.Text += "$ " + usdUYU;
            lblCotizacionEuro.Text += "$ " + eurUYU;
            lblCotizacionReal.Text += "$ " + brlUYU;
        }
        else
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
                    double eurUYU = Math.Round(usdUYU / usdEUR, 2);
                    double brlUYU = Math.Round(usdUYU / usdBRL, 3);

                    lblCotizacionDolar.Text += "$ " + usdUYU;
                    lblCotizacionEuro.Text += "$ " + eurUYU;
                    lblCotizacionReal.Text += "$ " + brlUYU;



                    Preferences.Set("ultimaCotizacionDiaria", DateTime.Today.ToString("yyyy-MM-dd"));
                    Preferences.Set("dolar_Peso", usdUYU);
                    Preferences.Set("euro_Peso", eurUYU);
                    Preferences.Set("real_Peso", brlUYU);
                }
            }
        }

    }
}