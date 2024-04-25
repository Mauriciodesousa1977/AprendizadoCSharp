using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.ComponentModel;


namespace BancoDeTalentos
{
    internal class Banco
    {
        //atributo
        private static SQLiteConnection conexao;

        //médoto conexaoBAnco  RETORNA UMA CONEXAO DA CLASSE SQLITECONECTION
        private static SQLiteConnection ConexaoBanco()
        {
            //criar uma conexao do tipo sqliteconnect
            //linkado ao arquivo banco.db
            conexao = new SQLiteConnection("Data Source = ..\\..\\..\\Banco\\Banco0.db");
            //abrindo a conexao UTILIZANDO O MÉTODO OPEN()
            //CONEXAO É UM OBJETO DA CLASSE SQLITECONNECTION E OPEN É UM MÉTODO DO OBJETO
            conexao.Open();
            //retorna para o arquivo que chamou a conexao
            return conexao;
        }
        //médoto consulta que recebe uma string com o comando sql e retorna uma tablea de dados(DataTable)
        public static DataTable consulta(string sql)
        {
            //Adaptador de dados iniciado com null
            SQLiteDataAdapter da = null;
            //objeto da classe dataTable  (tabela de dados)
            DataTable dt = new DataTable();
            // tenta realizar os comandos dentro do try
            try
            {
                //Cria um escopo que ao final de sua execução libera recursos automaticamente através do médoto Dispose()
                //Cria um objeto do tipo comando
                //CONEXAOBANCO().CREATECOMMAND() = CONEXAO.CREATCOMMAND()
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    //preencher o comando com a string sql;
                    cmd.CommandText = sql;
                    //Criar um SQLiteDataAdapter usando o comando e a conexao e salva em da
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    //Converte de DataAdapter para DAtaTable e preenche o dt
                    da.Fill(dt);
                    //fehca a conexao
                    ConexaoBanco().Close();
                    //retorna o DataTable e dt
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ConexaoBanco().Close();
                //caso ocorra algum erro no try exibe a exceção
                throw ex;
            }

        }
        public static void inserirCurriculo(Curriculo c)
        {
            if (existeNome(c))
            {
                MessageBox.Show("Nome já cadastrado!!", "Banco de Talentos - Cadastro de curriculos");
                return;
            }
            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    //preence o comando com a string sql
                    cmd.CommandText = "INSERT INTO t_curriculos (nome, telefone, dataNascimento, escolaridade, profissao1, profissao2, curso1, curso2)" +
                        " VALUES (@nome, @telefone, @dataNascimento, @escolaridade, @profissao1, @profissao2, @curso1, @curso2)";
                    cmd.Parameters.AddWithValue("@nome", c.nome);
                    cmd.Parameters.AddWithValue("@telefone", c.telefone);
                    cmd.Parameters.AddWithValue("@dataNascimento", c.dataNascimento);
                    cmd.Parameters.AddWithValue("@escolaridade", c.escolaridade);
                    cmd.Parameters.AddWithValue("@profissao1", c.profissao1);
                    cmd.Parameters.AddWithValue("@profissao2", c.profissao2);
                    cmd.Parameters.AddWithValue("@curso1", c.curso1);
                    cmd.Parameters.AddWithValue("@curso2", c.curso2);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Parabéns!! Novo curriculo Armazenado.", "Banco de Talentos - Cadastro de curriculos");
                    ConexaoBanco().Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ops!! Erro ao salvar currículo.", "Banco de Talentos - Cadastro de curriculos");
                ConexaoBanco().Close();
                throw ex;
            }
        }
        private static bool existeNome(Curriculo c)
        {
            DataTable dt = null;
            bool res = false;
            string sql = "SELECT nome FROM t_curriculos WHERE nome = '" + c.nome + "'";
            dt = Banco.consulta(sql);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            return res;
        }
        public static DataTable ObterTodosCurriculos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    cmd.CommandText = "SELECT id, nome, telefone, dataNascimento as 'Dt Nascimento', escolaridade, profissao1 as 'Profissão 1', profissao2 as 'Profissão 2', curso1 as 'Curso 1', curso2 as 'Curso 2' FROM t_curriculos";
                    da = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                    da.Fill(dt);
                    ConexaoBanco().Close();
                    return dt;
                }
            }catch (Exception ex)
            {
                ConexaoBanco().Close();
                throw ex;
            }
        }
        public static void AlterarCurriculo(Curriculo c)
        {
            try
            {
                using (var cmd = ConexaoBanco().CreateCommand())
                {
                    //preencer o comando com a string sql para alteração
                    cmd.CommandText = "UPDATE t_curriculos SET nome = @nome, telefone = @telefone, dataNascimento = @dataNascimento, escolaridade = @escolaridade, profissao1 = @profissao1, profissao2 = @profissao2, curso1 = @curso1, curso2 = @curso2 WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", c.id);
                    cmd.Parameters.AddWithValue("@nome", c.nome);
                    cmd.Parameters.AddWithValue("@telefone", c.telefone);
                    cmd.Parameters.AddWithValue("@dataNascimento", c.dataNascimento);
                    cmd.Parameters.AddWithValue("@escolaridade", c.escolaridade);
                    cmd.Parameters.AddWithValue("@profissao1", c.profissao1);
                    cmd.Parameters.AddWithValue("@profissao2", c.profissao2);
                    cmd.Parameters.AddWithValue("@curso1", c.curso1);
                    cmd.Parameters.AddWithValue("@curso2", c.curso2);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Curriculo Atualizado");
                    ConexaoBanco().Clone();
                }
            }catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
