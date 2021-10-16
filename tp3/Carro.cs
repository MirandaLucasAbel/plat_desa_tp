﻿using System;
using System.Collections.Generic;


namespace tp1

{

    [Serializable]
    public class Carro
    {
        public int id { get; set; }
        public Dictionary<Producto, int> productos { get; set; }

        public Carro() {
            this.id = id;
            this.productos = new Dictionary<Producto, int>();
        }
        public Carro(int id) {
            this.id = id;
            this.productos = new Dictionary<Producto, int>();
        }

        public bool agregarProducto(Producto producto, int cantidad) {
            
            if ( this.productos.ContainsKey(producto))
            {
                this.productos[producto] = this.productos[producto] + cantidad;
            }
            else
            {
                productos.Add(producto, cantidad);
            }
            return true;
        }
        public bool sacarProductos(Producto producto, int cantidad) {
            foreach (KeyValuePair<Producto, int> prod in productos)
            {
                if (prod.Key == producto) {
                    if (prod.Value <= cantidad)
                    {
                        productos.Remove(producto);
                    }
                    else
                    {
                        this.productos[prod.Key] = prod.Value - cantidad;
                    }
                    return true;
                }
            }
            return false;
        }

        private Producto buscarProducto(Producto producto)
        {
            foreach (KeyValuePair<Producto, int> prod in productos)
            {
                if (prod.Key == producto)
                {
                    return prod.Key;
                }
            }
            return null;
        }
        public void mostrarTodosLosProductos()
        {
            foreach (KeyValuePair<Producto, int> prod in productos)
            {
                prod.Key.ToString();
            }
        }

        internal double calcularTotal()
        {
            double total = 0;
            foreach (KeyValuePair<Producto, int> prod in productos)
            {
                total += (prod.Key.precio * prod.Value);
            }

            return total;
        }

        internal int cantidadArticulos()
        {
            int cant = 0;
            foreach (KeyValuePair<Producto, int> prod in productos)
            {
                cant +=  prod.Value;
            }

            return cant;
        }

        public string toString()
        {
            //return "Carro: " + this.id + " - " + this.productos.ToString();
            string aux = "";
            foreach (KeyValuePair<Producto, int> prod in productos)
            {
                aux += prod.Key.nombre + " " + prod.Value.ToString() + "u * $" + prod.Key.precio.ToString() + "\n";
            }
            aux += "Total a pagar: ";
            aux += calcularTotal().ToString();

            return aux;
        }
    }
}
