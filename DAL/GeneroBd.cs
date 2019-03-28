using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class GeneroBd : EntidadBase
    {
        public async Task<IEnumerable<Genero>> Todos()
        {
            return await db.Genero.ToListAsync();
        }

        public async Task<Genero> ObtenerPorId(int id)
        {
            return await db.Genero.FindAsync(id);
        }


        public async Task Agregar(Genero Genero)
        {
            db.Genero.Add(Genero);
            await db.SaveChangesAsync();
        }

        public async Task Actualizar(Genero Genero)
        {
            db.Entry(Genero).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var Genero = await db.Genero.FindAsync(id);
            db.Genero.Remove(Genero);
            await db.SaveChangesAsync();
        }
    }
}
