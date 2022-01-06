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

namespace ExemploAcessoDB2
{
    public partial class I_ManCliente : Form
    {
        #region Construtor

        public I_ManCliente()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Cliente oCliente = new Cliente();

        #endregion

        private void I_ManCliente_Load(object sender, EventArgs e)
        {
            DataTable result = oCliente.Listar(string.Empty);
            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvCliente.DataSource = result;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtId.Text.Trim() == string.Empty
                && txtNome.Text.Trim() == string.Empty
                && txtCPF.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtId.Text.Trim(), out int id);

            bool existeCpf = oCliente.ChecarCpf(id, txtCPF.Text.Trim());

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (existeCpf)
            {
                MessageBox.Show("CPF já cadastrado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            #endregion

            #region Operação

            oCliente.Id = id;
            oCliente.Nome = txtNome.Text.Trim();
            oCliente.CPF = txtCPF.Text.Trim();
            oCliente.Incluir();

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Registro incluído com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            #region Tratamento tela

            DataTable result = oCliente.Listar(string.Empty);

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvCliente.DataSource = result;

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;

            #endregion
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtId.Text.Trim() == string.Empty
                && txtNome.Text.Trim() == string.Empty
                && txtCPF.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtId.Text.Trim(), out int id);

            bool existeCpf = oCliente.ChecarCpf(id, txtCPF.Text.Trim());

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (existeCpf)
            {
                MessageBox.Show("CPF já cadastrado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            #endregion

            #region Operação

            oCliente.Id = id;
            oCliente.Nome = txtNome.Text.Trim();
            oCliente.CPF = txtCPF.Text.Trim();
            oCliente.Alterar();

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Registro alterado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            #region Tratamento tela

            DataTable result = oCliente.Listar(string.Empty);

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvCliente.DataSource = result;

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;

            #endregion
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == string.Empty
                && txtNome.Text.Trim() == string.Empty
                && txtCPF.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtId.Text.Trim(), out int id);

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            

            #region Operação

            oCliente.Id = id;
            oCliente.Nome = txtNome.Text.Trim();
            oCliente.CPF = txtCPF.Text.Trim();
            oCliente.Excluir();

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            

            #endregion

            #region Tratamento tela

            DataTable result = oCliente.Listar(string.Empty);

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvCliente.DataSource = result;

            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;

            #endregion
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvCliente.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCPF.Text = row.Cells[2].Value.ToString();
            }
        }

    }




}
