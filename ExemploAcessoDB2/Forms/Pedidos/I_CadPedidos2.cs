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
    public partial class I_CadPedidos2 : Form
    {
        #region Construtor

        public I_CadPedidos2()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Pedido oPedido = new Pedido();
        private Cliente oCliente = new Cliente();
        private Produto oProduto = new Produto();
        private PDP oPDP = new PDP();

        #endregion

        #region Propriedades

        public string ModoExecucao { get; set; }
        public int Id { get; set; }
        public string nome { get; set; }

        #endregion

        #region Métodos

        private void PopularPedido()
        {
            oPedido.Selecionar(Id);
            if (oPedido.HasError)
            {
                MessageBox.Show(oPedido.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtId.Text = oPedido.Id_pedido.ToString();
            txtIdCliente.Text = oPedido.Id_cli.ToString();

            oCliente.Selecionar(oPedido.Id_cli);
            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtNomeCliente.Text = oCliente.Nome;
            txtCPFCliente.Text = oCliente.CPF;


            
        }

        private void IJ()
        {            
            oPDP.InnerJoin();

            if (oPDP.HasError)
            {
                MessageBox.Show(oPDP.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Popular_dgvPedidos()
        {
            DataTable result = oPDP.ListarPorId(Id);
            //DataTable result2 = oPDP.InnerJoin();
            if (oPDP.HasError)
            {
                MessageBox.Show(oPDP.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (DataRow item in result.Rows)
            {
                dgvProdutos.Rows.Add(
                    item.Field<int>("Id_produto").ToString(),
                    item.Field<string>("nome_produto").ToString());
            }

            /*foreach (DataRow item2 in result2.Rows)
            {
                dgvProdutos.Rows.Add(item2.Field<string>("nome_produto"));
            }*/
        }

        private void PreencherPedido()
        {
            int.TryParse(txtIdCliente.Text.Trim(), out int idCli);
            oPedido.Id_cli = idCli;
        }

        private void LimparCampos()
        {
            txtId.Text = string.Empty;
            txtIdCliente.Text = string.Empty;

            txtId.Enabled = true;
        }


        #endregion

        #region Eventos

        private void I_CadPedidos2_Load(object sender, EventArgs e)
        {
            if (ModoExecucao == "Incluir")
            {
                this.Text += " - Incluir";
                lblId.Visible = false;
                txtId.Visible = false;
            }
            else if (ModoExecucao == "Alterar")
            {
                this.Text += " - Alterar";

                txtId.Enabled = false;

                PopularPedido();
                Popular_dgvPedidos();
            }
            else if (ModoExecucao == "Visualizar")
            {
                this.Text += " - Visualizar";

                txtId.Enabled = false;
                txtIdCliente.Enabled = false;
                btnSalvar.Enabled = false;
                txtIdDoProduto.Enabled = false;
                txtNomeProduto.Enabled = false;
                txtDescricaoProduto.Enabled = false;
                btnIncluir.Enabled = false;
                btnRemover.Enabled = false;
                PopularPedido();
                Popular_dgvPedidos();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtIdCliente.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //=======================================================================

            #endregion

            #region Operação

            PreencherPedido();

            if (ModoExecucao == "Incluir")
            {
                #region Incluir

                oPedido.Inserir();
                if (oPedido.HasError)
                {
                    MessageBox.Show(oPedido.MsgError, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                foreach (DataGridViewRow item in dgvProdutos.Rows)
                {
                    oPDP = new PDP();
                    oPDP.Id_pedido = oPedido.Id_pedido;
                    oPDP.Id_produto = int.Parse(item.Cells[0].Value.ToString());
                    oPDP.Incluir();
                }

                MessageBox.Show("Registro incluído com sucesso!",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                #endregion
            }
            else if (ModoExecucao == "Alterar")
            {
                #region Alterar

                oPedido.Alterar();
                if (oPedido.HasError)
                {
                    MessageBox.Show(oPedido.MsgError, "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                oPDP.Id_pedido = Id;
                oPDP.ExcluirPorPedido();

                // CADASTRA NOVAMENTE OS ITENS DO PEDIDO DE ACORDO COM O DATAGRIDVIEW
                foreach (DataGridViewRow item in dgvProdutos.Rows)
                {
                    oPDP = new PDP();
                    oPDP.Id_pedido = oPedido.Id_pedido;
                    oPDP.Id_produto = int.Parse(item.Cells[0].Value.ToString());
                    oPDP.Incluir();
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

        private void txtIdCliente_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtIdCliente.Text.Trim(), out int idcli);

            oCliente.Selecionar(idcli);
            if (oCliente.HasError)
            {
                MessageBox.Show(oCliente.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtNomeCliente.Text = oCliente.Nome;
            txtCPFCliente.Text = oCliente.CPF;
        }

        private void txtIdDoProduto_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(txtIdDoProduto.Text.Trim(), out int idprod);

            oProduto.SelecionarP(idprod);
            if (oProduto.HasError)
            {
                MessageBox.Show(oProduto.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            txtNomeProduto.Text = oProduto.Nome_prod;
            txtDescricaoProduto.Text = oProduto.Desc;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtIdDoProduto.Text == "")
            {
                MessageBox.Show("O produto precisa ser selecionado!", "Aviso");
                return;
            }

            int.TryParse(txtIdDoProduto.Text.Trim(), out int idprod);
            oProduto.SelecionarP(idprod);
            if (oProduto.Id_prod == 0)
            {
                MessageBox.Show("O produto digitado não é válido.", "Aviso");
            }

            // VERIFICA SE JÁ TEM
            int quantidadeDesseProduto = dgvProdutos.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["ID"].Value.ToString().Equals(idprod.ToString()))
                .Count();

            if (quantidadeDesseProduto > 0)
            {
                MessageBox.Show("Esse produto já foi incluído", "Aviso");
                return;
            }

            int indiceLinha = dgvProdutos.Rows.Add();
            dgvProdutos.Rows[indiceLinha].Cells[0].Value = oProduto.Id_prod.ToString();
            dgvProdutos.Rows[indiceLinha].Cells[1].Value = oProduto.Nome_prod.ToString();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum produto a ser removido foi selecionado", "Aviso");
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja excluir este registro?",
               "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                dgvProdutos.Rows.Remove(dgvProdutos.SelectedRows[0]);

                MessageBox.Show("Registro excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        
    }
}
