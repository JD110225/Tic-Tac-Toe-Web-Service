using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System;

namespace Tarea3
{
    public struct Puntaje
    {
        public string nombre;
        public int tiempo;

    }
    public class SqlHandler
    {
        private SqlConnection conexion;
        private readonly string rutaConexion;

        public SqlHandler()
        {
            rutaConexion = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            conexion = new SqlConnection(rutaConexion);
        }

        public List<Puntaje> LeerBaseDeDatos()
        {
            string consulta = "SELECT * FROM Puntajes ORDER BY tiempo desc";
            SqlCommand comandoConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(comandoConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            conexion.Open();
            adaptador.Fill(consultaFormatoTabla);
            conexion.Close();
            return tablaToLista(consultaFormatoTabla);
        }

        public List<Puntaje> tablaToLista(DataTable tabla)
        {
            List<Puntaje> lista = new List<Puntaje>();
            foreach(DataRow row in tabla.Rows)
            {
                lista.Add(new Puntaje
                {
                    nombre = Convert.ToString(row["nombre"]),
                    tiempo = Convert.ToInt32(row["tiempo"])
                }) ;
            }
            return lista;
        }

        public bool InsertarEnBaseDeDatos(string nombre, string tiempo)
        {
            string consulta = "INSERT INTO Puntajes (nombre,tiempo) VALUES('"+nombre+"','"+tiempo+"');";
            Debug.WriteLine(consulta);
            SqlCommand comandoConsulta = new SqlCommand(consulta, conexion);
            conexion.Open();
            bool exito;
            try
            {
                comandoConsulta.ExecuteNonQuery();
                exito = true;
                Debug.WriteLine("Exito al insertar en base de datos");
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine("Error al insertar en base de datos");
                System.Console.WriteLine(ex.Message);
                exito = false;
            }
            conexion.Close();
            return exito;
        }
    }
}