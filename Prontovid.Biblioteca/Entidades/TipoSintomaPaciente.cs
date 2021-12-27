using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe não será sobreescrita pelo Telecode
    public partial class TipoSintomaPaciente
    {
		public static bool TestarCampos(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {            
            return true;
        }
		
		public static bool Inserir(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {            				
			return Inserir(banco, tipoSintomaPaciente,false);
        }

		public static bool Inserir(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente,bool atribuirColunaIdentidade)
        {            				
			return InserirSQL(banco, tipoSintomaPaciente,atribuirColunaIdentidade);
        }
		
		public static bool Alterar(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {            
			return AlterarSQL(banco, tipoSintomaPaciente);
        }
		
        public static bool Excluir(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
		{
			return ExcluirSQL(banco, tipoSintomaPaciente);
		}								
		
		public static bool Gravar(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {
            return GravarSQL(banco, tipoSintomaPaciente);
        }

        public static List<TipoSintomaPaciente> ConsultarTodos(IBanco banco)
        {
            return ConsultarSQL(banco, "");
        }

        public static TipoSintomaPaciente ConsultarPeloNome(IBanco banco, string nomeTipo)
        {
            var lista = ConsultarSQL(banco, " Where NomeTipo = '" + nomeTipo + "'");

            if (lista.Count == 0)
                return null;

            return lista[0];
        }

    }
}
