using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class HobbyBd : EntidadBase
    {
        public async Task<IEnumerable<Hobby>> Todos()
        {
            return await db.Hobby.ToListAsync();
        }

        public async Task<Hobby> ObtenerPorId(int id)
        {
            return await db.Hobby.FindAsync(id);
        }


        public async Task Agregar(Hobby Hobby)
        {
            db.Hobby.Add(Hobby);
            await db.SaveChangesAsync();
        }

        public async Task Actualizar(Hobby Hobby)
        {
            db.Entry(Hobby).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var Hobby = await db.Hobby.FindAsync(id);
            db.Hobby.Remove(Hobby);
            await db.SaveChangesAsync();
        }
    }
}
