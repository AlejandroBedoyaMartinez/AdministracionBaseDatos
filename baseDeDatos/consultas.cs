using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cuerpo;
using Google.Protobuf.WellKnownTypes;
using Mysqlx.Cursor;
namespace baseDeDatos
{
    public class consultas
    {
        public List<clsInventario> obtenerInventarios()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=20.100.192.90; database=practica1; user=Ana; pwd=Elote123456*";
            cn.Open();
            List<clsInventario> datos = new List<clsInventario>();
            string strSQL = @"select * from Inventario";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            MySqlDataReader dr = comando.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    clsInventario x = new clsInventario();
                    x.id = dr.GetInt32("id");
                    x.nombreCorto = dr.GetString("NombreCorto");
                    x.descirpcion = dr.GetString("Descripcion");
                    x.serie = dr.GetString("Serie");
                    x.color = dr.GetString("color");
                    x.fechaAdquisicion = dr.GetString("FechaAdquision");
                    x.tipoAdquision = dr.GetString("TipoAdquision");
                    x.observaciones = dr.GetString("Observaciones");
                    x.Areas_ID = dr.GetInt32("AREAS_id");
                    datos.Add(x);
                }
            }
            catch (Exception ex)
            {
                clsInventario x = new clsInventario();
                x.id = 0;
                x.nombreCorto = "";
                x.descirpcion = "";
                x.serie = "";
                x.color = "";
                x.fechaAdquisicion = "";
                x.tipoAdquision = "";
                x.observaciones = "";
                x.Areas_ID = 0;
                datos.Add(x);
            }
            finally
            {
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            }
            
            return datos;
        }
        public List<clsAreas> obtenerAreas()
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=20.100.192.90; database=practica1; user=Ana; pwd=Elote123456*";
            cn.Open();
            List<clsAreas> datos = new List<clsAreas>();
            string strSQL = @"select * from Areas";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            MySqlDataReader dr = comando.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    clsAreas x = new clsAreas();
                    x.id = dr.GetInt32("id");
                    x.nombre = dr.GetString("Nombre");
                    x.ubicacion = dr.GetString("Ubicacion");
                    datos.Add(x);
                }
            }
            catch (Exception ex)
            {
                clsAreas x = new clsAreas();
                x.id = dr.GetInt32("id");
                x.nombre = dr.GetString("Nombre");
                x.ubicacion = dr.GetString("Ubicacion");
                datos.Add(x);
            }finally {
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            }
            return datos;

        }
        public List<clsInventario> buscarInventario(int id)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=20.100.192.90; database=practica1; user=Ana; pwd=Elote123456*";
            cn.Open();
            List<clsInventario> datos = new List<clsInventario>();
            string strSQL = @"select * from Inventario where id = @id";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            comando.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = comando.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    clsInventario x = new clsInventario();
                    x.id = dr.GetInt32("id");
                    x.nombreCorto = dr.GetString("NombreCorto");
                    x.descirpcion = dr.GetString("Descripcion");
                    x.serie = dr.GetString("Serie");
                    x.color = dr.GetString("color");
                    x.fechaAdquisicion = dr.GetString("FechaAdquision");
                    x.tipoAdquision = dr.GetString("TipoAdquision");
                    x.observaciones = dr.GetString("Observaciones");
                    x.Areas_ID = dr.GetInt32("AREAS_id");
                    datos.Add(x);
                }
            }
            catch (Exception ex)
            {
                clsInventario x = new clsInventario();
                x.id = 0;
                x.nombreCorto = "";
                x.descirpcion = "";
                x.serie = "";
                x.color = "";
                x.fechaAdquisicion = "";
                x.tipoAdquision = "";
                x.observaciones = "";
                x.Areas_ID = 0;
                datos.Add(x);
            }
            finally
            {
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            }

            return datos;
        }

        public Boolean agregarInventario(String nombreCorto,String descripcion, String serie,String color, String fechaAdquision, String tipoAdquision, String observaciones, int area_id )
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=20.100.192.90; database=practica1; user=Ana; pwd=Elote123456*";
            cn.Open();
            List<clsInventario> datos = new List<clsInventario>();
            string strSQL = @"insert into Inventario values
(null,@nombreCorto,@descripcion,@serie,@color,@fechaAdquision,@tipoAdquision,@observaciones,@area_id)";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            try
            {
                comando.Parameters.AddWithValue("@nombreCorto", nombreCorto);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@serie", serie);
                comando.Parameters.AddWithValue("@color", color);
                comando.Parameters.AddWithValue("@fechaAdquision", fechaAdquision);
                comando.Parameters.AddWithValue("@tipoAdquision", tipoAdquision);
                comando.Parameters.AddWithValue("@observaciones", observaciones);
                comando.Parameters.AddWithValue("@area_id", area_id);
                MySqlDataReader dr = comando.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public Boolean actualizarInventario(int id, String nombreCorto, String descripcion, String serie, String color, String fechaAdquision, String tipoAdquision, String observaciones, int Areas_id)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=20.100.192.90; database=practica1; user=Ana; pwd=Elote123456*";
            cn.Open();
            List<clsInventario> datos = new List<clsInventario>();
            string strSQL = @"update Inventario set
NombreCorto = @nombreCorto,Descripcion = @descripcion,Serie = @serie,color = @color,FechaAdquision = @fechaAdquision,TipoAdquision = @tipoAdquision,Observaciones = @observaciones,AREAS_id = @Areas_id
where id = @id";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            try
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nombreCorto", nombreCorto);
                comando.Parameters.AddWithValue("@descripcion", descripcion);
                comando.Parameters.AddWithValue("@serie", serie);
                comando.Parameters.AddWithValue("@color", color);
                comando.Parameters.AddWithValue("@fechaAdquision", fechaAdquision);
                comando.Parameters.AddWithValue("@tipoAdquision", tipoAdquision);
                comando.Parameters.AddWithValue("@observaciones", observaciones);
                comando.Parameters.AddWithValue("@Areas_id", Areas_id);
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public Boolean borrarInventario(int id)
        {
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "server=20.100.192.90; database=practica1; user=Ana; pwd=Elote123456*";
            cn.Open();
            List<clsInventario> datos = new List<clsInventario>();
            string strSQL = @"delete from Inventario where id = @id";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            
            try
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
    }
}
