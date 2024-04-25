using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTalentos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Curriculo curriculo         = new Curriculo();
            curriculo.nome              = tbxNome.Text;
            curriculo.telefone          = tbxTelefone.Text;
            curriculo.dataNascimento    = dtpDataNascimento.Text;
            curriculo.escolaridade      = cbxEscolaraidade.Text;
            curriculo.profissao1        = tbxProfissao1.Text;
            curriculo.profissao2        = tbxProfissao2.Text;
            curriculo.curso1            = tbxCurso1.Text;
            curriculo.curso2            = tbxCurso2.Text;

            Banco.inserirCurriculo(curriculo);

        }

        private void btnGerenciar_Click(object sender, EventArgs e)
        {
            GestaoCurriculos  gc = new GestaoCurriculos();
            gc.ShowDialog();
        }
    }
}
