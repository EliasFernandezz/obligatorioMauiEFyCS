using obligatorioMauiEFyCS.Service;
using obligatorioMauiEFyCS.DB_Models;
using Microsoft.Extensions.DependencyInjection;
namespace obligatorioMauiEFyCS;



public partial class Registro : ContentPage
{

    private readonly AuthService _authService;
    private byte[] fotoAGuardar;

    public Registro()
	{
		InitializeComponent();
        _authService = new AuthService();
    }

    private void VolverALogin_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync(); 
    }

    private async void btnTomarElegirFoto_Clicked(object sender, EventArgs e)
    {
        string action = await DisplayActionSheet("Selecciona una opción", "Cancelar", null, "Tomar foto", "Seleccionar de la galería");

        try
        {
            FileResult? foto = null;
            if (action == "Tomar foto")
            {
                foto = await MediaPicker.CapturePhotoAsync();
            }
            else if (action == "Seleccionar de la galería")
            {
                foto = await MediaPicker.PickPhotoAsync();
            }
            if (foto != null)
            {
                var stream = await foto.OpenReadAsync();
                fotoAGuardar = await ConvertStreamToByteArray(stream);

                // Aquí puedes procesar el stream como desees
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("ERROR", "Error al abrir la cámara o galería", "Cerrar");
        }
    }

    private async Task<byte[]> ConvertStreamToByteArray(Stream stream)
    {
        using (var memoryStream = new MemoryStream())
        {
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray(); // Devuelve el arreglo de bytes
        }
    }

    private async void btnRegistrarse_Clicked(object sender, EventArgs e)
    {
        try
        {
            var usuario = new Usuario
            {
                Nickname = NicknameEntry.Text,
                Contrasena = ContrasenaEntry.Text,
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Direccion = DireccionEntry.Text,
                Telefono = int.Parse(TelefonoEntry.Text),
                Email = EmailEntry.Text,
                FotoPerfil = fotoAGuardar
            };
            await _authService.RegistroUsuarioAsync(usuario);

            Preferences.Set($"{NicknameEntry}_prefVerClima", true);
            Preferences.Set($"{NicknameEntry}_prefVerNoticias", true);
            Preferences.Set($"{NicknameEntry}_prefVerCotizaciones", true);
            Preferences.Set($"{NicknameEntry}_prefVerCine", true);
            Preferences.Set($"{NicknameEntry}_prefVerPatrocinadores", true);
            Preferences.Set($"{NicknameEntry}_prefGestionarPatrocinadores", true);
        }
        catch (Exception ex)
        {
            Preferences.Remove($"{NicknameEntry}_prefVerClima");
            Preferences.Remove($"{NicknameEntry}_prefVerNoticias");
            Preferences.Remove($"{NicknameEntry}_prefVerCotizaciones");
            Preferences.Remove($"{NicknameEntry}_prefVerCine");
            Preferences.Remove($"{NicknameEntry}_prefVerPatrocinadores");
            Preferences.Remove($"{NicknameEntry}_prefGestionarPatrocinadores");

            await DisplayAlert("Error", "Los datos ingresados son invalidos", "Cerrar");
        }
    }
}