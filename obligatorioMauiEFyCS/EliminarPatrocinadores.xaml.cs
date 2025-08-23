using obligatorioMauiEFyCS.ServicioPatrocinador;
using obligatorioMauiEFyCS.Models;
namespace obligatorioMauiEFyCS;

public partial class EliminarPatrocinadores : ContentPage
{
    private PatrocinadorService _service;
    public EliminarPatrocinadores()
    {
        InitializeComponent();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "patrocinadores.db");
        _service = new PatrocinadorService(dbPath);
    }

    public async void OnClickEliminarPatrocinador(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(idPatrocinador.Text, out int id))
            {
                await DisplayAlert("Error", "ID inválido", "Cerrar");
                return;
            }

            var patrocinador = new Models.PatrocinadoresModel { id = id };


            await _service.EliminarPatrocinador(patrocinador);

            await DisplayAlert("Éxito", "Patrocinador eliminado correctamente", "OK");

            //limpiar campos
            idPatrocinador.Text = string.Empty;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", " No se pudo eliminar el patrocinador: " + ex.Message, "Cerrar");
        }
    }
}
