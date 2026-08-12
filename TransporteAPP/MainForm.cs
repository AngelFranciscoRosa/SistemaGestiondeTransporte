using System;
using System.Drawing;
using System.Windows.Forms;
using Transporteapp.Entities.TransporteApp.Entities;

namespace TransporteAPP
{
    public partial class MainForm : Form
    {
        private Usuario usuarioActual;

        public MainForm(Usuario user)
        {
            InitializeComponent(); // 🔥 ESTO ES CLAVE
            usuarioActual = user;
            lblusuario.Text = "Usuario: " + usuarioActual.Username;
            lblhora.Font = new Font("Segoe UI", 35, FontStyle.Bold);
            lblhora.ForeColor = Color.Black;
            lblhora.BackColor = Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (usuarioActual.Rol == "Empleado")
            {
                btnChoferes.Enabled = false;
                btnAutobuses.Enabled = false;
                btnRutas.Enabled = false;
            }
       
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            ChoferForm form = new ChoferForm();
            this.Hide(); 
            form.Show();
        }

        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            AutobusForm form2 = new AutobusForm ();
            this.Hide(); 
            form2.Show();
        }

        private void btnAsignaciones_Click(object sender, EventArgs e)
        {
           AsignacionForm form3 = new AsignacionForm();
            this.Hide(); 
            form3.Show();
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            new RutaForm().Show();
            this.Hide(); //
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm login = new LoginForm();
            login.Show();
        }

    }
}