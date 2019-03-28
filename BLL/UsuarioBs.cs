using System.Collections.Generic;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class UsuarioBs
    {
        private UsuarioBd obj;

        public UsuarioBs()
        {
            obj = new UsuarioBd();
        }

        public async Task<IEnumerable<Usuario>> Todos()
        {
            return await obj.Todos();
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            return await obj.ObtenerPorId(id);
        }

        public async Task Agregar(Usuario Usuario)
        {
            obj.Agregar(Usuario);
        }

        public async Task Actualizar(Usuario Usuario)
        {
            obj.Actualizar(Usuario);
        }

        public async Task Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
