using ExemploAcessoDB2.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploAcessoDB2.Forms.Pedidos
{
    public partial class I_ManPedidos2 : Form
    {
        #region Construtor

        public I_ManPedidos2()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Pedido oPedido = new Pedido();
        private PDP oPDP = new PDP();

        #endregion

        #region Propriedades

        public int Id_cbb { get; set; } = 0;

        public int Id_cli_cbb { get; set; } = 0;

        #endregion

        #region Métodos

        private void Popular_dgvPedidos()
        {

            int.TryParse(txtPesquisar.Text.Trim(), out int id);
            int.TryParse(txtPesquisar.Text.Trim(), out int idPedido);

            DataTable result = null;

            if (cbbPor.Text == "ID")
            {
                result = oPedido.ListarPorIdPedido(idPedido);
            }
            else if (cbbPor.Text == "ID Cliente")
            {
                result = oPedido.ListarPorId(id);
            }

            if (oPedido.HasError)
            {
                MessageBox.Show(oPedido.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvPedidos.DataSource = result;
        }

        #endregion

        #region Eventos

        private void I_ManPedidos2_Load(object sender, EventArgs e)
        {
            cbbPor.SelectedIndex = 0;

            Popular_dgvPedidos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Popular_dgvPedidos();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            I_CadPedidos2 i_CadPedidos2 = new I_CadPedidos2();
            i_CadPedidos2.ModoExecucao = "Incluir";
            i_CadPedidos2.ShowDialog();

            Popular_dgvPedidos();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            I_CadPedidos2 i_CadPedidos2 = new I_CadPedidos2();
            i_CadPedidos2.ModoExecucao = "Alterar";

            int.TryParse(dgvPedidos.SelectedRows[0].Cells["Id_pedido"].Value.ToString(), out int id);

            i_CadPedidos2.Id = id;
            i_CadPedidos2.ShowDialog();

            Popular_dgvPedidos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir este registro?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int.TryParse(dgvPedidos.SelectedRows[0].Cells["Id_pedido"].Value.ToString(), out int id);

                oPedido.Id_pedido = id;
                oPedido.Remover();
                MessageBox.Show("Registro excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Popular_dgvPedidos();
            }

            foreach (DataGridViewRow item in dgvPedidos.Rows)
            {
                oPDP = new PDP();
                oPDP.Id_pedido = oPedido.Id_pedido;
                oPDP.Id_produto = int.Parse(item.Cells[0].Value.ToString());
                oPDP.Excluir();
            }

            // PEGA TODOS OS ITENS DO PEDIDO QUE ESTÁ SENDO EXCLUÍDO E EXCLUI
            DataTable listagem = oPDP.ListarPorId(oPedido.Id_pedido);
            foreach (DataRow item in listagem.Rows)
            {
                oPDP.Id = item.Field<int>("Id");
                oPDP.Excluir();
            }



        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            I_CadPedidos2 i_CadPedidos2 = new I_CadPedidos2();
            i_CadPedidos2.ModoExecucao = "Visualizar";

            int.TryParse(dgvPedidos.SelectedRows[0].Cells["Id_pedido"].Value.ToString(), out int id);

            i_CadPedidos2.Id = id;
            i_CadPedidos2.ShowDialog();

            Popular_dgvPedidos();
        }

        private void cbbPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Popular_dgvPedidos();
        }

        #endregion

    }
}
