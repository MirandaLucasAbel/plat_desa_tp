using System;

using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using tp1;
using config;
using System;
using System.Data.SqlClient;

namespace dao
{
	public class UsuarioDAO1 : DataBaseConfig
	{
	
		
		//static string fileName = Path.Combine(LocalFileManager.userpath, "Usuario.json");

		public UsuarioDAO1()
		{
		}

		public  Usuario getUserById(int userId)
        {
			string sql = "select * from users";
			SqlDataReader data = ejecutarQuery(sql);


			List<Usuario> usuarios;
			Usuario user = null;
			
			//usuarios = JsonConvert.DeserializeObject<List<Usuario>>
					//	(File.ReadAllText(fileName));
           // user = usuarios.Find(e => e.id == userId);
			return user;

		}

		public  List<Usuario> getAll()
		{
			
			List<Usuario> usuarios;
			try
			{
				usuarios = JsonConvert.DeserializeObject<List<Usuario>>
	(File.ReadAllText(fileName));
			}
			catch (Exception ex)
			{

				//en caso de no haber datos se genera un admin y se guarda en el archivo
				Console.WriteLine("archivo no encontrado, se inicializa un objeto vacio para productos");
				usuarios = new List<Usuario>();
				usuarios.Add(new Usuario(0, 0000, "admin", "admin", "admin@gmail.com", "admin", "admin", "000"));
				usuarios.Add(new Usuario(1, 0001, "cliente", "cliente", "cliente@gmail.com", "cliente", "cliente", "001"));
				saveAll(usuarios);
			}


			return usuarios;
		}

		public  void saveAll(List<Usuario> usuario)
		{
			try
			{
				File.WriteAllText(fileName, JsonConvert.SerializeObject(usuario));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw new Exception("ocurrio un error al guardar los datos");
			}


		}

	}

}
