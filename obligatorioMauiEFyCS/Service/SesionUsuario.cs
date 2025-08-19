namespace obligatorioMauiEFyCS.Service
{
    internal class SesionUsuario
    {
        private static SesionUsuario _instance;
        public static SesionUsuario Instance => _instance ??= new SesionUsuario();
        public string Nickname { get; set; }

        public byte[] FotoPerfil { get; set; }
        private SesionUsuario() { }
    }
}
