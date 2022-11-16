using System.ComponentModel.DataAnnotations;

namespace integradora555.Models;

public class Casa
{
    [Key]
    public int CasaId { get; set; }

    [Display(Name = "nombre de tu albergue en el que desea pasar una larga y prospera vida")]
    [Required(ErrorMessage = "es necesario saber el nombre de tu posada")]
    [MaxLength(30, ErrorMessage = "su nombre es demasiado largo, por favor fijese como acortarlo")]
    [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "SE ADMITEN SOLO MAYUSCULA Y ESPACIO")]
    public string? NombreDeCasa { get; set; }

    [Display(Name = "Altura de tu vivienda..para mas informacion visite google maps,ARREGLESE")]
    [Required(ErrorMessage = "por favor escribi la calle y numero de tu cobija")]
    [MaxLength(40, ErrorMessage = "su direccion es demasiado larga, por favor mudece o achique su direccion para poder usar nuestra app")]
    [RegularExpression(@"[A-Z\s\d]*$", ErrorMessage = "ACA ESCRIBI EN MAYUSCULA QUE LO DEMAS SE VALE TODO")]
    public string? domicilio { get; set; }

    [Display(Name = "nombre del dueño del arrendatario")]
    [Required(ErrorMessage = "Es necesario saber el nombre del dueño de su ostentoso hogar")]
    [MaxLength(20, ErrorMessage = "señor/a su nombre es demasado largo")]
    [RegularExpression(@"[A-Z\s]*$", ErrorMessage = "SOLO SON ADMICIBLE MAYUSCULA Y ESPACIO ")]
    public string? NombreDueño { get; set; }

    public byte[]? imagenDeCasa { get; set; }

    public bool alquilada { get; set; }

    public bool eliminada { get; set; }








}
