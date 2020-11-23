using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace SQL
{
    public static class SQL
    {
        public static void CargarDatos(out List<Pantalon> pantalones, out List<Camiseta> camisetas)
        {
            camisetas = new List<Camiseta>();
            pantalones = new List<Pantalon>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("SELECT * FROM TP_4", conexion);
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        int talle = (int)reader["Talle"];
                        int equipacion = (int)reader["Equipacion"];
                        int numero = (int)reader["Numero"];
                        int mangaBolsillo = (int)(reader)["MangaOBolsillo"];
                        int esCamiseta = (int)(reader)["EsCamiseta"];


                        if (esCamiseta == 1)
                        {
                            if (mangaBolsillo == 1)
                            {
                                Camiseta prenda = new Camiseta((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, true);
                                camisetas.Add(prenda);
                            }
                            else
                            {
                                Camiseta prenda = new Camiseta((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, false);
                                camisetas.Add(prenda);
                            }
                        }
                        else
                        {
                            if (mangaBolsillo == 1)
                            {
                                Pantalon prenda = new Pantalon((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, true);
                                pantalones.Add(prenda);
                            }
                            else
                            {
                                Pantalon prenda = new Pantalon((Prenda.ETalle)talle, (Prenda.EEquipacion)equipacion, id, numero, false);
                                pantalones.Add(prenda);
                            }
                        }                   
                    }
                }
            }catch(Exception e)
            {
                camisetas = default;
                pantalones = default;
            }

        }

        public static void BorrarPrenda(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    string comandoStr = "DELETE FROM TP_4 WHERE Id = @id";

                    SqlCommand comando = new SqlCommand(comandoStr, conexion);
                    comando.Parameters.AddWithValue("id", id);

                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {

            }
        }

        public static bool agregarCamiseta(Camiseta camiseta)
        {
            bool retorno;
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    string comandoStr = "INSERT INTO TP_4(Talle, Equipacion, Numero, MangaOBolsillo, EsCamiseta) VALUES(@talle, @equipacion, @numero, @mangaOBolsillo, @esCamiseta)";

                    SqlCommand comando = new SqlCommand(comandoStr, conexion);
                    comando.Parameters.AddWithValue("talle", camiseta.Talle);
                    comando.Parameters.AddWithValue("equipacion", camiseta.Equipacion);
                    comando.Parameters.AddWithValue("numero", camiseta.Numero);

                    if(camiseta.mangaLarga)
                        comando.Parameters.AddWithValue("mangaOBolsillo", 1);
                    else
                        comando.Parameters.AddWithValue("mangaOBolsillo", 0);

                    comando.Parameters.AddWithValue("esCamiseta", 1);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool agregarPantalon(Pantalon pantalon)
        {
            bool retorno;
            try
            {
                using (SqlConnection conexion = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=TP4;Trusted_Connection=True;"))
                {
                    string comandoStr = "INSERT INTO TP_4(Talle, Equipacion, Numero, MangaOBolsillo, EsCamiseta) VALUES(@talle, @equipacion, @numero, @mangaOBolsillo, @esCamiseta)";

                    SqlCommand comando = new SqlCommand(comandoStr, conexion);
                    comando.Parameters.AddWithValue("talle", pantalon.Talle);
                    comando.Parameters.AddWithValue("equipacion", pantalon.Equipacion);
                    comando.Parameters.AddWithValue("numero", pantalon.Numero);

                    if(pantalon.conBolsillo == true)
                        comando.Parameters.AddWithValue("mangaOBolsillo", 1);
                    else
                        comando.Parameters.AddWithValue("mangaOBolsillo", 1);

                    comando.Parameters.AddWithValue("esCamiseta", 0);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
