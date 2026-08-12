using System;
using System.Windows.Forms;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP
{
    public partial class RutaForm : Form
    {
        RutaService service = new RutaService();
        int idSeleccionado = 0;

        public RutaForm()
        {
            InitializeComponent();
        }

        private void RutaForm_Load(object sender, EventArgs e)
        {
            CargarRutas();
        }

        private void CargarRutas()
        {
            dgvRutas.DataSource = service.Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            service.Insertar(new Ruta { Nombre = txtNombre.Text });

            MessageBox.Show("Ruta guardada");
            CargarRutas();
        }

        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvRutas.Rows[e.RowIndex];

                idSeleccionado = (int)fila.Cells["IdRuta"].Value;
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            service.Actualizar(new Ruta
            {
                IdRuta = idSeleccionado,
                Nombre = txtNombre.Text
            });

            MessageBox.Show("Ruta actualizada");
            CargarRutas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.Eliminar(idSeleccionado);

            MessageBox.Show("Ruta eliminada");
            CargarRutas();
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