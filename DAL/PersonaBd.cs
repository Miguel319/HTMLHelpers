using BOL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonaBd : EntidadBase
    {
        public async Task<IEnumerable<Persona>> Todos()
        {
            return await db.Persona.ToListAsync();
        }

        public async Task<Persona> ObtenerPorId(int id)
        {
            return await db.Persona.FindAsync(id);
        }

        public async Task Agregar(Persona persona)
        {
            db.Persona.Add(persona);
            await db.SaveChangesAsync();
        }

        public async Task Actualizar(Persona persona)
        {
            db.Entry(persona).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var persona = await db.Persona.FindAsync(id);
            db.Persona.Remove(persona);
            await db.SaveChangesAsync();
        }
    }
}
