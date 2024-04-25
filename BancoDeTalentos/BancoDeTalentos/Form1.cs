using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeTalentos
{
    public partial class Form1 : Form
    {
        //Cria objeto dt da classe DataTable
        //Esse objeto servirá para armazenar as informações que virão do banco de dados.
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = tbxUsuario.Text;
            string senha = tbxSenha.Text;
           /* Usuario u1 = new Usuario();
            
            if(usuario == u1.getUsuario() && senha == u1.getSenha())
            {
                Gerenciar d1 = new Gerenciar(usuario);
                d1.ShowDialog();
                lblAcesso.Text = "Acessi liberado!! \nBom trabalho";
            }
            else
            {
                lblAcesso.Text = "Usuário ou senha incorreto!";
            }
            tbxUsuario.Text = "";
            tbxSenha.Text = "";*/
           if (usuario =="" || senha == "")
            {
                MessageBox.Show("Usuario e ou senha inválida");
                tbxUsuario.Focus();
                return;
            }
           //Comando Sql para selecionar todas as colunas da tabela usuario onde o usuario e a senha forem iguais as digitadas na tela de
           //login
            string sql = "SELECT * FROM T_usuarios WHERE usuario = '" + usuario + "' AND senha = '" + senha + "'";
            //IDA -  chama o método consulta passando a string sql como parâmetro, esse é um método static que
            //pertence a classe Banco.
            //VOLTA - retorna a tavlea de dados do banco de dados e salva no dt(DataTable)
            dt = Banco.consulta(sql);
            //conta quantas linhas tem na tabela de dados
            //e verufuca se tem uma li linha      
            if(dt.Rows.Count == 1)
            {
                //criar um objeto do tipo Dashboard (forma) e passao usuario como parâmetro
                //dt = tabela de dados
                //Rows[0] = primeira linha
                //ItenArray[1] segunda coluna da primeira linha
                Form2 d = new Form2();
                //item 1"usuario" da linha "0"
                //dt.Rows[0].Field<string>("usuario")
                d.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Usuario e ou senha inválida");
            }
            

        }

        private void tbxSenha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbxSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar.PerformClick();
        }
    }
}
