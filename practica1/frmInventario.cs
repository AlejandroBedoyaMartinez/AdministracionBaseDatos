using baseDeDatos;
using cuerpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;
namespace practica1
{
    public partial class frmInventario : MetroForm
    {
        Boolean agregando;
        List<clsInventario> clsInventario = new List<clsInventario>();
        List<clsAreas> clsAreas = new List<clsAreas>();
        int idArea;
        int idInventario;
        public frmInventario(Boolean agregando, int idArea,int idInventario )
        {
            InitializeComponent();
            this.agregando = agregando;
            this.idArea = idArea;
            this.idInventario = idInventario;
            llenarCombobox();
            llenarDatos();
        }

        public void inicializarElementos()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtColor.Text = "";
            txtObeservaciones.Text = "";
            txtSerie.Text = "";
            cbxArea.SelectedIndex = 0;
            cbxTipoAdquisicion.SelectedIndex = 0;
        }
        public void llenarDatos()
        {
            if (!agregando)
            {
                consultas consulta = new consultas();
                clsInventario = consulta.buscarInventario(idInventario);
                txtNombre.Text = clsInventario[0].nombreCorto;
                txtDescripcion.Text = clsInventario[0].descirpcion;
                txtSerie.Text = clsInventario[0].serie;
                txtColor.Text = clsInventario[0].color;
                dtmCalendario.Text = clsInventario[0].fechaAdquisicion;
                txtObeservaciones.Text = clsInventario[0].observaciones;
                int adquision = cbxTipoAdquisicion.FindStringExact(clsInventario[0].tipoAdquision.Trim());
                cbxTipoAdquisicion.SelectedIndex = adquision;
            }
            else
            {
                inicializarElementos();
            }
            return;
        }
       public void llenarCombobox()
        {
            consultas consulta = new consultas();
            clsAreas = consulta.obtenerAreas();
            cbxArea.DataSource = null;
            cbxArea.DisplayMember = "nombre";
            cbxArea.ValueMember = "id";
            cbxArea.DataSource = clsAreas;
            cbxArea.SelectedIndex = idArea-1;

            cbxTipoAdquisicion.Items.Add("Muestra de proveedor");
            cbxTipoAdquisicion.Items.Add("Compra");
            cbxTipoAdquisicion.Items.Add("Devolucion del cliente");
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            consultas consulta = new consultas();
            Boolean validar = false;
            if (txtNombre.Text.Equals("") || txtDescripcion.Text.Equals("") || txtColor.Text.Equals("") || txtObeservaciones.Text.Equals("") || txtSerie.Text.Equals(""))
            {
                validar = true;
            }
            if (validar)
            {
                MetroMessageBox.Show(this, "No pueden existir campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (agregando)
            {
                try
                {
                    if (consulta.agregarInventario(txtNombre.Text, txtDescripcion.Text, txtSerie.Text, txtColor.Text, dtmCalendario.Value.ToString("yyyy-MM-dd"), cbxTipoAdquisicion.SelectedItem.ToString(), txtObeservaciones.Text, cbxArea.SelectedIndex + 1))
                    {
                        MetroMessageBox.Show(this, "Se ha agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "Algo ha salido mal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                if (consulta.actualizarInventario(clsInventario[0].id, txtNombre.Text, txtDescripcion.Text, txtSerie.Text, txtColor.Text, dtmCalendario.Value.ToString("yyyy-MM-dd"), cbxTipoAdquisicion.SelectedItem.ToString(), txtObeservaciones.Text, cbxArea.SelectedIndex + 1))
                {
                    MetroMessageBox.Show(this, "Se ha actualizado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MetroMessageBox.Show(this, "Algo ha salido mal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
