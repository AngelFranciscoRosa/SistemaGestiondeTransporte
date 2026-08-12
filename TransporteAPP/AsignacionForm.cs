using System;
using System.Windows.Forms;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP
{
    public partial class AsignacionForm : Form
    {
        AsignacionService service = new AsignacionService();

        public AsignacionForm()
        {
            InitializeComponent();
        }
        public AsignacionForm(Form form)
        {
            InitializeComponent();
    
        }
        private void AsignacionForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarAsignaciones();
        }
        private void CargarAsignaciones()
        {
            dgvAsignaciones.DataSource = service.ListarAsignaciones();
        }

        private void CargarCombos()
        {
            // 🔹 Choferes
            cbChofer.DataSource = service.GetChoferesDisponibles();
            cbChofer.DisplayMember = "Nombre";
            cbChofer.ValueMember = "IdChofer";

            // 🔹 Autobuses
            cbAutobus.DataSource = service.GetAutobusesDisponibles();
            cbAutobus.DisplayMember = "Placa";
            cbAutobus.ValueMember = "IdAutobus";

            // 🔹 Rutas
            cbRuta.DataSource = service.GetRutasDisponibles();
            cbRuta.DisplayMember = "Nombre";
            cbRuta.ValueMember = "IdRuta";

            if (cbRuta.Items.Count == 0)
            {
                MessageBox.Show("No hay rutas disponibles");
            }

            if (cbAutobus.Items.Count==0)
            {
                MessageBox.Show("No hay Autobuses Disponibles");
            }

             if (cbChofer.Items.Count==0)
            {
                MessageBox.Show("No hay Choferes Disponibles");
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            Asignacion a = new Asignacion
            {
                IdChofer = (int)cbChofer.SelectedValue,
                IdAutobus = (int)cbAutobus.SelectedValue,
                IdRuta = (int)cbRuta.SelectedValue
            };

            service.Insertar(a);

            MessageBox.Show("Asignación realizada");

            // 🔄 Recargar combos (ya no deben aparecer los usados)
            CargarCombos();
            CargarAsignaciones(); // 🔥 IMPORTANTE
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is MainForm)
                {
                    f.Show(); // 👈 vuelve a mostrar dashboard
                    break;
                }
            }

            this.Close(); // 👈 cierra el form actual  
        }

    }

}