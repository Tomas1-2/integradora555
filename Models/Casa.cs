using System.ComponentModel.DataAnnotations;

namespace integradora555.Models;

public class Casa
{
    [Key]
    public int CasaId { get; set; }

    [Display(Name = "Nombre")]
    [Required(ErrorMessage = "Es necesario saber el nombre")]
    [MaxLength(30, ErrorMessage = "Su nombre es demasiado largo")]
    [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "SE ADMITEN SOLO MAYUSCULA Y ESPACIO")]
    public string? NombreDeCasa { get; set; }

    [Display(Name = "Direccion")]
    [Required(ErrorMessage = "Escribie la calle y numero ")]
    [MaxLength(40, ErrorMessage = "Su direccion es demasiado larga")]
    [RegularExpression(@"[A-Z\s\d]*$", ErrorMessage = "ACA ESCRIBI EN MAYUSCULA QUE LO DEMAS SE VALE TODO")]
    public string? domicilio { get; set; }

    [Display(Name = "Nombre del dueño de casa")]
    [Required(ErrorMessage = "Es necesario saber el nombre del dueño del hogar")]
    [MaxLength(20, ErrorMessage = "Señor/a su nombre es demasado largo")]
    [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "SOLO SON ADMICIBLE MAYUSCULA Y ESPACIO ")]
    public string? NombreDueño { get; set; }

    public byte[]? imagenDeCasa { get; set; }

    public bool alquilada { get; set; }

    public bool eliminada { get; set; }








}
