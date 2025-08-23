using obligatorioMauiEFyCS.ServicioPatrocinador;

namespace obligatorioMauiEFyCS;

public partial class VerPatrocinadores : ContentPage
{
    private PatrocinadorService _service;
    public VerPatrocinadores()
    {

        InitializeComponent();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "patrocinadores.db");
        _service = new PatrocinadorService(dbPath);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await MostrarPatrocinadores(); // refresva la lista cada vez que se carga la pantalla asi la misma no se queda con solo datos viejos
    }

    public async Task MostrarPatrocinadores()
    {
        var lista = await _service.GetPatrocinadores();
        patrocinadoresListView.ItemsSource = lista;
    }


}