
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Globalization;

namespace obligatorioMauiEFyCS;
public partial class VerPatrocinadoresMapa : ContentPage
{
	public VerPatrocinadoresMapa()
	{
		InitializeComponent();

        //var posicion = new Location(-34.9011, -56.1645); // Montevideo, Uruguay
        //var region = MapSpan.FromCenterAndRadius(posicion, Distance.FromKilometers(3));
        //MyMap.MoveToRegion(region);

        //MyMap.Pins.Add(new Pin
        //{
        //    Label = "Montevideo",
        //    Address = "Uruguay",
        //    Type = PinType.Place,
        //    Location = posicion
        //});

        //var circle = new Circle
        //{
        //    Center = new Location(-34.9011, -56.1645),
        //    Radius = new Distance(2500),
        //    StrokeColor = Color.FromArgb("#88FF0000"),
        //    StrokeWidth = 8,
        //    FillColor = Color.FromArgb("#88FFC0CB")
        //};

        //MyMap.MapElements.Add(circle);
    }


}