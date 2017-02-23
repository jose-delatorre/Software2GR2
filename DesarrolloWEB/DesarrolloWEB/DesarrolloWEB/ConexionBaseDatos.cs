﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace DesarrolloWEB
{
    public class ConexionBaseDatos
    {
        public void ExecuteNonQuery(string strSQL)
        {
            SqlConnection cnn = null;

            try
            {
                cnn = new SqlConnection(ObtenerCadenaConexion());
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public DataSet ExecuteDataSet(string strSQL)
        {
            DataSet ds = new DataSet();
            SqlConnection cnn = null;


            try
            {
                cnn = new SqlConnection(ObtenerCadenaConexion());

                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;


                cmd.CommandTimeout = 0; // infinito

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds, "Tabla1");
                return ds;
            }

            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }


        }

        private string ObtenerCadenaConexion()
        {
            try
            {


                return "DATA SOURCE = localhost; Initial Catalog = baseWEB; Integrated Security = True;";

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
