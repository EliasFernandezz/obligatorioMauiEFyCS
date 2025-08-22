using obligatorioMauiEFyCS.Service;

namespace obligatorioMauiEFyCS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            mostrarSecciones();
        }

        public void mostrarSecciones()
        {
            bool verClima = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerClima", true);
            bool verNoticias = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerNoticias", true);
            bool verCotizaciones = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerCotizaciones", true);
            bool verCine = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerCine", true);
            bool verPatrocinadores = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerPatrocinadores", true);
            bool gestionarPatrocinadores = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefGestionarPatrocinadores", true);

            fyClima.IsVisible = verClima;
            fyNoticias.IsVisible = verNoticias;
            fyCotizaciones.IsVisible = verCotizaciones;
            fyCine.IsVisible = verCine;

            fyPatrocinadores.IsVisible = gestionarPatrocinadores || verPatrocinadores;
            fyVerPatrocinadores.IsVisible = verPatrocinadores;
            fyGestionarPatrocinadores.IsVisible = gestionarPatrocinadores;
        }
    }
}
