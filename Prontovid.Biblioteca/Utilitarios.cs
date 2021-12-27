using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca
{
    public static class Utilitarios
    {
        public static string Servidor { get; set; }

        public static bool MicroDebug
        {
            get { return Environment.MachineName.ToUpper().Equals("DSKDEV07"); }
        }

        public static IBanco ObterConexaoFechada()
        {
            string senha = "a2m8x7h5";
            if (MicroDebug)
                Servidor = "DSKDEV07\\MSSQLSERVER01";
            else
                Servidor = "(local)";

            if (MicroDebug)
                senha = "a2m8x7h5";


            var conexao = new SqlNativo(Servidor, "Prontovid", "sa", senha);

            return conexao;

        }

        public static IBanco ObterConexao()
        {
            var conexao = ObterConexaoFechada();

            conexao.AbrirConexao();

            return conexao;
        }


        public static string ObterSenha()
        {
            return "";
        }




    }
}
