using System.ComponentModel.DataAnnotations;

namespace integradora555.Models;

public class Cliente
{
    [Key]
    public int clienteId { get; set; }
    [Display(Name ="Nombre")]
    [RegularExpression(@"[A-Z\s]*$",ErrorMessage = "SE ADMITEN SOLO MAYUSCULA Y ESPACIO")]
    [MaxLength(25, ErrorMessage = "El nombre es muy largo")]
    [Required(ErrorMessage = "inserte el nombre ")]
    public string Nombre { get; set; }
    [Display(Name ="Apellido")]
    [RegularExpression(@"[A-Z]*$", ErrorMessage ="ESCRIBIR EN MAYUSCULA Y SIN ESPACIO")]
    [MaxLength(15,ErrorMessage ="El apellido muy largo")]
    [Required(ErrorMessage = "inserte el apellido")]
    public string Apellido { get; set; }
    [Display(Name ="documento de identidad nacional")]
    [RegularExpression(@"[0-9\d]*$", ErrorMessage ="CARACTERES ADMITIDOS(0-1-2-3-4-5-6-7-8-9)")]
    [Required(ErrorMessage = "inserte el numero de DNI")]
    public int Dni { get; set; }
    [Display(Name = "Fecha")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "inserte la fecha ")]
    public DateTime FechaDeNacimiento { get; set; }


}
