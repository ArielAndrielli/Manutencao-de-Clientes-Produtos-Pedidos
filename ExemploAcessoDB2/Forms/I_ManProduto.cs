using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExemploAcessoDB2
{
    public partial class I_ManProduto : Form
    {
        #region Construtor

        public I_ManProduto()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Produto oProduto = new Produto();

        #endregion

        #region Métodos
        
        #endregion

        #region Eventos

        private void I_ManProduto_Load(object sender, EventArgs e)
        {
            DataTable result = oProduto.ListarProd(string.Empty);
            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvProduto.DataSource = result;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtIdProduto.Text.Trim() == string.Empty
                && txtNomeProduto.Text.Trim() == string.Empty
                && txtDescricaoProduto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtIdProduto.Text.Trim(), out int id);

            bool existeId = oProduto.ChecarId(id);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (existeId)
            {
                MessageBox.Show("ID já cadastrado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            #endregion

            #region Operação

            oProduto.Id_prod = id;
            oProduto.Nome_prod = txtNomeProduto.Text.Trim();
            oProduto.Desc = txtDescricaoProduto.Text.Trim();
            oProduto.IncluirP();

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Registro incluído com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            #region Tratamento tela

            DataTable result = oProduto.ListarProd(string.Empty);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvProduto.DataSource = result;

            txtIdProduto.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtDescricaoProduto.Text = string.Empty;

            #endregion
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtIdProduto.Text.Trim() == string.Empty
                && txtNomeProduto.Text.Trim() == string.Empty
                && txtDescricaoProduto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtIdProduto.Text.Trim(), out int id);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            #region Operação

            oProduto.Id_prod = id;
            oProduto.Nome_prod = txtNomeProduto.Text.Trim();
            oProduto.Desc = txtDescricaoProduto.Text.Trim();
            oProduto.ExcluirP();

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Registro deletado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            #region Tratamento tela

            DataTable result = oProduto.ListarProd(string.Empty);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvProduto.DataSource = result;

            txtIdProduto.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtDescricaoProduto.Text = string.Empty;

            #endregion
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtIdProduto.Text.Trim() == string.Empty
                && txtNomeProduto.Text.Trim() == string.Empty
                && txtDescricaoProduto.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtIdProduto.Text.Trim(), out int id);

            bool existeId = oProduto.ChecarId(id);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (existeId)
            {
                MessageBox.Show("ID já cadastrado", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            #endregion

            #region Operação

            oProduto.Id_prod = id;
            oProduto.Nome_prod = txtNomeProduto.Text.Trim();
            oProduto.Desc = txtDescricaoProduto.Text.Trim();
            oProduto.AlterarP();

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Registro altualizado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion

            #region Tratamento tela

            DataTable result = oProduto.ListarProd(string.Empty);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dgvProduto.DataSource = result;

            txtIdProduto.Text = string.Empty;
            txtNomeProduto.Text = string.Empty;
            txtDescricaoProduto.Text = string.Empty;

            #endregion
        }

        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dgvProduto.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtIdProduto.Text = row.Cells[0].Value.ToString();
                txtNomeProduto.Text = row.Cells[1].Value.ToString();
                txtDescricaoProduto.Text = row.Cells[2].Value.ToString();
            }
        }

        #endregion
    }
}