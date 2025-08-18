using obligatorioMauiEFyCS.Service;
using obligatorioMauiEFyCS.DB_Models;
using Microsoft.Extensions.DependencyInjection;


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
}