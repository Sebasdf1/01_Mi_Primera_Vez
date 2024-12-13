using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion.Personal
{
    public partial class Frmpersonal : Form
    {
        public bool modoEdision = false;
        public Frmpersonal(string modo)
        {
            InitializeComponent();
            if (modo != "n") this.modoEdision = true;            
        }

        private void Frmpersonal_Load(object sender, EventArgs e)
        {
            if (!this.modoEdision)
            {
                lblFrmPersonal.Text = "Ingreso de Nuevo Personal";
            }
            else { 
                lblFrmPersonal.Text = "Actualziacion de Personal";
            }
        }
    }
}
