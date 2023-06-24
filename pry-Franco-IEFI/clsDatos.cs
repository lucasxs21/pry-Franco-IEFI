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
        OleDbCommand cmdPais;        
        OleDbDataReader rdrPais;

        private string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb";    

        public void CargarDatos(ComboBox cmbPais)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=EL_CLUB.accdb;";
            cmbPais.SelectedIndex = -1;
            
            try
            {
                cnn = new OleDbConnection(conexion);               
                cmdPais = new OleDbCommand();
                cmdPais.Connection = cnn;
                cmdPais.CommandType = CommandType.TableDirect;
                cmdPais.CommandText = "PAISES";
                cnn.Open();
               

                rdrPais = cmdPais.ExecuteReader();
                
                cmbPais.Items.Clear();
               
                DataTable dtPais = new DataTable();              

                if (rdrPais.HasRows)
                {
                    dtPais.Load(rdrPais);
                    cmbPais.DataSource = dtPais;
                    cmbPais.ValueMember = "Id";
                    cmbPais.DisplayMember = "Pais";
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message, "", MessageBoxButtons.OK);

            }
        }// carga de paises en base de datos

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

        }// registro de datos 

        public bool AgregarPais(string nombrePais)
        {
            // controlar si el país ya existe en la base de datos
            if (ExistePais(nombrePais))
            {
                MessageBox.Show("El país ya existe.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // llamar funcion para insertar en la base de datos
            InsertarPais(nombrePais);

            MessageBox.Show("El país se ha agregado correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }// gestor de validacion de pais y insercion 
    
        private bool ExistePais(string nombrePais) // bandera de reconocimiento si existe o no el pais 
        {
            bool paisEncontrado = false;
       

            cnn = new OleDbConnection(conexion);
            cnn.Open();
            string query = "SELECT Pais FROM PAISES";
            OleDbCommand cmdPais = new OleDbCommand(query, cnn);
            OleDbDataReader reader = cmdPais.ExecuteReader();

            while (reader.Read())
            {
                string pais = reader.GetString(0);
                if (string.Equals(pais, nombrePais, StringComparison.OrdinalIgnoreCase))//comparamos ignorando mayusculas
                {
                    paisEncontrado = true;
                    break;
                }
            }

            cnn.Close();

            return paisEncontrado;
        }

        private void InsertarPais(string nombrePais)
        {
            
            cnn = new OleDbConnection(conexion);
            cnn.Open();
            string query = "INSERT INTO PAISES (Pais) VALUES (@Pais)";
            OleDbCommand cmd = new OleDbCommand(query, cnn);
            cmd.Parameters.AddWithValue("@Pais", nombrePais);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }// insertar en base de datos 




    }
}
