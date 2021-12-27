using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class ResponsavelPaciente
    {
		public static bool TestarCampos(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {            				
			return Inserir(banco, responsavelPaciente,false);
        }

		public static bool Inserir(IBanco banco, ResponsavelPaciente responsavelPaciente,bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, responsavelPaciente,atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {            
			return AlterarSQL(banco, responsavelPaciente);
        }
		
        public static bool Excluir(IBanco banco, ResponsavelPaciente responsavelPaciente)
		{
			return ExcluirSQL(banco, responsavelPaciente);
		}								
		
		public static bool Gravar(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {
            return GravarSQL(banco, responsavelPaciente);
        }
		
		        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("ResponsavelPaciente", "CodPaciente");
        }
    }
}
