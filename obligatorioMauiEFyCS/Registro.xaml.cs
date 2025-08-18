using obligatorioMauiEFyCS.Service;
using obligatorioMauiEFyCS.DB_Models;
using Microsoft.Extensions.DependencyInjection;
namespace obligatorioMauiEFyCS;



public partial class Registro : ContentPage
{

    private readonly AuthService _authService;

    public Registro()
	{
		InitializeComponent();
        _authService = new AuthService();
    }

    private void VolverALogin_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync(); 
    }

    private void btnTomarFoto_Clicked(object sender, EventArgs e)
    {

    }

    private void btnElegirFoto_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnRegistrarse_Clicked(object sender, EventArgs e)
    {
        var usuario = new Usuario
        {
            nickname = NicknameEntry.Text,
            Contrasena = ContrasenaEntry.Text,
            Nombre = NombreEntry.Text,
            Apellido = ApellidoEntry.Text,
            Direccion = DireccionEntry.Text,
            Telefono = int.Parse(TelefonoEntry.Text),
            Email = EmailEntry.Text,
            fotoPerfil = null // Aquí deberías asignar la foto seleccionada o tomada
        };
        var resultado = await _authService.RegistroUsuarioAsync(usuario);
    }
}