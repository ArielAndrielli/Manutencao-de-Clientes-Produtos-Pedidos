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
    public partial class I_CadProduto2 : Form
    {
        #region Construtor

        public I_CadProduto2()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Produto oProduto = new Produto();

        #endregion

        #region Propriedades

        public string ModoExecucao { get; set; }
        public int Id { get; set; }

        #endregion

        #region Metodos

        private void PopularProduto()
        {
            oProduto.SelecionarP(Id);

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtId.Text = oProduto.Id_prod.ToString();
            txtNome.Text = oProduto.Nome_prod.Trim();
            txtDescricao.Text = oProduto.Desc.Trim();
        }

        private void PreencherProduto()
        {
            oProduto.Nome_prod = txtNome.Text.Trim();
            oProduto.Desc = txtDescricao.Text.Trim();
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;

            txtId.Enabled = true;
        }

        #endregion

        #region Eventos

        private void I_ManProduto_Load(object sender, EventArgs e)
        {
            if (ModoExecucao == "Incluir")
            {
                this.Text += " - Incluir";
            }
            else if (ModoExecucao == "Alterar")
            {
                this.Text += " - Alterar";

                txtId.Enabled = false;

                PopularProduto();
            }
            else if (ModoExecucao == "Visualizar")
            {
                this.Text += " - Visualizar";

                txtId.Enabled = false;
                txtNome.Enabled = false;
                txtDescricao.Enabled = false;
                btnSalvar.Enabled = false;

                PopularProduto();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtNome.Text.Trim() == string.Empty
                || txtDescricao.Text.Trim().Replace(".", "").Replace("-", "").Replace("_", "") == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtId.Text.Trim(), out int id);

            if (ModoExecucao == "Incluir")
                id = 0;

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

            PreencherProduto();

            if (ModoExecucao == "Incluir")
            {
                #region Incluir

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
            }
            else if (ModoExecucao == "Alterar")
            {
                #region Alterar

                oProduto.AlterarP();

                if (oProduto.HasError)
                {
                    MessageBox.Show(oProduto.MsgError, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show("Registro atualizado com sucesso!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion
            }

            #endregion

            LimparCampos();

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
