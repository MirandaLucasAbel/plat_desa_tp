﻿using System;


namespace tp1
{
    public class Empresa : Usuario 
        {
        public int cuit { get; set;}


        public Empresa (int id, int cuit, int dni, string nombre, string apellido, string mail, string password) : base( id,  dni,  nombre, apellido,  mail,  password)
        {
            this.cuit = cuit;

        }

        public string toString()
        {
            //modificar para empresa asasas 
            return "Empresa - " + base.toString()  + " - cuit: " + cuit;
        }
    }




}

