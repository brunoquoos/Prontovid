using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class Configuracao
    {
		public static bool TestarCampos(IBanco banco, Configuracao configuracao)
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, Configuracao configuracao)
        {            				
			return Inserir(banco, configuracao,false);
        }

		public static bool Inserir(IBanco banco, Configuracao configuracao,bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, configuracao,atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, Configuracao configuracao)
        {            
			return AlterarSQL(banco, configuracao);
        }
		
        public static bool Excluir(IBanco banco, Configuracao configuracao)
		{
			return ExcluirSQL(banco, configuracao);
		}								
		
		public static bool Gravar(IBanco banco, Configuracao configuracao)
        {
            return GravarSQL(banco, configuracao);
        }
		
		
    }
}
