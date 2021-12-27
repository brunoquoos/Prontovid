using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class PermissaoPessoa
    {
        public enum ePermissao
        {
            Paciente = 1,
            Medico = 2,
            Administrador = 3
        }

        public static bool TestarCampos(IBanco banco, PermissaoPessoa permissaoPessoa)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, PermissaoPessoa permissaoPessoa)
        {
            return Inserir(banco, permissaoPessoa, false);
        }

        public static bool Inserir(IBanco banco, PermissaoPessoa permissaoPessoa, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, permissaoPessoa, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, PermissaoPessoa permissaoPessoa)
        {
            return AlterarSQL(banco, permissaoPessoa);
        }

        public static bool Excluir(IBanco banco, PermissaoPessoa permissaoPessoa)
        {
            return ExcluirSQL(banco, permissaoPessoa);
        }

        public static bool Gravar(IBanco banco, PermissaoPessoa permissaoPessoa)
        {
            return GravarSQL(banco, permissaoPessoa);
        }

        public static double MaiorPermissao(IBanco banco, double codPessoa)
        {
            var lista = ConsultarSQL(banco, " Where CodPessoa = " + banco.ObterDuplo(codPessoa) + " Order By CodPermissao Desc ");

            if (lista.Count > 0)
                return lista[0].CodPermissao;

            return 0;
        }
        
        public static bool ExcluirPermissoes(IBanco banco, double codPessoa)
        {
            var lista = ConsultarSQL(banco, " Where CodPessoa = " + banco.ObterDuplo(codPessoa) + " Order By CodPermissao Desc ");

            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    PermissaoPessoa.Excluir(banco, item);
                }
            }
            return true;
        }

        public static PermissaoPessoa MaiorPermissaoObj(IBanco banco, double codPessoa)
        {
            var lista = ConsultarSQL(banco, " Where CodPessoa = " + banco.ObterDuplo(codPessoa) + " Order By CodPermissao Desc");

            if (lista.Count == 0)
                return null;

            return lista[0];
        }


    }
}
