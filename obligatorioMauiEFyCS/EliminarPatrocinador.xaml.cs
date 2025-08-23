using obligatorioMauiEFyCS.ServicioPatrocinador;
namespace obligatorioMauiEFyCS;

public partial class EliminarPatrocinador : ContentPage
{
    private PatrocinadorService _service;
    public EliminarPatrocinador()
	{
		InitializeComponent();
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "patrocinadores.db");
        _service = new PatrocinadorService(dbPath);
    }

    public async void OnClickEliminarPatrocinador(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(idPatrocinador.Text))
            {
                await DisplayAlert("Error", " No se pudo eliminar el patrocinador id incorrecto", "Cerrar");
                return;
            }

            int id = int.Parse(idPatrocinador.Text);

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