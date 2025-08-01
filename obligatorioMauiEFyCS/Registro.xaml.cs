namespace obligatorioMauiEFyCS;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}

    private void VolverALogin_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync(); 
    }
}