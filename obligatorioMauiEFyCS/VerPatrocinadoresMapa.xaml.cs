using Microsoft.Maui.Devices.Sensors; // Para Location
using Microsoft.Maui.Graphics;
using obligatorioMauiEFyCS.ServicioPatrocinador;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;


namespace obligatorioMauiEFyCS;

public partial class VerPatrocinadoresMapa : ContentPage
{
	public VerPatrocinadoresMapa()
	{
		InitializeComponent();
        var posicionInicial = new Location(-34.9011, -56.1645); // Montevideo
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(posicionInicial, Distance.FromKilometers(3)));

        var pinInicial = new Pin
        {
            Label = "Montevideo",
            Address = "Uruguay",
            Type = PinType.Place,
            Location = posicionInicial
        };
        MyMap.Pins.Add(pinInicial);
    }

    private async void MyMap_MapClicked(object sender, MapClickedEventArgs e)
    {
        // Creamos directamente Location a partir de las coordenadas
        var ubicacionSeleccionada = new Location(e.Location.Latitude, e.Location.Longitude);

        // Limpiar pins y elementos anteriores
        MyMap.Pins.Clear();
        MyMap.MapElements.Clear();

        // Crear pin en la ubicación seleccionada
        var pin = new Pin
        {
            Label = "Ubicación seleccionada",
            Address = $"Lat: {ubicacionSeleccionada.Latitude}, Lon: {ubicacionSeleccionada.Longitude}",
            Type = PinType.Place,
            Location = ubicacionSeleccionada
        };
        MyMap.Pins.Add(pin);

        // Crear círculo alrededor del pin
        var circle = new Circle
        {
            Center = ubicacionSeleccionada,
            Radius = new Distance(250), // metros
            StrokeColor = Colors.Red,
            StrokeWidth = 4,
            FillColor = Color.FromArgb("#88FFC0CB")
        };
        MyMap.MapElements.Add(circle);

        // Centrar el mapa en la ubicación seleccionada
        MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(ubicacionSeleccionada, Distance.FromKilometers(1)));

        // Enviar la ubicación a la página de gestión
        MessagingCenter.Send(this, "UbicacionSeleccionada", ubicacionSeleccionada);

        // Mensaje opcional
        await DisplayAlert("Ubicación seleccionada",
            $"Lat: {ubicacionSeleccionada.Latitude}, Lon: {ubicacionSeleccionada.Longitude}", "OK");

        // Volver a la página de gestión
        await Navigation.PopAsync();
    }
}
