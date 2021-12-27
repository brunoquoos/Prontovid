using Telecon.Genericos.Classes.BancoDeDados;

namespace [Namespace]
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class [NomeClasse]
    {
		public static bool TestarCampos(IBanco banco, [NomeClasse] [NomeObjeto])
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, [NomeClasse] [NomeObjeto])
        {            				
			return Inserir(banco, [NomeObjeto],false);
        }

		public static bool Inserir(IBanco banco, [NomeClasse] [NomeObjeto],bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, [NomeObjeto],atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, [NomeClasse] [NomeObjeto])
        {            
			return AlterarSQL(banco, [NomeObjeto]);
        }
		
        public static bool Excluir(IBanco banco, [NomeClasse] [NomeObjeto])
		{
			return ExcluirSQL(banco, [NomeObjeto]);
		}								
		
		public static bool Gravar(IBanco banco, [NomeClasse] [NomeObjeto])
        {
            return GravarSQL(banco, [NomeObjeto]);
        }
		
		[ObterProximoCodigo]
    }
}
