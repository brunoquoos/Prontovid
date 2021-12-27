using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class NivelPermissao
    {
		public static bool TestarCampos(IBanco banco, NivelPermissao nivelPermissao)
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, NivelPermissao nivelPermissao)
        {            				
			return Inserir(banco, nivelPermissao,false);
        }

		public static bool Inserir(IBanco banco, NivelPermissao nivelPermissao,bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, nivelPermissao,atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, NivelPermissao nivelPermissao)
        {            
			return AlterarSQL(banco, nivelPermissao);
        }
		
        public static bool Excluir(IBanco banco, NivelPermissao nivelPermissao)
		{
			return ExcluirSQL(banco, nivelPermissao);
		}								
		
		public static bool Gravar(IBanco banco, NivelPermissao nivelPermissao)
        {
            return GravarSQL(banco, nivelPermissao);
        }

        public static List<NivelPermissao> ConsultarTodos(IBanco banco)
        {
            return ConsultarSQL(banco, "Order By " + COLUNA_DESCRICAO_NIVEL);
        }


    }
}
