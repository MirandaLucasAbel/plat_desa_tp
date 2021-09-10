using System;
using Categoria;

namespace tp1
{
    class Producto
    {
        public int id;
        public string nombre { get; set; };
        public double precio { get; set; };
        public int cantidad { get; set; };
        public Categoria cat { get; set; };
        
        public Producto(String nombre,double precio, int cantidad, Categoria categoria){

            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.categoria = categoria;
        
        }

        string override toString()
        {
            return "Producto: " + this.ID + " - nombre " + this.nombre + " - precio " + this.precio + " - cantidad " + this.cantidad + " - categoria " + this.categoria;
        }
    }
}