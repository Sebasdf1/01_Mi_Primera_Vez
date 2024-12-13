using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            /*
            Ejemplo de colores:
            black
            green
            white
            
            rgb (red, green, blue) - Valores: 0-255
            rgba (red, green, blue, transparencia)
            */
        }

        // Evento del botón Personal
        private void button2_Click(object sender, EventArgs e)
        {
            // Cargar el UserControl CUPersonal
            CUPersonal frmPrueba = new CUPersonal();
            PanelGeneral.Controls.Clear(); // Limpiar panel principal
            frmPrueba.Dock = DockStyle.Fill; // Ajustar al tamaño del panel
            PanelGeneral.Controls.Add(frmPrueba); // Agregar el control al panel
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Aquí puedes definir qué sucede al hacer clic en el label (si es necesario)
        }

        // Evento del botón Asistencia
        private void button1_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para el botón de asistencia
        }

        // Evento del botón Usuarios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Cargar el UserControl CUUsuarios
            CUUsuarios frmUsuarios = new CUUsuarios();
            PanelGeneral.Controls.Clear(); // Limpiar el panel principal
            frmUsuarios.Dock = DockStyle.Fill; // Ajustar al tamaño del panel
            PanelGeneral.Controls.Add(frmUsuarios); // Agregar el control al panel
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Código a ejecutar cuando se cargue el formulario
        }
    }
}

/*
Descripción de controles usados:

- btnUsuarios: Botón para acceder a la interfaz de usuarios.
- txtNombre: Campo de texto para buscar usuarios (en CUUsuarios).
- lstUsuarios: Listado de usuarios (en CUUsuarios).
*/
