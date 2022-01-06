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
    public partial class I_ManCliente2 : Form
    {
        #region Construtor

        public I_ManCliente2()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Cliente oCliente = new Cliente();

        #endregion

        #region Metodos

        private void Popular_dgvClientes()
        {
            string nome = txtPesquisar.Text.Trim() + "%";
            string cpf = txtPesquisar.Text.Trim() + "%";
            int.TryParse(txtPesquisar.Text.Trim(), out int id);

            DataTable result = null;

            if (cbbPor.Text == "Nome")
            {
                result = oCliente.ListarPorNome(nome);
            }
            else if (cbbPor.Text == "CPF")
            {
                result = oCliente.ListarPorCpf(cpf);
            }
            else
            {
                result = oCliente.ListarPorId(id);
            }

            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvClientes.DataSource = result;
        }

        #endregion

        #region Eventos

        private void I_ManCliente_Load(object sender, EventArgs e)
        {
            cbbPor.SelectedIndex = 0;

            Popular_dgvClientes();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Popular_dgvClientes();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            I_CadCliente2 i_CadCliente2 = new I_CadCliente2();
            i_CadCliente2.ModoExecucao = "Incluir";
            i_CadCliente2.ShowDialog();

            Popular_dgvClientes();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            I_CadCliente2 i_CadCliente2 = new I_CadCliente2();
            i_CadCliente2.ModoExecucao = "Alterar";

            int.TryParse(dgvClientes.SelectedRows[0].Cells["Id"].Value.ToString(), out int id);

            i_CadCliente2.Id = id;
            i_CadCliente2.ShowDialog();

            Popular_dgvClientes();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("Deseja excluir este registro?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int.TryParse(dgvClientes.SelectedRows[0].Cells["Id"].Value.ToString(), out int id);

                oCliente.Id = id;
                oCliente.Excluir();
                MessageBox.Show("Registro excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Popular_dgvClientes();
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            I_CadCliente2 i_CadCliente2 = new I_CadCliente2();
            i_CadCliente2.ModoExecucao = "Visualizar";

            int.TryParse(dgvClientes.SelectedRows[0].Cells["Id"].Value.ToString(), out int id);

            i_CadCliente2.Id = id;
            i_CadCliente2.ShowDialog();

            Popular_dgvClientes();
        }

        private void cbbPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Popular_dgvClientes();
        }

        #endregion

    }
}
