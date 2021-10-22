using System;

using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;

namespace dao
{
    class ProductoDAO1 : DataBaseConfig
    {

        static string fileName = Path.Combine(LocalFileManager.userpath, "Producto.json");
        private string tabla = "productos";

        public ProductoDAO1()
        {
        }

        public List<Producto> getAll()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                string sql = $"use[ecommerce - plataforma]; select id, nombre, precio, cantidad, categoria from { tabla}; ";
                SqlDataReader data = ejecutarQuery(sql);

                Producto producto = null;
                int id;
                string nombre;
                double precio;
                int cantidad;
                string categoria; //como pasar categoria de tp1. el id? el nombre?

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());
                    nombre = (data.GetValue(1).ToString());
                    precio = Double.Parse(data.GetValue(2).ToString());
                    cantidad = Int32.Parse(data.GetValue(3).ToString());
                    categoria = (data.GetValue(4).ToString());

                    producto = new Producto(id, nombre, precio, cantidad, null);// categoria); //revisar
                    productos.Add(producto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("archivo no encontrado");
            }

            finally
            {
                conexion.Close();
            }

            return productos;
        }

        public bool insert(string nombre, double precio, int cantidad /*categoria*/)
        {
            bool flag = true;

            try
            {
                Categoria categoria = null; //revisar
                string sql = $"use[ecommerce - plataforma]; insert into {tabla} (nombre, precio, cantidad, categoria) values ('{nombre}','{precio}','{cantidad}','{categoria}');";
                SqlDataReader data = ejecutarQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }

        public bool update(Producto producto)
        {
            bool flag = true;
            try
            {
                string sql = $"use[ecommerce - plataforma]; update productos set nombre = '{producto.nombre}', precio = '{producto.precio}', cantidad = '{producto.cantidad}', categoria = '{producto.cat}' where id = '{producto.id};";
                SqlDataReader data = ejecutarQuery(sql);

                ejecutarQuery(sql);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }

        public bool delete (int id)
        {
            bool flag = true;
            try
            {
                string sql = $"use [ecommerce-plataforma]; delete from {tabla} where id = {id};";
                SqlDataReader data = ejecutarQuery(sql);

                ejecutarQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }

        public void saveAll (List<Producto> producto)
        {
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(producto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("ocurrio un error al guardar los datos");
            }
        }
    }
}
