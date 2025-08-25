using obligatorioMauiEFyCS.Service;

namespace obligatorioMauiEFyCS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            mostrarSecciones();

            if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
            {
                    scGeolocalizacion.IsVisible = false;
            }
        }

        public void mostrarSecciones()
        {
            bool verClima = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerClima", true);
            bool verNoticias = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerNoticias", true);
            bool verCotizaciones = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerCotizaciones", true);
            bool verCine = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefVerCine", true);
            bool patrocinadores = Preferences.Get($"{SesionUsuario.Instance.Nickname}_prefPatrocinadores", true);

            fyClima.IsVisible = verClima;
            fyNoticias.IsVisible = verNoticias;
            fyCotizaciones.IsVisible = verCotizaciones;
            fyCine.IsVisible = verCine;
            fyPatrocinadores.IsVisible = patrocinadores;

        }
    }
}
