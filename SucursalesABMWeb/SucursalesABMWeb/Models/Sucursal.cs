using System;
using System.ComponentModel.DataAnnotations;

namespace SucursalesABMWeb.Models
{
    public class Sucursal
    {
        public int SucursalID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(100)]
        public string Provincia { get; set; }

        [Required]
        [StringLength(20)]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime FechaApertura { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }
    }
}
