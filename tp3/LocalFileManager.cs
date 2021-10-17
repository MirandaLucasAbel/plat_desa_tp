using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Plataforma_TP2;
using dao;
using tp1;

namespace config
{
       class LocalFileManager
    {
        public static string userpath;

        static LocalFileManager()
        {
            userpath = Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData) + @"\\Mercado";

            if (!Directory.Exists(userpath))
            {
                Directory.CreateDirectory(userpath);
            }

            //test
            UsuarioDAO1 us = new UsuarioDAO1();
            // us.ejecutarQuery("select * from usuarios");
            try
            {
                us.getUserById(5);
                var usuarios = us.getAll();
                us.delete(5);
               Usuario aux = new Usuario (6, 0000, "admin", "admin", "admin@gmail.com", "admin", "admin", "000");
                us.update(aux);
                us.insert("1231241", "1234123", "pass", 1234, "mail", "admin", "1234");
            }
            catch(Exception ex)
            {

            }
       

        }
    }
}