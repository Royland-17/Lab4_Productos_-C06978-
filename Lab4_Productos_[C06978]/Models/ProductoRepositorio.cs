using Lab4_Productos__C06978_.Models;

namespace Lab4_Productos__C06978_.Models
{
    public static class ProductoRepositorio
    {
    
        private static List<Producto> _productos = new List<Producto>();
        private static int _proximoId = 1;

        public static List<Producto> ObtenerTodos() => _productos;

        public static Producto ObtenerPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

        public static void Agregar(Producto p)
        {
            p.Id = _proximoId++;
            _productos.Add(p);
        }

        public static void Actualizar(Producto p)
        {
            var existente = ObtenerPorId(p.Id);
            if (existente != null)
            {
                existente.Nombre = p.Nombre;
                existente.Precio = p.Precio;
                existente.Categoria = p.Categoria;
            }
        }

        public static void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null) _productos.Remove(producto);
        }
    }
}