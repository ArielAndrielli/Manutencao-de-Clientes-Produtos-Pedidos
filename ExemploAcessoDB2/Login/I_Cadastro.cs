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
    public partial class I_Cadastro : Form
    {

        #region Construtor

        public I_Cadastro()
        {
            InitializeComponent();
        }

        #endregion

        #region Atributos

        private Log_in oCadastro = new Log_in();

        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region Verificações

            if (txtUsuario.Text.Trim() == string.Empty
                && txtSenha.Text.Trim() == string.Empty
                && txtConfSenha.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Campos obrigatórios", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (txtConfSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("As senhas não batem! Verifique e tente novamente.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            #endregion

            #region Operação

            oCadastro.Nome = txtUsuario.Text.Trim();
            oCadastro.Senha = txtSenha.Text.Trim();
            oCadastro.Cadastrar();

            if (oCadastro.HasError)
            {
                MessageBox.Show(oCadastro.MsgError, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("Usuário cadastrado com sucesso!",
                "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            I_Login log = new I_Login();
            log.ShowDialog();

            #endregion
        }
    }
}
