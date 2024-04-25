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
    public partial class Gerenciar : Form
    {
        public Gerenciar(string usuario)
        {
            InitializeComponent();
            lblMensagem.Text = "Seja bem vindo!! "+usuario;
        }

        private void Gerenciar_Load(object sender, EventArgs e)
        {

        }
              

        private void curriculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarCurriculo c = new CadastrarCurriculo();
            c.ShowDialog();
        }
    }
}
