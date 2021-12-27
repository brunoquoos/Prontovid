using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class ResultadoExame
    {
        public static bool TestarCampos(IBanco banco, ResultadoExame resultadoExame)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, ResultadoExame resultadoExame)
        {
            return Inserir(banco, resultadoExame, false);
        }

        public static bool Inserir(IBanco banco, ResultadoExame resultadoExame, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, resultadoExame, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, ResultadoExame resultadoExame)
        {
            return AlterarSQL(banco, resultadoExame);
        }

        public static bool Excluir(IBanco banco, ResultadoExame resultadoExame)
        {
            return ExcluirSQL(banco, resultadoExame);
        }

        public static bool Gravar(IBanco banco, ResultadoExame resultadoExame)
        {
            return GravarSQL(banco, resultadoExame);
        }

        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("ResultadoExame", "Codigo");
        }

        public static ResultadoExame ConsultarResultadoExame(IBanco banco, double codExame)
        {
            var lista = ConsultarSQL(banco, " Where CodExame = " + banco.ObterDuplo(codExame));

            if (lista.Count == 0)
                return null;

            return lista[0];
        }
    }
}
