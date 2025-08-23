using obligatorioMauiEFyCS.Models;
using obligatorioMauiEFyCS.ServicioPatrocinador;

namespace obligatorioMauiEFyCS;

public partial class GestionarPatrocinadores : ContentPage
{
    private PatrocinadorService _service;
    public GestionarPatrocinadores()
    {
        InitializeComponent();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "patrocinadores.db");
        _service = new PatrocinadorService(dbPath);

    }

    public async void OnClickCrearPatrocinador(object sender, EventArgs e)
    {
        try
        {
            var patrocinador = new Models.PatrocinadoresModel
            {
                nombre = nombrePatrocinador.Text,
                logo = iconoDelPatrocinador.Text,
                direccion = ubicacionDelPatrocinador.Text
            };

            await _service.CrearPatrocinador(patrocinador);

            await DisplayAlert("Éxito", "Patrocinador creado correctamente", "OK");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", " No se pudo crear el patrocinador: " + ex.Message, "Cerrar");
        }
    }
}
