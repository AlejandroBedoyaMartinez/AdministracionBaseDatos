using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cuerpo;
using baseDeDatos;
using MetroFramework.Forms;
using MetroFramework;
namespace practica1
{

    public partial class frmMenu : MetroForm
    {
        List<clsInventario> clsInventario = new List<clsInventario>();
        public frmMenu()
        {
            InitializeComponent();
            llenarTabla();
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;   
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmInventario frmInventario = new frmInventario(true,0,0);
            frmInventario.ShowDialog();
            llenarTabla();
        }

        public void llenarTabla()
        {
            clsInventario.Clear();
            consultas consulta = new consultas();
            clsInventario = consulta.obtenerInventarios();
            dgvInventario.DataSource = null;
            dgvInventario.DataSource = clsInventario;
            dgvInventario.Columns[0].Visible = false;
            dgvInventario.Columns[1].Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventario.SelectedRows[0].Index >= 0)
                {
                    frmInventario frmInventario = new frmInventario(false, clsInventario[dgvInventario.SelectedRows[0].Index].Areas_ID, clsInventario[dgvInventario.SelectedRows[0].Index].id);
                    frmInventario.ShowDialog();
                    llenarTabla();
                    return;
                }
                MetroMessageBox.Show(this, "No se ha seleccionado ninguna fila" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "No se ha seleccionado ninguna fila" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventario.SelectedRows.Count > 0)
                {
                    consultas consulta = new consultas();
                    bool si = consulta.borrarInventario(clsInventario[dgvInventario.SelectedRows[0].Index].id);
                    if (si)
                    {
                        MetroMessageBox.Show(this,"Se ha borrado correctamente", "Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        llenarTabla();
                        return;
                    }
                    MetroMessageBox.Show(this, "Algo ha salido mal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MetroMessageBox.Show(this, "No se ha seleccionado ninguna fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "No se ha seleccionado ninguna fila", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
