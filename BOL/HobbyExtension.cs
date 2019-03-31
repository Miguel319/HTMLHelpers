using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class HobbyExtension
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Nullable<int> GeneroId { get; set; }
        public string EstadoCivil { get; set; }
        public string Hobbys { get; set; }

        public virtual Genero Genero { get; set; }

        public List<Hobby> Hobbies { get; set; }
    }
}
