using System;

using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;

namespace dao
{
    class CategoriaDAO1 : DataBaseConfig
    {
        private string tabla = "categorias";

        public CategoriaDAO1()
        {

        }

        public List<Categoria> getAll()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                string sql = $"use[ecommerce - plataforma]; select id, nombre from { tabla}; ";
                SqlDataReader data = ejecutarQuery(sql);

                Categoria categoria = null;
                int id;
                string nombre;

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());
                    nombre = (data.GetValue(1).ToString());

                    categoria = new Categoria(id, nombre);
                    categorias.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Archivo no encontrado");
            }

            finally
            {
                conexion.Close();
            }

            return categorias;
        }

        public bool insert(string categoria)
        {
            return false;
        }

        public bool update(int id,string nombre)
        {
            return false;
        }

        public bool delete(int id)
        {
            return false;
        }

        public bool saveAll (List<Categoria> categoria)
        {


            return false;
        }

        internal Categoria get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
