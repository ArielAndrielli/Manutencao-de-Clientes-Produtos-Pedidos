using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExemploAcessoDB2.Login
{
    public partial class I_Login : Form
    {
        #region construtor

        public I_Login()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Log_in oLogin = new Log_in();

        #endregion

        #region Eventos

        private void btnLogin_Click(object sender, EventArgs e)
        {

            bool existeCadastro = oLogin.VerificarCadastro(txtUsuario.Text.Trim(), txtSenha.Text.Trim());

            if (existeCadastro)
            {
                MessageBox.Show("Acesso permitido! Bem vindo(a)!", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //As duas linhas abaixo mostram o form do menu principal
                I_MenuPrincipal menu = new I_MenuPrincipal();
                menu.ShowDialog();

                Close();
            }
            else
            {
                MessageBox.Show("Acesso negado! Tente inserir suas credenciais novamente!", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = string.Empty;
        }

        private void txtSenha_Click(object sender, EventArgs e)
        {
            txtSenha.Text = string.Empty;
        }

        private void lblCadastro_Click(object sender, EventArgs e)
        {
            I_Cadastro cad = new I_Cadastro();
            cad.ShowDialog();
        }

        private void lblCadastro_MouseHover(object sender, EventArgs e)
        {
            lblCadastro.ForeColor = Color.DarkBlue;
        }

        private void lblCadastro_MouseLeave(object sender, EventArgs e)
        {
            lblCadastro.ForeColor = Color.DodgerBlue;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                txtUsuario.Text = "Usuário";
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == string.Empty)
            {
                txtSenha.Text = "Senha";
            }

        }

        #endregion

    }
}
