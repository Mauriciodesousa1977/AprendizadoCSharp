using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeTalentos
{
    public class Usuario
    {
        private string usuario = "Aluno";
        private string senha = "123";

        public string getUsuario() { return usuario; }
        public string getSenha() { return senha; }

        public void setUsusario(string usuario) { this.usuario = usuario; }
        public void setSenha(string senha) { this.senha = senha; }
    }

}