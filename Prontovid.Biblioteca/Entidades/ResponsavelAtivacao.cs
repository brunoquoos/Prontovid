using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class ResponsavelAtivacao
    {
		public static bool TestarCampos(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {            				
			return Inserir(banco, responsavelAtivacao,false);
        }

		public static bool Inserir(IBanco banco, ResponsavelAtivacao responsavelAtivacao,bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, responsavelAtivacao,atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {            
			return AlterarSQL(banco, responsavelAtivacao);
        }
		
        public static bool Excluir(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
		{
			return ExcluirSQL(banco, responsavelAtivacao);
		}								
		
		public static bool Gravar(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {
            return GravarSQL(banco, responsavelAtivacao);
        }
		
		        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("ResponsavelAtivacao", "CodPaciente");
        }
    }
}
