using System;
using System.Windows.Forms;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP
{
    public partial class AutobusForm : Form
    {
        AutobusService service = new AutobusService();
        private int idSeleccionado = 0;


    public AutobusForm()
        {
            InitializeComponent();
        }

        private void AutobusForm_Load(object sender, EventArgs e)
        {
            CargarAutobuses();
        }

        private void CargarAutobuses()
        {
            dgvAutobuses.DataSource = service.Listar();
        }

        // INSERTAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Autobus a = new Autobus
            {
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                Color = txtColor.Text,
                Anio = int.Parse(txtAnio.Text)
            };

            service.Insertar(a);

            MessageBox.Show("Autobús guardado");
            LimpiarCampos();
            CargarAutobuses();
        }

        // SELECCIONAR FILA
        private void dgvAutobuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvAutobuses.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["IdAutobus"].Value);

                txtMarca.Text = fila.Cells["Marca"].Value.ToString();
                txtModelo.Text = fila.Cells["Modelo"].Value.ToString();
                txtPlaca.Text = fila.Cells["Placa"].Value.ToString();
                txtColor.Text = fila.Cells["Color"].Value.ToString();
                txtAnio.Text = fila.Cells["Anio"].Value.ToString();
            }
        }

        // EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Autobus a = new Autobus
            {
                IdAutobus = idSeleccionado,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                Placa = txtPlaca.Text,
                Color = txtColor.Text,
                Anio = int.Parse(txtAnio.Text)
            };

            service.Actualizar(a);

            MessageBox.Show("Autobús actualizado");
            LimpiarCampos();
            CargarAutobuses();
        }

        // ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.Eliminar(idSeleccionado);

            MessageBox.Show("Autobús eliminado");
            LimpiarCampos();
            CargarAutobuses();
        }

        // LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtPlaca.Clear();
            txtColor.Clear();
            txtAnio.Clear();
            idSeleccionado = 0;
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
