using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class StatusPessoa
    {
        public enum eColor
        {
            Verde = 0,
            Amarelo = 1,
            Vermelho = 2
        }

        public static bool TestarCampos(IBanco banco, StatusPessoa statusPessoa)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, StatusPessoa statusPessoa)
        {
            return Inserir(banco, statusPessoa, false);
        }

        public static bool Inserir(IBanco banco, StatusPessoa statusPessoa, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, statusPessoa, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, StatusPessoa statusPessoa)
        {
            return AlterarSQL(banco, statusPessoa);
        }

        public static bool Excluir(IBanco banco, StatusPessoa statusPessoa)
        {
            return ExcluirSQL(banco, statusPessoa);
        }

        public static bool Gravar(IBanco banco, StatusPessoa statusPessoa)
        {
            return GravarSQL(banco, statusPessoa);
        }

        public static StatusPessoa UltimoStatus(IBanco banco, double codPaciente)
        {            
            var statusPessoa = ConsultarSQL(banco, " Where CodPaciente = " + codPaciente + " Order By " + COLUNA_DATA_STATUS + " DESC");
            if (statusPessoa.Count > 0)
                return statusPessoa[0];
            return null;
        }


    }
}
