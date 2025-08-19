using obligatorioMauiEFyCS.Service;
using obligatorioMauiEFyCS.DB_Models;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


namespace obligatorioMauiEFyCS;


public partial class Login : ContentPage
{
	private readonly AuthService _authService;

    public Login()
	{
		InitializeComponent();
		_authService = new AuthService();
        InitializeDatabase();
    }

    private async void InitializeDatabase()
    {
        await _authService.InitializeDatabaseAsync();
    }

    private void IrARegistro_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Registro());
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            var usuario = new Usuario
            {
                Nickname = NicknameEntry.Text,
                Contrasena = ContrasenaEntry.Text
            };
            bool esLoginValido = await _authService.EsLoginUsuarioValidoAsync(usuario);

            if (esLoginValido)
            {
                await _authService.LoginUsuarioAsync(usuario);
                SesionUsuario.Instance.Nickname = usuario.Nickname;
                SesionUsuario.Instance.FotoPerfil = usuario.FotoPerfil;
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "Cerrar");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Los datos ingresados son invalidos", "Cerrar");
        }
    }
}