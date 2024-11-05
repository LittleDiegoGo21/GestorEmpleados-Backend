using System.ComponentModel.DataAnnotations;

namespace GestorEmpleados.API.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public decimal Subtotal { get; set; }

        public string Cliente { get; set; }
    }
}
