using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BOL
{
    public class CorreoUnico : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HtmlHelperDbEntities db = new HtmlHelperDbEntities();
            string emailValor = (string)value;
            int count = db.Usuario.Where(x => x.Email == emailValor).ToList().Count();
            if (count != 0)
                return new ValidationResult("Ya existe un usuario con ese correo electrónico");
            return ValidationResult.Success;
        }
    }

    public class UsuarioValidacion
    {
        [CorreoUnico]
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Contra { get; set; }
        [Required(ErrorMessage = "Tiene que confirmar la contraseña.")]
        [DisplayName("Confirmar contraseña")]
        [Compare("Contra", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarContra { get; set; }
    }

    [MetadataType(typeof(UsuarioValidacion))]
    public partial class Usuario
    {
        public string ConfirmarContra { get; set; }
    }
}
