using System;

using Slc_Mercado;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using tp1;
using config;
using Slc_Mercado;
using System.Data.SqlClient;

public class CompraDAO1 : DataBaseConfig
{

    private string tabla = "compra";

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

	public bool insert(int id_usuario,Carro carro)
    {

        bool flag = true;

        int id_producto;
        int cantidad;
        double total;
        try
        {
            foreach (KeyValuePair<Producto, int> kvp in carro.productos)
            {
                id_producto = kvp.Key.id;
                cantidad = kvp.Value;
                total = carro.calcularTotal();
                string sql = $"use [ecommerce-plataforma]; insert into {tabla}(id_usuario,id_producto,cantidad,total) values({id_usuario},{id_producto},{cantidad},{total});";
                SqlDataReader data = ejecutarQuery(sql);
                conexion.Close();

            }
           

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

	public bool delete(int id)
    {
        bool flag = true;

        try
        {

            string sql = $"use[ecommerce-plataforma]; delete from {tabla} where id = {id}";
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



	
}
