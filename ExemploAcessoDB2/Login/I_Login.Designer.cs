﻿
namespace ExemploAcessoDB2.Login
{
    partial class I_Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.lblTextin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(135, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // txtUsuario
            // 
            this.txtUsuario.ForeColor = System.Drawing.Color.Gray;
            this.txtUsuario.Location = new System.Drawing.Point(55, 135);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(273, 20);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.Text = "Valério";
            this.txtUsuario.Click += new System.EventHandler(this.txtUsuario_Click);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // txtSenha
            // 
            this.txtSenha.ForeColor = System.Drawing.Color.Gray;
            this.txtSenha.Location = new System.Drawing.Point(55, 200);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(273, 20);
            this.txtSenha.TabIndex = 4;
            this.txtSenha.Text = "farofa9";
            this.txtSenha.Click += new System.EventHandler(this.txtSenha_Click);
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(107, 315);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(156, 77);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastro.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCadastro.Location = new System.Drawing.Point(155, 247);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(51, 13);
            this.lblCadastro.TabIndex = 6;
            this.lblCadastro.Text = "Crie uma.";
            this.lblCadastro.Click += new System.EventHandler(this.lblCadastro_Click);
            this.lblCadastro.MouseLeave += new System.EventHandler(this.lblCadastro_MouseLeave);
            this.lblCadastro.MouseHover += new System.EventHandler(this.lblCadastro_MouseHover);
            // 
            // lblTextin
            // 
            this.lblTextin.AutoSize = true;
            this.lblTextin.Location = new System.Drawing.Point(52, 247);
            this.lblTextin.Name = "lblTextin";
            this.lblTextin.Size = new System.Drawing.Size(106, 13);
            this.lblTextin.TabIndex = 7;
            this.lblTextin.Text = "Não tem uma conta?";
            // 
            // I_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 471);
            this.Controls.Add(this.lblTextin);
            this.Controls.Add(this.lblCadastro);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "I_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.Label lblTextin;
    }
}