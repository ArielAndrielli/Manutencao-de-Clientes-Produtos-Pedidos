
namespace ExemploAcessoDB2
{
    partial class I_MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manutençõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManProd = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoDePedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manutençõesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manutençõesToolStripMenuItem
            // 
            this.manutençõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCliente,
            this.pedidoToolStripMenuItem,
            this.btnProduto,
            this.btnManClientes,
            this.btnManProd,
            this.manutençãoDePedidoToolStripMenuItem});
            this.manutençõesToolStripMenuItem.Name = "manutençõesToolStripMenuItem";
            this.manutençõesToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.manutençõesToolStripMenuItem.Text = "Manutenções";
            // 
            // btnCliente
            // 
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(208, 22);
            this.btnCliente.Text = "Cliente";
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // pedidoToolStripMenuItem
            // 
            this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
            this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.pedidoToolStripMenuItem.Text = "Pedido";
            this.pedidoToolStripMenuItem.Click += new System.EventHandler(this.pedidoToolStripMenuItem_Click);
            // 
            // btnProduto
            // 
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(208, 22);
            this.btnProduto.Text = "Produto";
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnManClientes
            // 
            this.btnManClientes.Name = "btnManClientes";
            this.btnManClientes.Size = new System.Drawing.Size(208, 22);
            this.btnManClientes.Text = "Manutenção de clientes";
            this.btnManClientes.Click += new System.EventHandler(this.btnManClientes_Click);
            // 
            // btnManProd
            // 
            this.btnManProd.Name = "btnManProd";
            this.btnManProd.Size = new System.Drawing.Size(208, 22);
            this.btnManProd.Text = "Manutenção de Produtos";
            this.btnManProd.Click += new System.EventHandler(this.btnManProd_Click);
            // 
            // manutençãoDePedidoToolStripMenuItem
            // 
            this.manutençãoDePedidoToolStripMenuItem.Name = "manutençãoDePedidoToolStripMenuItem";
            this.manutençãoDePedidoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.manutençãoDePedidoToolStripMenuItem.Text = "Manutenção de Pedidos";
            this.manutençãoDePedidoToolStripMenuItem.Click += new System.EventHandler(this.manutençãoDePedidoToolStripMenuItem_Click);
            // 
            // I_MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "I_MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "I_MenuPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manutençõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnCliente;
        private System.Windows.Forms.ToolStripMenuItem btnProduto;
        private System.Windows.Forms.ToolStripMenuItem btnManClientes;
        private System.Windows.Forms.ToolStripMenuItem btnManProd;
        private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manutençãoDePedidoToolStripMenuItem;
    }
}