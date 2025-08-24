using SQLite;
using obligatorioMauiEFyCS.Service;

namespace obligatorioMauiEFyCS
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            byte[] fotoPerfil = SesionUsuario.Instance.FotoPerfil;
            string nickname = SesionUsuario.Instance.Nickname;

            lblBienvenida.Text = $"¡Hola {nickname}! disfruta de los servicios que se ofrecen en esta aplicacion ";

            if (fotoPerfil != null)
            {
                // Convertir el byte[] a una imagen y asignarla al Image
                var sourceImg = ImageSource.FromStream(() => new MemoryStream(fotoPerfil));
                imgFotoPerfil.Source = sourceImg;
            }
            else
            {
                imgFotoPerfil.Source = "foto_perfil_por_defecto.png"; // Imagen por defecto si no hay foto
            }
        }

        private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            SesionUsuario.Instance.Nickname = null;
            SesionUsuario.Instance.FotoPerfil = null;

            await Shell.Current.GoToAsync("//Login");
        }
    }

}
