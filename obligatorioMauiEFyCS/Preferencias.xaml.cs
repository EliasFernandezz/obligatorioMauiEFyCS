using obligatorioMauiEFyCS.Service;

namespace obligatorioMauiEFyCS;

public partial class Preferencias : ContentPage
{
	public Preferencias()
	{
		InitializeComponent();
        CargarPreferencias();
    }

    private void CargarPreferencias()
    {
        bool verClima = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerClima", true);
        bool verNoticias = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerNoticias", true);
        bool verCotizaciones = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerCotizaciones", true);
        bool verCine = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerCine", true);
        bool verPatrocinadores = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerPatrocinadores", true);
        bool gestionarPatrocinadores = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefGestionarPatrocinadores", true);

        radioVerClimaSi.IsChecked = verClima;
        radioVerClimaNo.IsChecked = !verClima;

        radioVerNoticiasSi.IsChecked = verNoticias;
        radioVerNoticiasNo.IsChecked = !verNoticias;

        radioVerCotizacionesSi.IsChecked = verCotizaciones;
        radioVerCotizacionesNo.IsChecked = !verCotizaciones;

        radioVerCineSi.IsChecked = verCine;
        radioVerCineNo.IsChecked = !verCine;

        radioVerPatrocinadoresSi.IsChecked = verPatrocinadores;
        radioVerPatrocinadoresNo.IsChecked = !verPatrocinadores;

        radioGestionarPatrocinadoresSi.IsChecked = gestionarPatrocinadores;
        radioGestionarPatrocinadoresNo.IsChecked = !gestionarPatrocinadores;
    }


    private async void OnGuardarPreferenciasClicked(object sender, EventArgs e)
    {
        // Guardar preferencias en Preferences
        Preferences.Set($"{SesionUsuario.Instance.Nickname}_prefVerClima", radioVerClimaSi.IsChecked);
        Preferences.Set($"{SesionUsuario.Instance.Nickname}_prefVerNoticias", radioVerNoticiasSi.IsChecked);
        Preferences.Set($"{SesionUsuario.Instance.Nickname}_prefVerCotizaciones", radioVerCotizacionesSi.IsChecked);
        Preferences.Set($"{SesionUsuario.Instance.Nickname}_prefVerCine", radioVerCineSi.IsChecked);
        Preferences.Set($"{SesionUsuario.Instance.Nickname}_prefVerPatrocinadores", radioVerPatrocinadoresSi.IsChecked);
        Preferences.Set($"{SesionUsuario.Instance.Nickname}_prefGestionarPatrocinadores", radioGestionarPatrocinadoresSi.IsChecked);

        ((AppShell)Application.Current.MainPage).mostrarSecciones();
        await Shell.Current.GoToAsync("//MainPage");
    }
}