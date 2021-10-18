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
        static string fileName = Path.Combine(LocalFileManager.userpath, "Categoria.json");
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

        public void saveALL (List<Categoria> categoria)
        {
            
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(categoria));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("ocurrio un error al guardar los datos");
            }
            
        }



    }
}
