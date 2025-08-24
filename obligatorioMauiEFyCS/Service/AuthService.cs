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
            SesionUsuario.Instance.Nickname = usuario.Nickname;
            SesionUsuario.Instance.FotoPerfil = usuario.FotoPerfil;
        }


        public void LoginUsuarioAsync(Usuario usuario)
        {
            SesionUsuario.Instance.Nickname = usuario.Nickname;
        }

        public async Task<bool> EsLoginUsuarioValidoAsync(Usuario usuario)
        {
            var user = await dbConexion.Table<Usuario>().FirstOrDefaultAsync(u => u.Nickname == usuario.Nickname && u.Contrasena == usuario.Contrasena);

            if(user == null) return false;

            else
            {
                SesionUsuario.Instance.FotoPerfil = user.FotoPerfil;
                return true;
            }
                
        }

        public async Task<bool> LoginUsuarioHuellaAsync()
        {
            var primerUsuario = await dbConexion.Table<Usuario>().FirstOrDefaultAsync();
            if (primerUsuario != null)
            {
                SesionUsuario.Instance.Nickname = primerUsuario.Nickname;
                return true;
            }
            else return false;
        }
    }
}
