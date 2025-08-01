namespace obligatorioMauiEFyCS;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void IrARegistro_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Registro());
    }
}