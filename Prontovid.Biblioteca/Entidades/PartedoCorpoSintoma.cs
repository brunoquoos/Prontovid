using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class PartedoCorpoSintoma
    {
		public static bool TestarCampos(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {            				
			return Inserir(banco, partedoCorpoSintoma,false);
        }

		public static bool Inserir(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma,bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, partedoCorpoSintoma,atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {            
			return AlterarSQL(banco, partedoCorpoSintoma);
        }
		
        public static bool Excluir(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
		{
			return ExcluirSQL(banco, partedoCorpoSintoma);
		}								
		
		public static bool Gravar(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {
            return GravarSQL(banco, partedoCorpoSintoma);
        }

        public static List<PartedoCorpoSintoma> ConsultarPeloCodSintoma(IBanco banco, double codSintoma)
        {
            return ConsultarSQL(banco, " Where CodSintoma = " + banco.ObterDuplo(codSintoma));
        }

    }
}
