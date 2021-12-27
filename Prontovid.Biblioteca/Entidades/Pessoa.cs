using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class Pessoa
    {
        public static bool TestarCampos(IBanco banco, Pessoa pessoa)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, Pessoa pessoa)
        {
            return Inserir(banco, pessoa, false);
        }

        public static bool Inserir(IBanco banco, Pessoa pessoa, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, pessoa, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, Pessoa pessoa)
        {
            return AlterarSQL(banco, pessoa);
        }

        public static bool Excluir(IBanco banco, Pessoa pessoa)
        {
            return ExcluirSQL(banco, pessoa);
        }

        public static bool Gravar(IBanco banco, Pessoa pessoa)
        {
            return GravarSQL(banco, pessoa);
        }

        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("Pessoa", "Codigo");
        }

        public static List<Pessoa> ConsultarTodas(IBanco banco, bool apenasAtivos)
        {
            return ConsultarSQL(banco, apenasAtivos ? " where Ativo = 1 " : "");
        }

        public static bool ExisteUser(IBanco banco, string user)
        {
            var users = ConsultarSQL(banco, " where Usuario = '" + user + "'");
            if (users != null)
                if (users.Count > 0)
                    return true;
            return false;
        }


        public static Pessoa ConsultarPorUser(IBanco banco, string usuario)
        {
            var lista = ConsultarSQL(banco, " Where Usuario = '" + usuario + "'");

            if (lista.Count == 0)
                return null;

            return lista[0];
        }
    }
}
