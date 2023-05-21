using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ADO.Models
{
    public class AdmArticulo
    {
        private SqlConnection conexion;
        private void Conectar()
        {
            string stringConexion = ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            conexion = new SqlConnection(stringConexion);
        }

        public List<Articulo> TraerTodos()
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("select codigo, descripcion, precio from articulos", conexion);

            List<Articulo> articulos = new List<Articulo>();

            conexion.Open();

            SqlDataReader registros = sentencia.ExecuteReader();

            while (registros.Read())
            {
                Articulo articulo = new Articulo
                {
                    Codigo = int.Parse(registros["codigo"].ToString()),
                    Descripcion = registros["descripcion"].ToString(),
                    
                    Precio = float.Parse(registros["precio"].ToString()),
                };

                articulos.Add(articulo);
            }

            conexion.Close();

            return articulos;
        }
        public int Alta(Articulo pArticulo)
        {
            Conectar();
            SqlCommand sentencia = new SqlCommand("insert into Articulos (Codigo, Descripcion, Precio) values (@codigo, @descripcion, @precio)", conexion);

            sentencia.Parameters.Add("@codigo", System.Data.SqlDbType.Int);
            sentencia.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);
            sentencia.Parameters.Add("@precio", System.Data.SqlDbType.Float);


            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;

            conexion.Open();

            int i = sentencia.ExecuteNonQuery();

            conexion.Close();

            return i;

        }





        public Articulo TraerArticulo(int pCodigo)
        {

            Conectar();
            SqlCommand sentencia = new SqlCommand("select codigo, descripcion, precio from articulos where codigo = @Codigo", conexion);

            sentencia.Parameters.Add("@Codigo", SqlDbType.Int);
            sentencia.Parameters["@Codigo"].Value = pCodigo;

            conexion.Open();

            Articulo a = new Articulo();

            SqlDataReader registros = sentencia.ExecuteReader();

            if (registros.Read())
            {
                a.Codigo = int.Parse(registros["codigo"].ToString());
                a.Descripcion = registros["descripcion"].ToString();
                a.Precio = float.Parse(registros["precio"].ToString());

            }

            conexion.Close();

            return a;
        }

        public int ModificarArticulo(Articulo pArticulo)
        {

            Conectar();
            SqlCommand sentencia = new SqlCommand("update articulos set descripcion = @descripcion, precio = @precio where codigo = @codigo", conexion);

            sentencia.Parameters.Add("@codigo", SqlDbType.Int);
            sentencia.Parameters["@codigo"].Value = pArticulo.Codigo;
            sentencia.Parameters.Add("@descripcion", SqlDbType.VarChar);
            sentencia.Parameters["@descripcion"].Value = pArticulo.Descripcion;
            sentencia.Parameters.Add("@precio", SqlDbType.Float);
            sentencia.Parameters["@precio"].Value = pArticulo.Precio;

            conexion.Open();

            int i = sentencia.ExecuteNonQuery();

            conexion.Close();

            return i;
        }

        public int Borrar(int pCodigo)
        {

            Conectar();
            SqlCommand sentencia = new SqlCommand("delete from articulos where codigo = @Codigo", conexion);

            sentencia.Parameters.Add("@Codigo", SqlDbType.Int);
            sentencia.Parameters["@Codigo"].Value = pCodigo;

            conexion.Open();

            int i = sentencia.ExecuteNonQuery();

            conexion.Close();

            return i;
        }



    }
}















