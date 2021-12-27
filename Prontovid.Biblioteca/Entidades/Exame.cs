using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class Exame
    {
        public static bool TestarCampos(IBanco banco, Exame exame)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, Exame exame)
        {
            return Inserir(banco, exame, false);
        }

        public static bool Inserir(IBanco banco, Exame exame, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, exame, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, Exame exame)
        {
            return AlterarSQL(banco, exame);
        }

        public static bool Excluir(IBanco banco, Exame exame)
        {
            return ExcluirSQL(banco, exame);
        }

        public static bool Gravar(IBanco banco, Exame exame)
        {
            return GravarSQL(banco, exame);
        }

        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("Exame", "Codigo");
        }


        public static List<Exame> ConsultarTodos(IBanco banco, double codPessoa)
        {
            return ConsultarSQL(banco, (codPessoa > 0 ? " where CodPaciente = " + codPessoa : "") + " ORDER BY DataExame DESC");
        }
    }
}
