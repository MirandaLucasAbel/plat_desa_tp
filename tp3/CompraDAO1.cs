using System;

using Slc_Mercado;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using tp1;
using config;
using Slc_Mercado;


public class CompraDAO1
{

	public Compra get(int id_usuario)
    {
		return new Compra(id_usuario,null,null);
    }

	public  List<Compra> getAll()
    {

		List<Compra> compras = null;
		return compras;
    }


	public bool saveAll(List<Compra> compra)
    {

		return false;

	}

	public bool insert(Compra compra)
    {
		return false;
    }

	public bool delete(int id)
    {
		return false;
    }



	
}
