using obligatorioMauiEFyCS.DB_Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioMauiEFyCS.Service
{
    class AuthService
    {
        private readonly SQLiteAsyncConnection dbConexion;
        public AuthService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "baseDeDatos.db");
            dbConexion = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitializeDatabaseAsync()
        {
            await dbConexion.CreateTableAsync<Usuario>();
            await dbConexion.CreateTableAsync<Patrocinador>();
        }




        public async Task RegistroUsuarioAsync(Usuario usuario)
        {
            await dbConexion.InsertAsync(usuario);
        }


        public void LoginUsuarioAsync(Usuario usuario)
        {
            SesionUsuario.Instance.Nickname = usuario.Nickname;
            SesionUsuario.Instance.FotoPerfil = usuario.FotoPerfil;
        }

        public async Task<bool> EsLoginUsuarioValidoAsync(Usuario usuario)
        {
            var user = await dbConexion.Table<Usuario>().FirstOrDefaultAsync(u => u.Nombre == usuario.Nombre || u.Contrasena == usuario.Contrasena);

            if(user == null) return false;

            else return true;
        }
    }
}
