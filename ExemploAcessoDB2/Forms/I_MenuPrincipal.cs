using ExemploAcessoDB2.Forms.Pedidos;
using System;
using System.Windows.Forms;

namespace ExemploAcessoDB2
{
    public partial class I_MenuPrincipal : Form
    {

        #region Construtor

        public I_MenuPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void btnCliente_Click(object sender, EventArgs e)
        {
            I_ManCliente manCliente = new I_ManCliente();
            manCliente.MdiParent = this;
            manCliente.Show();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            I_ManProduto manProduto = new I_ManProduto();
            manProduto.Show();

        }

        private void btnManClientes_Click(object sender, EventArgs e)
        {
            I_ManCliente2 manCliente = new I_ManCliente2();
            manCliente.MdiParent = this;
            manCliente.Show();
        }

        private void btnManProd_Click(object sender, EventArgs e)
        {
            I_ManProduto2 manProduto = new I_ManProduto2();
            manProduto.MdiParent = this;
            manProduto.Show();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            I_ManPedido manPedido = new I_ManPedido();
            manPedido.MdiParent = this;
            manPedido.Show();
        }

        private void manutençãoDePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            I_ManPedidos2 manPedidos = new I_ManPedidos2();
            manPedidos.MdiParent = this;
            manPedidos.Show();
        }

        #endregion

    }
}
