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
    public partial class I_CadCliente2 : Form
    {
        #region Construtor

        public I_CadCliente2()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Cliente oCliente = new Cliente();

        #endregion

        #region Propriedades

        public string ModoExecucao { get; set; }
        public int Id { get; set; }

        #endregion

        #region Metodos

        private void PopularCliente()
        {
            oCliente.Selecionar(Id);

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtId.Text = oCliente.Id.ToString();
            txtNome.Text = oCliente.Nome.Trim();
            txtCPF.Text = oCliente.CPF.Trim();
        }

        private void PreencherCliente()
        {
            
            oCliente.Nome = txtNome.Text.Trim();
            oCliente.CPF = txtCPF.Text.Trim().Replace(".", "").Replace(",", "").Replace("-", "").Replace("_", "");
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCPF.Text = string.Empty;

            txtId.Enabled = true;
        }

        #endregion

        #region Eventos

        private void I_ManCliente_Load(object sender, EventArgs e)
        {
            if (ModoExecucao == "Incluir")
            {
                this.Text += " - Incluir";
            }
            else if (ModoExecucao == "Alterar")
            {
                this.Text += " - Alterar";

                txtId.Enabled = false;

                PopularCliente();
            }
            else if (ModoExecucao == "Visualizar")
            {
                this.Text += " - Visualizar";

                txtId.Enabled = false;
                txtNome.Enabled = false;
                txtCPF.Enabled = false;
                btnSalvar.Enabled = false;

                PopularCliente();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtNome.Text.Trim() == string.Empty
                || txtCPF.Text.Replace(",", "").Replace(".", "").Replace("-", "").Replace("_", "").Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            int.TryParse(txtId.Text.Trim(), out int id);

            if (ModoExecucao == "Incluir")
                id = 0;

            if (Cliente.ValidaCPF(txtCPF.Text))
            {
                MessageBox.Show("CPF Válido!");
            }
            else
            {
                MessageBox.Show("CPF Inválido!");
                return;
            }

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

            PreencherCliente();

            if (ModoExecucao == "Incluir")
            {
                #region Incluir

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
            }
            else if (ModoExecucao == "Alterar")
            {
                #region Alterar

                oCliente.Alterar();

                if (oCliente.HasError)
                {
                    MessageBox.Show(oCliente.MsgError, "Erro",
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
