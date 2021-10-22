using System;

using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;

namespace Slc_Mercado
{
    class CarroDAO1 : DataBaseConfig
    {
        static string fileName = Path.Combine(LocalFileManager.userpath, "Carro.json");
        private string tabla = "carro";

        public CarroDAO1()
        {
        }

        public List<Carro> getAll()
        {
            List<Carro> carro = new List<Carro>();

            try
            {
                string sql = $"use[ecommerce - plataforma]; select id from { tabla}; ";
                SqlDataReader data = ejecutarQuery(sql);

                //Carro carro = null;
                int id;
                //VER QUE OTROS CAMPOS TIENE

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());

                    //carro = new Carro(id);
                   // carro.Add(carro);
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

            return carro;

        }

        public void saveAll (List<Carro> carro)
        {
            try
            {
                File.WriteAllText(fileName, JsonConvert.SerializeObject(carro));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("ocurrio un error al guardar los datos");
            }
        }




    }
}
