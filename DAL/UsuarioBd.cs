using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class UsuarioBd: EntidadBase
    {
        public async Task<IEnumerable<Usuario>> Todos()
        {
            return await db.Usuario.ToListAsync();
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            return await db.Usuario.FindAsync(id);
        }

        public async Task Agregar(Usuario Usuario)
        {
            db.Usuario.Add(Usuario);
            await db.SaveChangesAsync();
        }

        public async Task Actualizar(Usuario Usuario)
        {
            db.Entry(Usuario).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var Usuario = await db.Usuario.FindAsync(id);
            db.Usuario.Remove(Usuario);
            await db.SaveChangesAsync();
        }
    }
}
