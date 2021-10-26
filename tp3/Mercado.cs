using Slc_Mercado;
using System;
using System.Collections.Generic;
using System.Linq;
using dao;



namespace tp1
{
    public class Mercado
    {


       private List<Categoria> categorias;

        private List<Producto> productos;

        private List<Usuario> usuarios;

        private Usuario usuario;

        private Carro carro;

        private List<Compra> compras ;

       private CategoriaDAO1 categoriaDao;
        private ProductoDAO1 productoDao;
        private UsuarioDAO1 usuarioDao;
        private CompraDAO1 compradao;
        private CarroDAO1 carroDao;

        public Mercado()
            {
            /*no es necesario iniciar esto*/
            this.productos = ProductoDAO.getAll();
            this.categorias = CategoriaDAO.getAll();
            this.usuarios = UsuarioDAO.getAll();
            this.compras = new List<Compra>();

            /*daos*/
             this.categoriaDao = new CategoriaDAO1();
            this.compradao = new CompraDAO1();
            this.usuarioDao = new UsuarioDAO1();
            this.productoDao = new ProductoDAO1();
            

            foreach (Usuario us in usuarios) us.MiCarro = new Carro();

        }

        public List<Producto> getProductos()
        {
            return this.productoDao.getAll();
        }

        internal List<Producto> getProductosActivos()
        {
            return this.productoDao.getActivos();
        }

        internal List<Compra> getCompras()
        {
            return this.compradao.getAll();
        }

        internal List<Usuario> getUsuarios()
        {
            return this.usuarioDao.getAll();
        }

        internal List<Categoria> getCategorias()
        {
            return this.categoriaDao.getAll();
        }

        internal string mostrarCarro()
        {
           return  this.usuario.MiCarro.toString(); 
        }

        internal int cantidadArticulos()
        {
            return this.usuario.MiCarro.cantidadArticulos();
        }

        public bool agregarProducto (string nombre, double precio, int cantidad, int id_Categoria)
            {

           bool flag = this.productoDao.insert(nombre, precio, cantidad, id_Categoria);
            
            return flag;
            }


        public bool modificarProducto(int id, string nombre, double precio, int cantidad, int id_Categoria)
        {

            bool flag = this.productoDao.update(id, nombre, precio, cantidad, id_Categoria);
            return flag;
        }

        public Categoria buscarCategoria(int id)
        {
            return categoriaDao.get(id);
        }
                public bool eliminarProducto (int id) {
            return this.productoDao.delete(id);
                }

        internal double calcularCompra(int idUsuario)
        {
            double total = this.usuario.MiCarro.calcularTotal();
        
            return total;
         }

        public List<Producto> buscarProductos(string query) 
            {
            List<Producto> productoPorNombre = productoDao.getByName(query);

            return productoPorNombre;
            }


            public List<Producto> buscarProductosPorPrecio (string query) //ORDENADO POR PRECIO DE MENOR A MAYOR LOS PRODUCTOS QUE CONTIENEN EN SU NOMBRE LA CADENA INGRESADA
            {

            List<Producto> listProductos = productoDao.getByPrice(query);
                return listProductos;
            }


            public List<Producto> buscarProductosPorCategoria (int id_Categoria) //ORDENADO POR NOMBRE LOS PRODUCTOS QUE PERTENCEN A LA CATEGORIA CON EL ID INGRESADO
            {
            List<Producto> listProd = productoDao.getbyCateg(id_Categoria);
                
                
            return listProd;
            }

        public Producto buscarProductoPorNombre(string nombre) //ORDENADO POR NOMBRE LOS PRODUCTOS QUE PERTENCEN A LA CATEGORIA CON EL ID INGRESADO
        {
            return productoDao.getAllByName(nombre);
        }


        public bool agregarUsuario (int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
            {
                
            // int erroresDeIngreso = verificarIngresoUsuario(idActual, dni, nombre, apellido, mail, password, cuit_Cuil, tipo); //descomentar
            int erroresDeIngreso = 0;
               
                if (erroresDeIngreso > 0)
                {
                Console.WriteLine("usted tiene " + erroresDeIngreso + " errores que solucionar antes de poder crear su usuario");
                return false;
                }

         

            bool flag = this.usuarioDao.insert(nombre, apellido, password, dni, mail, tipo, cuit_Cuil);

            return flag;
            }


        public bool modificarUsuario(int id, int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
        {
            //int contieneErrores = verificarIngresoUsuario(id, dni, nombre, apellido, mail, password, cuit_Cuil, tipo);
            int contieneErrores = 0;
            if (contieneErrores > 0)
            {
                //UPDATE
                Console.WriteLine("usted tiene "+ contieneErrores + " errores que solucionar antes de poder modificar el usuario");
                return false;
            }
            else
            {
                bool flag = this.usuarioDao.update(id,  dni,  nombre,  apellido,  mail,  password,  cuit_Cuil,  tipo);
            }
            return true;
        }

        private int verificarIngresoUsuario(int id, int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
        {
            //revisar
            int contadorErrores = 0;
            foreach (Usuario us in usuarios)
            {
                if (us.id == id)
                {
                    if (cuit_Cuil.Length == 11)
                    {
                        us.cuilCuit = cuit_Cuil;
                    }
                    else
                    {
                        Console.WriteLine("El Cuit/Cuil ingresado no es correcto, recuerde que debe tener 11 digitos");
                        contadorErrores += 1;
                    }

                    if (Math.Log10(dni) + 1 == 8)
                    {
                        us.dni = dni;
                    }
                    else
                    {
                        Console.WriteLine("El Dni ingresado no es correcto, recuerde que debe tener 8 digitos");
                        contadorErrores += 1;
                    }

                    if (!(string.IsNullOrEmpty(nombre)))
                    {
                        us.nombre = nombre;
                    }
                    else
                    {
                        Console.WriteLine("El Nombre ingresado no puede estar vacio");
                        contadorErrores += 1;
                    }

                    if (!(string.IsNullOrEmpty(apellido)))
                    {
                        us.apellido = apellido;
                    }
                    else
                    {
                        Console.WriteLine("El Apellido ingresado no puede estar vacio");
                        contadorErrores += 1;
                        break;
                    }

                    if (!(string.IsNullOrEmpty(mail)))
                    {
                        us.mail = mail;
                    }
                    else
                    {
                        Console.WriteLine("El Mail ingresado no es correcto");
                        contadorErrores += 1;
                    }

                    if (!(string.IsNullOrEmpty(password)) && password.Length > 6)
                    {
                        us.password = password;
                    }
                    else
                    {
                        Console.WriteLine("El Password ingresado no es correcto, recuerde que debe tener 6 digitos");
                        contadorErrores += 1;
                    }
                }
            }
            return contadorErrores;
        }

            public bool eliminarUsuario (int id)
            {
            bool flag = this.usuarioDao.delete(id);
            return flag;
            }

            public List<Usuario> mostrarUsuarios () 
            {
                usuarios = usuarios.OrderBy(o  =>  o.dni).ToList();
                return usuarios;     
            
            }
 
            public bool agregarCategoria (string nombre)
            {
            return this.categoriaDao.insert(nombre);
            }
            //private int verificarEspacio

            public bool modificarCategoria (int id, string nombre)
            {
            return this.categoriaDao.update(id, nombre);
            }


            public bool eliminarCategoria (int id)
            {
            return categoriaDao.delete(id);
      
        }


            public List<Categoria> mostrarCategorias()
            {
            categorias = categorias.OrderBy(o => o.id).ToList();
            return categorias;
            /*foreach (Categoria cat in categorias)
            {
                    Console.WriteLine(cat.toString());

            }*/
        }

        public List<Categoria> buscarProductosPorCategoria(string nombreCateg) 
        {
            categorias = categorias.OrderBy(o => o.id).ToList();
            List<Producto> aux = new List<Producto>();
            foreach (Producto prod in productos)
            {
                if(prod.cat.nombre == nombreCateg)
                {
                    aux.Add(prod);
                }
            }
            return categorias;
        }


           

            public bool agregarAlCarro (int id_Producto, int cantidad, int id_Usuario){
                bool flag = true;

           

            try
            {
                if (getProductoById(id_Producto).cantidad >= cantidad) { 
                usuario.MiCarro.agregarProducto(getProductoById(id_Producto), cantidad);
                } else
                {
                    flag = false;
                }
            }
            catch(Exception ex)
            {
                flag = false;
            }
            

              

            return flag;
        }
        
            
            public bool quitarDelCarro (int id_Producto, int cantidad, int id_Usuario){
            bool flag = false;
            for (var i = 0; i < usuarios.Count(); i++)
            {
                if (usuarios[i].id == id_Usuario)
                {
                    for (var a = 0; a < productos.Count(); a++)
                    {
                        if (productos[a].id == id_Producto)
                        {
                            usuarios[i].MiCarro.sacarProductos(productos[a], cantidad);
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag == true)
                {

                    break;
                }

            }

            return flag;
        }



        public List<Producto> buscarProductosPorNombre(string nombre)
        {
            List<Producto> aux = new List<Producto>();
            foreach (Producto prod in productos)
            {
                if (prod.nombre == nombre)
                {
                    aux.Add(prod);
                }
            }

            return aux;
        }
        public bool vaciarCarro (int id_Usuario){
            this.usuario.MiCarro = new Carro();
            bool flag = carroDao.delete(id_Usuario);
            return flag;
            }
          
        
        
            public bool comprar(int id_Usuario){
            bool flag = false;
            int idActual=0;
           
            if (checkCarrito(usuario.MiCarro.productos))
            {
                List<Producto> productos = ProductoDAO.getAll();

                foreach (KeyValuePair<Producto, int> prod in usuario.MiCarro.productos)
                {
                    //poco performante pero se optimiza cuando pasemos a sql
                   foreach(Producto stock in productos)
                    {
                        if (stock.id == prod.Key.id) stock.cantidad -= prod.Value;
                    }


                }

                ProductoDAO.saveAll(productos);
            }
            else
            {
                return false;
            }


            //revisar despues
            for (var i = 0; i < usuarios.Count(); i++)
            {
                if (usuarios[i].id == id_Usuario) {
                       
                        foreach (Compra comp in compras)
                        {
                        if (comp.id > idActual) { idActual = comp.id; }
                        }
                    List<List<String>> comprasAux = CompraDAO.getAllText();
                    compras.Add(new Compra(idActual +1, usuarios[i],usuarios[i].MiCarro.productos));
                    //comprasAux.Add(new Compra(idActual + 1, usuarios[i], usuarios[i].MiCarro.productos));
                    CompraDAO.saveAllText(compras);
                        flag = true;
                        break;

                }
            }

                return flag;
            }

        public bool checkCarrito(Dictionary<Producto,int> lista)
        {
            bool flag = true;
            foreach (KeyValuePair<Producto, int> prod in lista)
            {

                int pedido = prod.Value;
                int stock = getProductoById(prod.Key.id).cantidad;

                if ((stock < pedido))
                {
                    flag = false;
                    break;
                }
               
            }
            return flag;
        }

        //pasar al dao
        public Producto getProductoById(int id)
        {
            List<Producto> prodcutos = ProductoDAO.getAll();
            foreach (Producto prod in productos)
            {
                if (prod.id == id) return prod;
            }
            return null;
        }


      

       

        public int cantidadStockPorProducto(int idProd)
        {
            foreach(Producto prod in productos)
            {
                if(prod.id == idProd)
                {
                    return prod.cantidad;
                }
            }

            return -1;
        }
        
        public bool modificarCompra ( int id, double total){
            bool flag = false;
           // compras = CompraDAO.getAllText();
            for (var i = 0; i < compras.Count(); i++)
            {
                if (compras[i].id == id) {
                    compras[i].total = total;
                    flag = true;
                    CompraDAO.saveAll(compras);
                    break;
                }
            
            
            }
            return flag;
            }

        
        public bool eliminarCompra (int id){
            bool flag = false;
            List<List<string>> comprasText = CompraDAO.getAllText();
            int index = 0;
            foreach(List<string> lista in comprasText)
            {
                if(lista[0] == id.ToString())
                {
                    comprasText.RemoveAt(index);
                    //compras.RemoveAt(index);
                    flag = true;
                    CompraDAO.saveAllText1(comprasText);

                }
                index++;
            }
            return flag;

            }

  
        public List<Producto> mostrarTodosProductos()
        {
            productos.Sort((a, b) => a.id.CompareTo(b.id));
            return productos;
            /*foreach (Producto pr in producto)
            {
                Console.WriteLine(pr.toString());

            }*/

        }

            public List<Producto> mostrarTodosProductosPorPrecio() //MUESTRA TODOS LOS PRODUCTOS DEL MERCADO, ORDENADO POR PRECIO
            {
                  return productos.OrderBy(pr => pr.precio).ToList();
            }


            public List<Producto> mostrarTodosProductosPorCategoria() //MUESTRA TODAS LAS CATEGORIAS DEL MERCADO Y PARA CADA UNA DE ELLAS, LOS PRODUCTOS DENTRO DE LA MISMA.
            {
            return productos.OrderBy(pr => pr.cat.id).ToList();
            }


        public int iniciarSesion(int dni,string pass)
        {
            foreach (Usuario us in usuarios)
            {
                if (us.dni == dni && us.password == pass) return us.id;
            }
                return -1;
        }

        public bool iniciarSesion1(int dni,string pass)
        {
            UsuarioDAO1 usuarioDao = new UsuarioDAO1();
            this.usuario = usuarioDao.getUsuarioByDni(dni, pass);
            if (this.usuario != null)
            {
                this.carro = new Carro();
                return true;
            }
            return false;


        }



        public bool esAdmin()
        {
            return this.usuario.tipo.Trim() == "admin";
        }

        public  Usuario getUsuario()
        {
            return this.usuario;
        }

        public Usuario getUsuario(int id)
        {
            foreach (Usuario us in usuarios)
            {
                if (us.id == id) return us;
            }

            return null;
        }
    }
}
