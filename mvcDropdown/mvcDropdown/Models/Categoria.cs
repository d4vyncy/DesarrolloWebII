namespace mvcDropdown.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Foreign Key
        public int SucursalId { get; set; }

        // Propiedad de navegación
        public Sucursal Sucursal { get; set; }

        // Relación uno a muchos con Producto
        public ICollection<Producto> Productos { get; set; }

    }
}
