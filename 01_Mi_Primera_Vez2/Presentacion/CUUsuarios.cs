using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUUsuarios : UserControl
    {
        // Lista para almacenar los usuarios (si necesitas en memoria)
        private List<Usuario> listaUsuarios = new List<Usuario>();

        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void CUUsuarios_Load(object sender, EventArgs e)
        {
            ProbarConexion();
            CargarUsuarios();
        }

        // Método para probar la conexión a la base de datos
        private void ProbarConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa con la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }

        // Método para cargar todos los usuarios en el DataGridView
        private void CargarUsuarios()
        {
            string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Usuarios";
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Asignar los resultados al DataGridView
                        dgvUsuarios.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        // Método para buscar usuarios por nombre
        private void btnBuscarUsuarios_Click(object sender, EventArgs e)
        {
            string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    conexion.Open();
                    string sql = "SELECT * FROM Usuarios WHERE Nombres LIKE @filtro";
                    using (SqlCommand comando = new SqlCommand(sql, conexion))
                    {
                        comando.Parameters.AddWithValue("@filtro", $"%{txtBuscarUsuarios.Text}%");
                        SqlDataAdapter adapter = new SqlDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Asignar los resultados al DataGridView
                        dgvUsuarios.DataSource = dt;

                        MessageBox.Show("Búsqueda realizada correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar usuarios: " + ex.Message);
            }
        }

        // Método para abrir el formulario de agregar usuarios
        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmAgregarUsuario frmAgregar = new FrmAgregarUsuario();
            frmAgregar.ShowDialog();
            CargarUsuarios(); // Recargar los usuarios después de agregar
        }

        // Método para editar un usuario
        private void botonEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadena))
                    {
                        conexion.Open();

                        // Obtener datos de la fila seleccionada
                        int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
                        string nombres = dgvUsuarios.SelectedRows[0].Cells["Nombres"].Value.ToString();
                        string apellidos = dgvUsuarios.SelectedRows[0].Cells["Apellidos"].Value.ToString();
                        string correo = dgvUsuarios.SelectedRows[0].Cells["CorreoElectronico"].Value.ToString();
                        string celular = dgvUsuarios.SelectedRows[0].Cells["NumeroCelular"].Value.ToString();
                        string pais = dgvUsuarios.SelectedRows[0].Cells["Pais"].Value.ToString();
                        string cedula = dgvUsuarios.SelectedRows[0].Cells["NumeroCedula"].Value.ToString();

                        // Consulta UPDATE
                        string sql = @"UPDATE Usuarios 
                                       SET Nombres = @nombres, Apellidos = @apellidos, CorreoElectronico = @correo,
                                           NumeroCelular = @celular, Pais = @pais, NumeroCedula = @cedula
                                       WHERE IdUsuario = @idUsuario";

                        using (SqlCommand comando = new SqlCommand(sql, conexion))
                        {
                            comando.Parameters.AddWithValue("@nombres", nombres);
                            comando.Parameters.AddWithValue("@apellidos", apellidos);
                            comando.Parameters.AddWithValue("@correo", correo);
                            comando.Parameters.AddWithValue("@celular", celular);
                            comando.Parameters.AddWithValue("@pais", pais);
                            comando.Parameters.AddWithValue("@cedula", cedula);
                            comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                            comando.ExecuteNonQuery();
                            MessageBox.Show("Usuario editado correctamente.");
                            CargarUsuarios();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar usuario: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para editar.");
            }
        }

        // Método para eliminar un usuario
        private void botonEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string cadena = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadena))
                    {
                        conexion.Open();

                        // Obtener el IdUsuario de la fila seleccionada
                        int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

                        // Consulta DELETE
                        string sql = "DELETE FROM Usuarios WHERE IdUsuario = @idUsuario";

                        using (SqlCommand comando = new SqlCommand(sql, conexion))
                        {
                            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Usuario eliminado correctamente.");
                            CargarUsuarios();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.");
            }
        }
    }
}

