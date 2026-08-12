using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransporteApp.BLL;
using TransporteApp.Entities;

namespace TransporteAPP
{
    public partial class ChoferForm : Form
    {
        public ChoferForm()
        {
            InitializeComponent();
        }

        ChoferService service = new ChoferService();
        private int idSeleccionado = 0;
        private void CargarChoferes()
        {
            dgvChoferes.DataSource = service.Listar();
        }

        private void ChoferForm_Load(object sender, EventArgs e)
        {
            CargarChoferes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Chofer c = new Chofer
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFecha.Value,
                Cedula = txtCedula.Text
            };

            service.Insertar(c);

            MessageBox.Show("Chofer guardado");

            CargarChoferes();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarChoferes();
        }

        private void dgvChoferes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvChoferes.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["IdChofer"].Value);

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["FechaNacimiento"].Value);
                txtCedula.Text = fila.Cells["Cedula"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Chofer c = new Chofer
            {
                IdChofer = idSeleccionado,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                FechaNacimiento = dtpFecha.Value,
                Cedula = txtCedula.Text
            };

            service.Actualizar(c);

            MessageBox.Show("Chofer actualizado");

            CargarChoferes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            service.Eliminar(idSeleccionado);

            MessageBox.Show("Chofer eliminado");

            CargarChoferes();
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

