using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Agrega las librerías necesarias para SQL
using System.Data.SqlClient;
using System.Configuration;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class FrmAgregarUsuario : Form
    {
        public FrmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void FrmAgregarUsuario_Load(object sender, EventArgs e)
        {
            // Puedes agregar inicializaciones aquí si son necesarias.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Validar que todos los campos estén llenos.
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                string.IsNullOrWhiteSpace(txtPais.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener la cadena de conexión desde App.config
            string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();

                    // 3. Definir la consulta INSERT
                    string sql = @"INSERT INTO Usuarios (Nombres, Apellidos, CorreoElectronico, NumeroCelular, Pais, NumeroCedula)
                                   VALUES (@Nombres, @Apellidos, @CorreoElectronico, @NumeroCelular, @Pais, @NumeroCedula)";

                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        // 4. Pasar los valores desde los TextBox
                        comando.Parameters.AddWithValue("@Nombres", txtNombres.Text);
                        comando.Parameters.AddWithValue("@Apellidos", txtApellidos.Text);
                        comando.Parameters.AddWithValue("@CorreoElectronico", txtCorreo.Text);
                        comando.Parameters.AddWithValue("@NumeroCelular", txtCelular.Text);
                        comando.Parameters.AddWithValue("@Pais", txtPais.Text);
                        comando.Parameters.AddWithValue("@NumeroCedula", txtCedula.Text);

                        // 5. Ejecutar la consulta
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar los campos después de guardar
                        LimpiarCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para limpiar los campos después de agregar un usuario
        private void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCorreo.Clear();
            txtCelular.Clear();
            txtPais.Clear();
            txtCedula.Clear();
            txtNombres.Focus();
        }
    }
}
