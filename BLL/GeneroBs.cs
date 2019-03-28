using System.Collections.Generic;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class GeneroBs
    {
        private GeneroBd obj;

        public GeneroBs()
        {
            obj = new GeneroBd();
        }

        public async Task<IEnumerable<Genero>> Todos()
        {
            return await obj.Todos();
        }

        public async Task<Genero> ObtenerPorId(int id)
        {
            return await obj.ObtenerPorId(id);
        }

        public async Task Agregar(Genero Genero)
        {
            await obj.Agregar(Genero);
        }

        public async Task Actualizar(Genero Genero)
        {
            await obj.Actualizar(Genero);
        }

        public async Task Eliminar(int id)
        {
            await obj.Eliminar(id);
        }
    }
}
