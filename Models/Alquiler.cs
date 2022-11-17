using System.ComponentModel.DataAnnotations;

namespace integradora555.Models{
public class Alquiler
{
    [Key]

    public int AlquilerId{ get; set;}
    [Display(Name ="fecha")]
    [DataType(DataType.Date)]
    public DateTime FechaDeAlquiler{ get; set;}
    [Display(Name = "cliente")]
    public int clienteId { get; set; }
    [Display(Name ="casa")]
    public int casaId { get ; set; }
    [Display(Name = "nombre")]
    public string? ClienteNombre { get; set; }
    [Display(Name = "nombre de la casa")]
    public string? CasaNombre {get; set; }

    public virtual Cliente? Cliente { get; set; }
     public virtual Casa? Casa { get; set; }
    

}

}
