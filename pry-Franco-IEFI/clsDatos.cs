using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Data;


namespace pry_Franco_IEFI
{
    internal class clsDatos
    {
        OleDbConnection cnn;
        OleDbCommand cmd;
        OleDbDataReader rdrVendedor;
        OleDbDataReader rdrProducto;
        OleDbDataReader rdrVentas;

        //public void CargarDatos(ComboBox cmbProducto, ComboBox cmbVendedor)
        //{
        //    string conexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VERDULEROS.mdb;";
        //    cmbProducto.SelectedIndex = -1;
        //    cmbVendedor.SelectedIndex = -1;
        //    try
        //    {
        //        cnn = new OleDbConnection(conexion);
        //        cmdVendedor = new OleDbCommand();
        //        cmdVendedor.Connection = cnn;
        //        cmdVendedor.CommandType = CommandType.TableDirect;
        //        cmdVendedor.CommandText = "Vendedores";

        //        cmdProducto = new OleDbCommand();
        //        cmdProducto.Connection = cnn;
        //        cmdProducto.CommandType = CommandType.TableDirect;
        //        cmdProducto.CommandText = "Productos";
        //        cnn.Open();

        //        rdrVendedor = cmd.ExecuteReader();

        //        rdrProducto = cmdProducto.ExecuteReader();

        //        cmbVendedor.Items.Clear();
        //        cmbProducto.Items.Clear();

        //        DataTable dtVendedor = new DataTable();
        //        DataTable dtProducto = new DataTable();

        //        if (rdrVendedor.HasRows)
        //        {
        //            dtVendedor.Load(rdrVendedor);
        //            cmbVendedor.DataSource = dtVendedor;
        //            cmbVendedor.ValueMember = "IdVendedor";
        //            cmbVendedor.DisplayMember = "NombreVendedor";
        //        }

        //        if (rdrProducto.HasRows)
        //        {
        //            dtProducto.Load(rdrProducto);
        //            cmbProducto.DataSource = dtProducto;
        //            cmbProducto.ValueMember = "IdProducto";
        //            cmbProducto.DisplayMember = "NomProducto";
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

        //    }
        //}

        public void Registrar(string Nombre, string Apellido, string pais, int Edad, bool sexo, decimal ingreso, int puntaje)
        {

            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb;";
            string Sql = "INSERT INTO SOCIOS (NOMBRE, APELLIDO, LUGAR_NACIMIENTO, EDAD, SEXO, INGRESO, PUNTAJE) " +
                     "VALUES (@nombre, @apellido, @lugarNacimiento, @edad, @sexo, @ingreso, @puntaje)";
            try
            {
                cnn = new OleDbConnection(conexion);
                cmd = new OleDbCommand();
                cmd.Connection = cnn;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = Sql;
               
                cmd.Parameters.AddWithValue("@nombre", Nombre);
                cmd.Parameters.AddWithValue("@apellido", Apellido);
                cmd.Parameters.AddWithValue("@lugarNacimiento", pais);
                cmd.Parameters.AddWithValue("@edad", Edad);
                cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.Parameters.AddWithValue("@ingreso", ingreso);
                cmd.Parameters.AddWithValue("@puntaje", puntaje);



                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }



        }

    }
}
