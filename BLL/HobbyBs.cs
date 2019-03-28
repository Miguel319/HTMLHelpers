using System.Collections.Generic;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class HobbyBs
    {
        private HobbyBd obj;

        public HobbyBs()
        {
            obj = new HobbyBd();
        }

        public async Task<IEnumerable<Hobby>> Todos()
        {
            return await obj.Todos();
        }

        public async Task<Hobby> ObtenerPorId(int id)
        {
            return await obj.ObtenerPorId(id);
        }

        public async Task Agregar(Hobby hobby)
        {
            obj.Agregar(hobby);
        }

        public async Task Actualizar(Hobby hobby)
        {
            obj.Actualizar(hobby);
        }

        public async Task Eliminar(int id)
        {
            obj.Eliminar(id);
        }
    }
}
