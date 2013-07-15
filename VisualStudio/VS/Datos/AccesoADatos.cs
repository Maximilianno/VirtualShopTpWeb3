using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using VisualStudio.Entidad;
using VisualStudio.VS.classes;
using System.Configuration;

namespace VisualStudio.VS.Datos
{
    public class AccesoADatos
    {
        SqlConnection sqlconn;
        Object resultado;
        #region Conexion
        protected void Page_Load(object sender, EventArgs e)
        {
            conectar();
        }

        //Conexion a BD
        public bool conectar()
        {
            /*SqlConnectionStringBuilder miConexion = new SqlConnectionStringBuilder();
            miConexion.DataSource = "SERGIO-HP";  //Nombre del servidor
            miConexion.InitialCatalog = "VirtualShop";            //Nombre de Base de Datos
            miConexion.IntegratedSecurity = true;
            string conexion = miConexion.ToString();/*cadenaDeConexion();*/
            /*sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            return (sqlconn.State == ConnectionState.Open);*/
            string connectionString;
            sqlconn = new SqlConnection();
            ConnectionStringSettingsCollection settings =
            ConfigurationManager.ConnectionStrings;

            ConnectionStringSettings TestConnect = settings["VirtualShopConnectionString"];
            connectionString = TestConnect.ToString();
            //SqlConnectionStringBuilder miConexion = new SqlConnectionStringBuilder(connectionString);
            sqlconn.ConnectionString = connectionString;
            sqlconn.Open();

            return (sqlconn.State == ConnectionState.Open);
        }

        public String cadenaDeConexion()
        {
            System.Configuration.Configuration rootWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString;
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["VirtualShopConnectionString"];
            return connString.ToString();
        }
        /*          FIN DE CONEXION         */
        #endregion Conexion

        #region Tienda
        public void insertarNuevaTienda(Tienda tienda)
        {
            if (conectar())
            {
                SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL", tienda.RazonSocial); //Envio el paramerto a insertar
                SqlParameter paramEmail = new SqlParameter("@EMAIL", tienda.Email);
                SqlParameter paramPassword = new SqlParameter("@PASSWORD", Utilitarios.CalculateMD5Hash(tienda.Password));
                SqlParameter paramCUIT = new SqlParameter("@CUIT", tienda.CUIT);
                SqlParameter paramImagen = new SqlParameter("@IMAGEN", tienda.Imagen);

                SqlParameter paramIdRegistracion = new SqlParameter("@UID", Utilitarios.CalculateMD5Hash(tienda.Email + "BirdIsTheWord"));
                

                SqlCommand miComando = new SqlCommand("p_CrearTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                
                miComando.Parameters.Add(paramRazonSocial);
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramIdRegistracion);
                miComando.Parameters.Add(paramImagen);

                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();
        }

        public void editarTienda(Tienda tienda)
        {
            if (conectar())
            {

                SqlParameter paramEmail = new SqlParameter("@EMAIL",tienda.Email); //Envio el paramerto a insertar
                SqlParameter paramRazonSocial = new SqlParameter("@RAZONSOCIAL", tienda.RazonSocial);
                SqlParameter paramCUIT = new SqlParameter("@CUIT", tienda.CUIT  );
                SqlParameter paramPassword = new SqlParameter("@PASSWORD", tienda.Password);
                SqlParameter paramEstado = new SqlParameter("@ESTADO", tienda.Estado);
                SqlParameter paramImagen = new SqlParameter("@IMAGEN", tienda.Imagen);


                SqlCommand miComando = new SqlCommand("p_ModificarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramRazonSocial);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramEstado);
                miComando.Parameters.Add(paramImagen);
                
                miComando.ExecuteNonQuery();
            sqlconn.Close();
        }
        }

        public void eliminarTienda(int ID)
        {
            if (conectar())
            {
                SqlParameter paramID = new SqlParameter("@ID", ID);

                SqlCommand miComando = new SqlCommand("p_EliminarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramID);
                miComando.ExecuteNonQuery();
            }
           
        }

        public Tienda LoginTienda(string email, string password)
        {
                if (conectar())
                {
                    SqlParameter paramEmail    = new SqlParameter("@EMAIL", email);
                    SqlParameter paramPassword = new SqlParameter("@PASSWORD", password);

                    SqlCommand miComando = new SqlCommand("p_Login", sqlconn); //ejecuto la StoreProcedure en la BD
                    miComando.CommandType = CommandType.StoredProcedure;
                    miComando.Parameters.Add(paramEmail);
                    miComando.Parameters.Add(paramPassword);

                    DataTable miTabla = new DataTable();
                    miTabla.Load(miComando.ExecuteReader());

                    if (miTabla.Rows.Count != 0)
                    {
                        Tienda userTienda = new Tienda();

                        userTienda.Password = Convert.ToString(miTabla.Rows[0]["Password"]);
                        userTienda.Id = Convert.ToInt32(miTabla.Rows[0]["Id"]);
                        userTienda.Email = Convert.ToString(miTabla.Rows[0]["Email"]);
                        userTienda.RazonSocial = Convert.ToString(miTabla.Rows[0]["RazonSocial"]);
                        userTienda.CUIT = Convert.ToString(miTabla.Rows[0]["CUIT"]);
                        userTienda.Estado = Convert.ToString(miTabla.Rows[0]["Estado"]);
                        userTienda.Imagen = Convert.ToString(miTabla.Rows[0]["Imagen"]);

                        return userTienda;
                    }
                    else
                        return null;
                }
            
                else return null;
        }

        public bool ConfirmaTienda(string email, string uid)
        {
            if (conectar())
            {

                SqlParameter paramEmail = new SqlParameter("@EMAIL", email); //Envio el paramerto a insertar
                SqlParameter paramUid = new SqlParameter("@UID", uid);
                
                SqlCommand miComando = new SqlCommand("p_ConfirmarTienda", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramUid);

                try
                {
                    miComando.ExecuteNonQuery();
                    return true;
                }
                catch {
                    return false;
                }

            }
            sqlconn.Close();
            return false;
        }

        public List<Tienda> ObtenerTiendasPorCategoria(int idCategoria)
        {
            if (conectar())
            {
                SqlCommand miComando = new SqlCommand("p_ObtenerTiendasPorCategoria", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramIdTienda = new SqlParameter("@IDCATEGORIA", idCategoria);

                miComando.Parameters.Add(paramIdTienda);

                DataTable miTabla = new DataTable();
                miTabla.Load(miComando.ExecuteReader());

                List<Tienda> tiendas = new List<Tienda>();
                int cant = miTabla.Rows.Count;
                int i = 0;

                while (i < cant)
                {
                    Tienda tienda = new Tienda();
                    tienda.Id = Convert.ToInt32(miTabla.Rows[i]["Id"]);
                    tienda.Email = Convert.ToString(miTabla.Rows[i]["Email"]);
                    tienda.RazonSocial = Convert.ToString(miTabla.Rows[i]["RazonSocial"]);
                    tienda.CUIT = Convert.ToString(miTabla.Rows[i]["CUIT"]);
                    tienda.Estado = Convert.ToString(miTabla.Rows[i]["Estado"]);
                    tienda.FechaRegistracion = Convert.ToDateTime(miTabla.Rows[i]["FechaRegistracion"]);
                    tienda.Imagen = Convert.ToString(miTabla.Rows[i]["Imagen"]);

                    tiendas.Add(tienda);
                    i++;
                }
                return tiendas;
            }
            else return null;
        }

        public List<Tienda> ObtenerTiendas() {

            if (conectar())
            {
                SqlCommand miComando = new SqlCommand("p_ObtenerTiendas", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                DataTable Tabla = new DataTable();
                Tabla.Load(miComando.ExecuteReader());
                
                List<Tienda> tiendas = new List<Tienda>();
                int cant = Tabla.Rows.Count;
                int i = 0;

                while (i < cant)
                {
                    Tienda tienda = new Tienda();
                    tienda.Id = Convert.ToInt32(Tabla.Rows[i]["Id"]);
                    tienda.Email = Convert.ToString(Tabla.Rows[i]["Email"]);
                    tienda.RazonSocial = Convert.ToString(Tabla.Rows[i]["RazonSocial"]);
                    tienda.CUIT = Convert.ToString(Tabla.Rows[i]["CUIT"]);
                    tienda.Estado = Convert.ToString(Tabla.Rows[i]["Estado"]);
                    tienda.FechaRegistracion = Convert.ToDateTime(Tabla.Rows[i]["FechaRegistracion"]);
                    tienda.Imagen = Convert.ToString(Tabla.Rows[0]["Imagen"]);

                    tiendas.Add(tienda);
                    i++;
                }

                return tiendas;

            }
            else return null;
        
        }

        #endregion Tienda

        #region Producto
        public void InsertarNuevoProducto(Producto producto)
        {
            if (conectar())
            {
                List<SqlParameter> lista = new List<SqlParameter>();

                SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA", producto.idTienda); //Envio el paramerto a insertar
                SqlParameter parmaNombre = new SqlParameter("@NOMBRE", producto.Nombre);
                SqlParameter paramDescripcion = new SqlParameter("@DESCRIPCION", producto.Descripcion);
                SqlParameter parmaPrecio = new SqlParameter("@PRECIO", producto.Precio);
                SqlParameter paramStock = new SqlParameter("@STOCK", producto.Stock);
                SqlParameter paramImg = new SqlParameter("@IMAGEN", producto.Imagen);
                SqlParameter paramIdCat = new SqlParameter("@IDCATEGORIA", producto.IdCategoria);

                SqlCommand miComando = new SqlCommand("p_CrearProducto", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                // Parameters:

                miComando.Parameters.Add(paramIdTienda);
                miComando.Parameters.Add(parmaNombre);
                miComando.Parameters.Add(paramDescripcion);
                miComando.Parameters.Add(parmaPrecio);
                miComando.Parameters.Add(paramStock);
                miComando.Parameters.Add(paramImg);
                miComando.Parameters.Add(paramIdCat);


                miComando.ExecuteNonQuery();
            }
            sqlconn.Close();

        }

        public void EditarProducto(Producto producto)
        {
            if (conectar())
            {
                SqlParameter paramId = new SqlParameter("@ID", producto.ID);
                SqlParameter paramEmail = new SqlParameter("@NOMBRE", producto.Nombre); //Envio el paramerto a insertar
                SqlParameter paramRazonSocial = new SqlParameter("@DESCRIPCION", producto.Descripcion);
                SqlParameter paramCUIT = new SqlParameter("@STOCK", producto.Stock);
                SqlParameter paramPassword = new SqlParameter("@PRECIO", producto.Precio);
                SqlParameter paramEstado = new SqlParameter("@CATEGORIA", producto.IdCategoria);


                SqlCommand miComando = new SqlCommand("p_EditarProducto", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramId);
                miComando.Parameters.Add(paramEmail);
                miComando.Parameters.Add(paramRazonSocial);
                miComando.Parameters.Add(paramCUIT);
                miComando.Parameters.Add(paramPassword);
                miComando.Parameters.Add(paramEstado);

                miComando.ExecuteNonQuery();
                sqlconn.Close();
            }
        }

        public List<Producto> ObtenerProductos(int idTienda)
        {
            if (conectar())
            {
                SqlCommand miComando = new SqlCommand("p_ObtenerProductos", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA", idTienda);

                miComando.Parameters.Add(paramIdTienda);

                DataTable miTabla = new DataTable();
                miTabla.Load(miComando.ExecuteReader());

                List<Producto> listaDeProductos = new List<Producto>();
                int cant = miTabla.Rows.Count;
                int i = 0;

                while (i < cant)
                {
                    Producto producto = new Producto();
                    producto.ID = Convert.ToInt32(miTabla.Rows[i]["Id"]);
                    producto.Nombre = Convert.ToString(miTabla.Rows[i]["Nombre"]);
                    producto.Descripcion = Convert.ToString(miTabla.Rows[i]["Descripcion"]);
                    producto.Stock = Convert.ToInt32(miTabla.Rows[i]["Stock"]);
                    producto.Precio = Convert.ToInt32(miTabla.Rows[i]["Precio"]);
                    producto.IdCategoria = Convert.ToInt32(miTabla.Rows[i]["Categoria"]);

                    listaDeProductos.Add(producto);
                    i++;
                }

                return listaDeProductos;

            }
            else return null;
        }

        public void EliminarProducto(int id)
        {
            if (conectar())
            {
                SqlParameter paramID = new SqlParameter("@ID", id);

                SqlCommand miComando = new SqlCommand("p_EliminarProducto", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramID);
                miComando.ExecuteNonQuery();
            }
        }

        public List<Producto> ProductosPorTiendaCategoria(int idTienda, int idCategoria)
        {
            if (conectar())
            {
                SqlCommand miComando = new SqlCommand("p_ProductosPorTiendaCategoria", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA", idTienda);
                SqlParameter paramIdCategoria = new SqlParameter("@IDCATEGORIA", idCategoria);

                miComando.Parameters.Add(paramIdTienda);
                miComando.Parameters.Add(paramIdCategoria);
                List<Producto> listaDeProductos = new List<Producto>();

                DataTable tabla = new DataTable();
                tabla.Load(miComando.ExecuteReader());
                int cant = tabla.Rows.Count;
                int i = 0;

                while (i < cant)
                {
                    Producto producto = new Producto();
                    producto.ID = Convert.ToInt32(tabla.Rows[i]["Id"]);
                    producto.idTienda = Convert.ToInt32(tabla.Rows[i]["IdTienda"]);
                    producto.Nombre = Convert.ToString(tabla.Rows[i]["Nombre"]);
                    producto.Descripcion = Convert.ToString(tabla.Rows[i]["Descripcion"]);
                    producto.Stock = Convert.ToInt32(tabla.Rows[i]["Stock"]);
                    producto.Precio = Convert.ToInt32(tabla.Rows[i]["Precio"]);
                    producto.IdCategoria = Convert.ToInt32(tabla.Rows[i]["IdCategoria"]);
                    producto.Imagen = Convert.ToString(tabla.Rows[i]["Imagen"]);
                    listaDeProductos.Add(producto);
                    i++;
                }

                return listaDeProductos;

            }
            else return null; 
        }

        public List<Producto> Producto(int idProducto)
        {
            if (conectar())
            {
                SqlCommand miComando = new SqlCommand("p_Producto", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                SqlParameter paramIdProducto = new SqlParameter("@IDPRODUCTO", idProducto);

                miComando.Parameters.Add(paramIdProducto);
                List<Producto> listaDeProductos = new List<Producto>();

                DataTable tabla = new DataTable();
                tabla.Load(miComando.ExecuteReader());
                int cant = tabla.Rows.Count;
                int i = 0;

                while (i < cant)
                {
                    Producto producto = new Producto();
                    producto.ID = Convert.ToInt32(tabla.Rows[i]["Id"]);
                    producto.idTienda = Convert.ToInt32(tabla.Rows[i]["IdTienda"]);
                    producto.Nombre = Convert.ToString(tabla.Rows[i]["Nombre"]);
                    producto.Descripcion = Convert.ToString(tabla.Rows[i]["Descripcion"]);
                    producto.Stock = Convert.ToInt32(tabla.Rows[i]["Stock"]);
                    producto.Precio = Convert.ToInt32(tabla.Rows[i]["Precio"]);
                    producto.IdCategoria = Convert.ToInt32(tabla.Rows[i]["IdCategoria"]);
                    producto.Imagen = Convert.ToString(tabla.Rows[i]["Imagen"]);
                    listaDeProductos.Add(producto);
                    i++;
                }

                return listaDeProductos;

            }
            else return null;
        }

        #endregion Producto

        #region Categoria
        public int ObtenerIdDeCategoria(string nombre)
        {
            if (conectar())
            {
                string nom = nombre;
                SqlParameter paramNombre = new SqlParameter("@NOMBRE", nombre);
                SqlParameter paramId = new SqlParameter("@ID", SqlDbType.Int, 1);
                paramId.Direction = ParameterDirection.Output;

                SqlCommand miComando = new SqlCommand("p_ObtenerIdDeCategoria", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.Parameters.Add(paramNombre);
                miComando.Parameters.Add(paramId);

                miComando.ExecuteNonQuery();

                resultado = miComando.Parameters["@ID"].Value;
                return Convert.ToInt32(resultado);

            }
            sqlconn.Close();
            int returnValor = Convert.ToInt32(resultado);
            return returnValor;
        }

        //Llena el DDL con las categorias
        public List<Categoria> ObtenerCategorias()
        {
            if (conectar())
            {
                DataTable MiTabla = new DataTable();

                SqlCommand miComando = new SqlCommand("p_ObtenerCategorias", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;
                miComando.ExecuteNonQuery();

                MiTabla.Load(miComando.ExecuteReader());
                List<Categoria> categorias = new List<Categoria>();
                int i = 0;
                int cant = MiTabla.Rows.Count;

                while (i < cant)
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = Convert.ToInt32(MiTabla.Rows[i]["Id"]);
                    categoria.Nombre = Convert.ToString(MiTabla.Rows[i]["Nombre"]);

                    categorias.Add(categoria);
                    i++;
                }

                return categorias;
            }
            else return null;

        }
        #endregion Categoria

        #region Ventas
        public List<Venta> ObtenerVentas(int idTienda)
        {
            if (conectar())
            {

                SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA", idTienda);

                SqlCommand miComando = new SqlCommand("p_ObtenerVentas", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                
                miComando.Parameters.Add(paramIdTienda);

                DataTable miTabla = new DataTable();
                miTabla.Load(miComando.ExecuteReader());

                List<Venta> listaDeVentas = new List<Venta>();

                int cant = miTabla.Rows.Count;
                int i = 0;
                Venta hola = new Venta();

                while (i < cant)
                {
                    Venta venta = new Venta();
                    venta.Id = Convert.ToInt32(miTabla.Rows[i]["Id"]);
                    venta.NombreProducto = Convert.ToString(miTabla.Rows[i]["Nombre"]);
                    venta.Cantidad = Convert.ToInt32(miTabla.Rows[i]["Cantidad"]);
                    venta.EmailComprador = Convert.ToString(miTabla.Rows[i]["EmailComprador"]);
                    venta.FechaTransaction = Convert.ToDateTime(miTabla.Rows[i]["FechaTransaccion"]);
                    venta.Estado = Convert.ToString(miTabla.Rows[i]["Estado"]);

                    listaDeVentas.Add(venta);
                    i++;
                }
                return listaDeVentas;
            }
            else return null;
        }

        public List<Venta> ObtenerVentasPorFecha(DateTime fechaDeCompra, int idTienda)
        {
            if (conectar())
            {
                SqlParameter paramFecha = new SqlParameter("@FECHA", fechaDeCompra);
                SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA", idTienda);

                SqlCommand miComando = new SqlCommand("p_ObtenerComprasPorFecha", sqlconn); //ejecuto la StoreProcedure en la BD
                miComando.CommandType = CommandType.StoredProcedure;

                miComando.Parameters.Add(paramFecha);
                miComando.Parameters.Add(paramIdTienda);

                DataTable miTabla = new DataTable();
                miTabla.Load(miComando.ExecuteReader());
                List<Venta> listaDeVentas = new List<Venta>();

                int cant = miTabla.Rows.Count;
                int i = 0;
                Venta hola = new Venta();

                while (i < cant)
                {
                    Venta venta = new Venta();
                    venta.Id = Convert.ToInt32(miTabla.Rows[i]["Id"]);
                    venta.NombreProducto = Convert.ToString(miTabla.Rows[i]["Nombre"]);
                    venta.Cantidad = Convert.ToInt32(miTabla.Rows[i]["Cantidad"]);
                    venta.EmailComprador = Convert.ToString(miTabla.Rows[i]["EmailComprador"]);
                    venta.FechaTransaction = Convert.ToDateTime(miTabla.Rows[i]["FechaTransaccion"]);
                    venta.Estado = Convert.ToString(miTabla.Rows[i]["Estado"]);

                    listaDeVentas.Add(venta);
                    i++;
                }
                return listaDeVentas;
            }
            else return null;
        }

        public bool Venta(Venta venta)
        {
            try
            {
                if (conectar())
                {

                    SqlParameter paramIdTienda = new SqlParameter("@IDTIENDA", venta.IdTienda);
                    SqlParameter paramEmail = new SqlParameter("@EMAIL", venta.EmailComprador); //Envio el paramerto a insertar
                    SqlParameter paramIdProducto = new SqlParameter("@IDPRODUCTO", venta.IdProducto);
                    SqlParameter paramPrecioUnitario = new SqlParameter("@PRECIOUNITARIO", venta.PrecioUnitario);
                    SqlParameter paramCantidad = new SqlParameter("@CANTIDAD", venta.Cantidad);

                    SqlCommand miComando = new SqlCommand("p_CrearVenta", sqlconn); //ejecuto la StoreProcedure en la BD
                    miComando.CommandType = CommandType.StoredProcedure;

                    miComando.Parameters.Add(paramIdTienda);
                    miComando.Parameters.Add(paramEmail);
                    miComando.Parameters.Add(paramIdProducto);
                    miComando.Parameters.Add(paramPrecioUnitario);
                    miComando.Parameters.Add(paramCantidad);

                    miComando.ExecuteNonQuery();
                    
                    sqlconn.Close();

                    return true;
                }
                else {
                    return false;
                }
            }
            catch {
                return false;
            }
        }
        #endregion Ventas

    }
}
