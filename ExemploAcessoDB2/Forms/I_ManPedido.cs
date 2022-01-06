using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExemploAcessoDB2.Forms.Pedidos
{
    public partial class I_ManPedido : Form
    {

        private Pedido oPedido = new Pedido();
        private Cliente oCliente = new Cliente();

        public I_ManPedido()
        {
            InitializeComponent();
        }

        private void I_CadPedido_Load(object sender, EventArgs e)
        {
            DataTable result = oPedido.Listar();
            if (oPedido.HasError)
            {
                MessageBox.Show(oPedido.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgv_Pedidos.DataSource = result;
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {

            #region Verificações

            if (txtCliente.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtCliente.Text.Trim(), out int id);

            oCliente.Selecionar(id);
            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.txtNome.Text = oCliente.Nome;
            this.txtCpf.Text = oCliente.CPF;

            #endregion

            #region operação



            #endregion

            #region Tratamento tela
            #endregion
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtCliente.Text.Trim() == string.Empty
                && txtPedido.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            int.TryParse(txtPedido.Text.Trim(), out int idP);
            int.TryParse(txtCliente.Text.Trim(), out int idC);

            #endregion

            #region Operação

            oPedido.Id_cli = idC;
            oPedido.Id_pedido = idP;
            oPedido.Inserir();

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Registro incluído com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            DataTable result = oPedido.Listar();

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgv_Pedidos.DataSource = result;

            txtCliente.Text = string.Empty;
            txtPedido.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCpf.Text = string.Empty;
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() == string.Empty && txtPedido.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtCliente.Text.Trim(), out int idC);
            int.TryParse(txtPedido.Text.Trim(), out int idP);

            if (oCliente.HasError)
            {
                MessageBox.Show(oPedido.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            #region Operação

            oPedido.Id_cli = idC;
            oPedido.Id_pedido = idP;
            oPedido.Remover();


            if (oCliente.HasError)
            {
                MessageBox.Show(oPedido.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else
            {
                MessageBox.Show("Registro excluído!");
            }



            #endregion

            #region Tratamento tela

            DataTable result = oPedido.Listar();

            if (oPedido.HasError)
            {
                MessageBox.Show(oPedido.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgv_Pedidos.DataSource = result;

            txtCliente.Text = string.Empty;
            txtPedido.Text = string.Empty;

            #endregion        
        }

        private void dgv_Pedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgv_Pedidos.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtCliente.Text = row.Cells[1].Value.ToString();
                txtPedido.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
