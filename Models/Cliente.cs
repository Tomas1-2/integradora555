using System.ComponentModel.DataAnnotations;

namespace integradora555.Models;

public class Cliente
{
    [Key]
    public int clienteId { get; set; }
    [Display(Name ="Nombre")]
    [RegularExpression(@"[A-Z\s]*$",ErrorMessage = "SE ADMITEN SOLO MAYUSCULA Y ESPACIO")]
    [MaxLength(25, ErrorMessage = "flaco cambia el nombre porque es muy largo")]
    [Required(ErrorMessage = "inserte el nombre que le ah dado su madre")]
    public string Nombre { get; set; }
    [Display(Name ="Apellido")]
    [RegularExpression(@"[A-Z]*$", ErrorMessage ="ESCRIBI EN MAYUSCULA Y SIN ESPACIO")]
    [MaxLength(15,ErrorMessage ="flaco cambia el apellido porque tambien muy largo")]
    [Required(ErrorMessage = "inserte el apellido que ah obtenido de su padre")]
    public string Apellido { get; set; }
    [Display(Name ="documento de identidad nacional")]
    [RegularExpression(@"[0-9\d]*$", ErrorMessage ="CARACTERES ADMITIDOS(0-1-2-3-4-5-6-7-8-9)")]
    [Required(ErrorMessage = "inserte el numero de individuo que el gobierno le ah otorgado")]
    public int Dni { get; set; }
    [Display(Name = "dia en la que llego al mundo a sufrir")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "inserte la fecha en la que usted ah salido del vientre")]
    public DateTime FechaDeNacimiento { get; set; }


}
