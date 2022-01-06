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
    public partial class I_ManProduto2 : Form
    {
        #region Constructor
        public I_ManProduto2()
        {
            InitializeComponent();
        }
        #endregion

        #region Atributos

        private Produto oProduto = new Produto();

        #endregion

        #region Propriedades

        public int Id_cbb { get; set; } = 0;
        public string Nome_cbb { get; set; } = string.Empty;
        public string Desc_cbb { get; set; } = string.Empty;

        #endregion

        #region Metodos

        private void Popular_dgvProdutos()
        {
            string nome = txtPesquisar.Text.Trim() + "%";
            string desc = txtPesquisar.Text.Trim() + "%";
            int.TryParse(txtPesquisar.Text.Trim(), out int id);

            DataTable result = null;

            if (cbbPor.Text == "Nome")
            {
                result = oProduto.ListarPorNome(nome);
            }
            else if (cbbPor.Text == "Descrição")
            {
                result = oProduto.ListarPorDesc(desc);
            }
            else
            {
                result = oProduto.ListarPorId(id);
            }

            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvProdutos.DataSource = result;

            #region Exemplo
            //exemplo

            //bool gosto = false;
            //string cor = "branco";
            //string cor2 = "azul";

            //if (cor == "azul")
            //{
            //    gosto = true;
            //}
            //else
            //{
            //    if (cor2 == "azul")
            //    {
            //        gosto = true;
            //    }
            //    else
            //    {
            //        gosto = false;
            //    }
            //}

            //gosto = (cor == "azul") ? true : false;
            //gosto = (cor == "azul") ? true : (cor2 == "azul") ? true : false;
            #endregion
        }

        #endregion

        #region Eventos

        private void I_ManProduto_Load(object sender, EventArgs e)
        {
            cbbPor.SelectedIndex = 0;

            Popular_dgvProdutos();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Popular_dgvProdutos();
        }   

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            I_CadProduto2 i_CadProduto2 = new I_CadProduto2();
            i_CadProduto2.ModoExecucao = "Incluir";
            i_CadProduto2.ShowDialog();

            Popular_dgvProdutos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            I_CadProduto2 i_CadProduto2 = new I_CadProduto2();
            i_CadProduto2.ModoExecucao = "Alterar";

            int.TryParse(dgvProdutos.SelectedRows[0].Cells["Id_produto"].Value.ToString(), out int id);

            i_CadProduto2.Id = id;
            i_CadProduto2.ShowDialog();

            Popular_dgvProdutos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Deseja excluir este registro?",
                "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                int.TryParse(dgvProdutos.SelectedRows[0].Cells["Id_produto"].Value.ToString(), out int id);

                oProduto.Id_prod = id;
                oProduto.ExcluirP();
                MessageBox.Show("Registro excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Popular_dgvProdutos();
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            I_CadProduto2 i_CadProduto2 = new I_CadProduto2();
            i_CadProduto2.ModoExecucao = "Visualizar";

            int.TryParse(dgvProdutos.SelectedRows[0].Cells["Id_produto"].Value.ToString(), out int id);

            i_CadProduto2.Id = id;
            i_CadProduto2.ShowDialog();

            Popular_dgvProdutos();
        }

        private void cbbPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Popular_dgvProdutos();
        }

        #endregion


    }
}
