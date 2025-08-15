using Newtonsoft.Json;
using obligatorioMauiEFyCSNoticias;
using System.Threading.Tasks;

namespace obligatorioMauiEFyCS;

public partial class Noticias : ContentPage
{
    public Noticias()
    {
        InitializeComponent();

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            gridNoticias.RowDefinitions.Clear();
            gridNoticias.ColumnDefinitions.Clear();
            for (int i = 0; i < 6; i++)
            {
                gridNoticias.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            gridNoticias.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            frameNoticia1.SetValue(Grid.RowProperty, 0);
            frameNoticia1.SetValue(Grid.ColumnProperty, 0);

            frameNoticia2.SetValue(Grid.RowProperty, 1);
            frameNoticia2.SetValue(Grid.ColumnProperty, 0);

            frameNoticia3.SetValue(Grid.RowProperty, 2);
            frameNoticia3.SetValue(Grid.ColumnProperty, 9);

            frameNoticia4.SetValue(Grid.RowProperty, 3);
            frameNoticia4.SetValue(Grid.ColumnProperty, 0);

            frameNoticia5.SetValue(Grid.RowProperty, 4);
            frameNoticia5.SetValue(Grid.ColumnProperty, 9);

            frameNoticia6.SetValue(Grid.RowProperty, 5);
            frameNoticia6.SetValue(Grid.ColumnProperty, 0);
        }
        else
        {
            gridNoticias.RowDefinitions.Clear();
            gridNoticias.ColumnDefinitions.Clear();
            for (int i = 0; i < 2; i++)
            {
                gridNoticias.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int j = 0; j < 3; j++)
            {
                gridNoticias.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            frameNoticia1.SetValue(Grid.RowProperty, 0);
            frameNoticia1.SetValue(Grid.ColumnProperty, 0);

            frameNoticia2.SetValue(Grid.RowProperty, 0);
            frameNoticia2.SetValue(Grid.ColumnProperty, 1);

            frameNoticia3.SetValue(Grid.RowProperty, 0);
            frameNoticia3.SetValue(Grid.ColumnProperty, 2);

            frameNoticia4.SetValue(Grid.RowProperty, 1);
            frameNoticia4.SetValue(Grid.ColumnProperty, 0);

            frameNoticia5.SetValue(Grid.RowProperty, 1);
            frameNoticia5.SetValue(Grid.ColumnProperty, 1);

            frameNoticia6.SetValue(Grid.RowProperty, 1);
            frameNoticia6.SetValue(Grid.ColumnProperty, 2);
        }

        CargarNoticiasAsync();
    }

    NoticiasModel? noticias;
    public async void CargarNoticiasAsync()
    {
        string url = "https://newsdata.io/api/1/latest?apikey=pub_1edc0dcb4e2d42189bd67947c6937530&country=uy&language=es&image=1";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert("Error", "No se pudo obtener las noticias.", "OK");
            }

            else
            {
                var json = await response.Content.ReadAsStringAsync();
                noticias = JsonConvert.DeserializeObject<NoticiasModel>(json);

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

    private async void TapGestureRecognizer_Enlace1(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(noticias.Results[0].SourceUrl, BrowserLaunchMode.SystemPreferred);
    }

    private async void TapGestureRecognizer_Enlace2(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(noticias.Results[1].SourceUrl, BrowserLaunchMode.SystemPreferred);
    }

    private async void TapGestureRecognizer_Enlace3(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(noticias.Results[2].SourceUrl, BrowserLaunchMode.SystemPreferred);
    }

    private async void TapGestureRecognizer_Enlace4(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(noticias.Results[3].SourceUrl, BrowserLaunchMode.SystemPreferred);
    }

    private async void TapGestureRecognizer_Enlace5(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(noticias.Results[4].SourceUrl, BrowserLaunchMode.SystemPreferred);
    }

    private async void TapGestureRecognizer_Enlace6(object sender, TappedEventArgs e)
    {
        await Browser.Default.OpenAsync(noticias.Results[5].SourceUrl, BrowserLaunchMode.SystemPreferred);
    }
}