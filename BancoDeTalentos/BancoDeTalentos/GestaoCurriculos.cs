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
    public partial class GestaoCurriculos : Form
    {
        Curriculo c = new Curriculo();
        public GestaoCurriculos()
        {
            InitializeComponent();
        }

        private void GestaoCurriculos_Load(object sender, EventArgs e)
        {
            dgvCurriculos.DataSource = Banco.ObterTodosCurriculos();
            dgvCurriculos.Columns[0].Width = 50;
        }

        private void dgvCurriculos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            //traz o objeto que está associado no grid
            DataGridView dgv = (DataGridView)sender;
            int contLinhas = dgv.SelectedRows.Count;
            if (contLinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();

                c.id = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                tbxNome.Text = dgv.SelectedRows[0].Cells["nome"].Value.ToString();
                tbxTelefone.Text = dgv.SelectedRows[0].Cells["telefone"].Value.ToString();
                dtpDataNascimento.Text = dgv.SelectedRows[0].Cells["Dt Nascimento"].Value.ToString();
                cbxEscolaraidade.Text = dgv.SelectedRows[0].Cells["escolaridade"].Value.ToString();
                tbxProfissao1.Text = dgv.SelectedRows[0].Cells["Profissão 1"].Value.ToString();
                tbxProfissao2.Text = dgv.SelectedRows[0].Cells["Profissão 2"].Value.ToString();
                tbxCurso1.Text = dgv.SelectedRows[0].Cells["Curso 1"].Value.ToString();
                tbxCurso2.Text = dgv.SelectedRows[0].Cells["Curso 2"].Value.ToString();
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            c.nome = tbxNome.Text;
            c.telefone = tbxTelefone.Text;
            c.dataNascimento = dtpDataNascimento.Text;
            c.escolaridade = cbxEscolaraidade.Text;
            c.profissao1 = tbxProfissao1.Text;
            c.profissao2 = tbxProfissao2.Text;
            c.curso1 = tbxCurso1.Text;
            c.curso2 = tbxCurso2.Text;

            Banco.AlterarCurriculo(c);
            dgvCurriculos.DataSource = Banco.ObterTodosCurriculos();
        }

        private void dgvCurriculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCurriculos_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
