using System.Collections.Generic;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class PersonaBs
    {
        private PersonaBd obj;

        public PersonaBs()
        {
            obj = new PersonaBd();
        }

        public async Task<IEnumerable<Persona>> Todos()
        {
            return await obj.Todos();
        }

        public async Task<Persona> ObtenerPorId(int id)
        {
            return await obj.ObtenerPorId(id);
        }

        public async Task Agregar(Persona Persona)
        {
           await obj.Agregar(Persona);
        }

        public async Task Actualizar(Persona Persona)
        {
           await obj.Actualizar(Persona);
        }

        public async Task Eliminar(int id)
        {
            await obj.Eliminar(id);
        }
    }
}
