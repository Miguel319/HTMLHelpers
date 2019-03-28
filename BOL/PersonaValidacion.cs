using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL
{
    public class EmailUnico : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HtmlHelperDbEntities db = new HtmlHelperDbEntities();

            var emailValor = (string) value;
            int unico = db.Persona.Where(x => x.Email == emailValor).ToList().Count();

            var retornar = (unico != 0)
                ? new ValidationResult("Ya hay una persona con este correo electrónico")
                : ValidationResult.Success;

            return retornar;
        }
    }

    public class PersonaValidacion
    {
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [DisplayName("Cédula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(15, 100, ErrorMessage = "La edad debe estar entre 15 y 100.")]
        public int Edad { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe introducir un correo electrónico.")]
        [EmailUnico(ErrorMessage = "Ya otro usuario con este mismo correo electrónico.")]
        public string Email { get; set; }
        [DisplayName("Género/sexo")]
        public Nullable<int> GeneroId { get; set; }
        [DisplayName("Estado civil")]
        public string EstadoCivil { get; set; }
        public string Hobbys { get; set; }
        public IEnumerable<Hobby> Hobbies { get; set; }
    }

    [MetadataType(typeof(PersonaValidacion))]
    public partial class Persona
    {
        public IEnumerable<Hobby> Hobbies { get; set; }
    }
}
