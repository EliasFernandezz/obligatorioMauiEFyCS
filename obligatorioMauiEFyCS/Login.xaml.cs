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

    private async void IrARegistro_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Registro");
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

            if (esLoginValido == true)
            {
                _authService.LoginUsuarioAsync(usuario);
                await Shell.Current.GoToAsync("//MainPage");
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