using System.ComponentModel.DataAnnotations;

namespace integradora555.Models
{
    public class Devolucion
    {
        [Key]

        public int DevolucionId { get; set; }

        [Display(Name = "Fecha Devolucion")]
        [DataType(DataType.Date)]
        public DateTime FechaDevolucion { get; set; }
        [Display(Name = "alquiler")]
        public int AlqulerId { get; set; }
        [Display(Name = "cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "casa")]
        public int CasaId { get; set; }

        [Display(Name = "nombre")]
        public string? ClienteNombre { get; set; }
        [Display(Name = "nombre de la casa")]
        public string? CasaNombre { get; set; }

        public virtual Cliente? Cliente { get; set; }

        public virtual Casa? Casa { get; set; }

    }
}