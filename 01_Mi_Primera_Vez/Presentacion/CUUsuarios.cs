using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class CUUsuarios : UserControl
    {
        // Lista para almacenar los usuarios
        private List<Usuario> listaUsuarios = new List<Usuario>();

        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuscarUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario FrmAgregarUsuario
            FrmAgregarUsuario frmAgregar = new FrmAgregarUsuario();

            // Mostrar el formulario como cuadro de diálogo
            frmAgregar.ShowDialog();
        }

        private void CUUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}

