using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using TransporteApp.BLL;
using TransporteApp.DAL.Connection;
using DbConn = TransporteApp.DAL.Connection.DbConnection;
namespace TransporteAPP
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioService service = new UsuarioService();

            var user = service.Login(txtUser.Text, txtPass.Text);

            if (user != null)
            {
                MainForm main = new MainForm(user);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
