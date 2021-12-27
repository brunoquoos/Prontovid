using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class TipoExame
    {
        public static bool TestarCampos(IBanco banco, TipoExame tipoExame)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, TipoExame tipoExame)
        {
            return Inserir(banco, tipoExame, false);
        }

        public static bool Inserir(IBanco banco, TipoExame tipoExame, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, tipoExame, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, TipoExame tipoExame)
        {
            return AlterarSQL(banco, tipoExame);
        }

        public static bool Excluir(IBanco banco, TipoExame tipoExame)
        {
            return ExcluirSQL(banco, tipoExame);
        }

        public static bool Gravar(IBanco banco, TipoExame tipoExame)
        {
            return GravarSQL(banco, tipoExame);
        }

        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("TiposExames", "Codigo");
        }

        public static List<TipoExame> ConsultarTodos(IBanco banco, bool apenasLaboratorial)
        {
            return ConsultarSQL(banco, apenasLaboratorial ? " where TipoLaboratorial = 1 Order By NomeExame " : " Order By NomeExame ");
        }
    }
}
