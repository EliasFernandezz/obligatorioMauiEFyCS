using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace obligatorioMauiEFyCS.ServicioPatrocinador
{
     public class PatrocinadorService
     {
        private readonly SQLiteAsyncConnection _db;
        public PatrocinadorService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Models.PatrocinadoresModel>().Wait();
        }

        public Task<List<Models.PatrocinadoresModel>>GetPatrocinadores()
        {
            return _db.Table<Models.PatrocinadoresModel>().ToListAsync();
        }

        public Task<int> CrearPatrocinador(Models.PatrocinadoresModel patrocinador)
        {
            return _db.InsertAsync(patrocinador);
        }

        public Task<int> EliminarPatrocinador(Models.PatrocinadoresModel patrocinador)
        {
            return _db.DeleteAsync(patrocinador);
        }
    }
}
