namespace mvcDropdown.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public string Descripcion { get; set; }

        // Foreign Key
        public int CategoriaId { get; set; }

        // Propiedad de navegación
        public Categoria Categoria { get; set; }


    }
}
