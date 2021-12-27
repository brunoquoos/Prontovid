using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class SintomaPaciente
    {
        public static bool TestarCampos(IBanco banco, SintomaPaciente sintomaPaciente)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, SintomaPaciente sintomaPaciente)
        {
            return Inserir(banco, sintomaPaciente, false);
        }

        public static bool Inserir(IBanco banco, SintomaPaciente sintomaPaciente, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, sintomaPaciente, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, SintomaPaciente sintomaPaciente)
        {
            return AlterarSQL(banco, sintomaPaciente);
        }

        public static bool Excluir(IBanco banco, SintomaPaciente sintomaPaciente)
        {
            return ExcluirSQL(banco, sintomaPaciente);
        }

        public static bool Gravar(IBanco banco, SintomaPaciente sintomaPaciente)
        {
            return GravarSQL(banco, sintomaPaciente);
        }

        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("SintomasPaciente", "Codigo");
        }

        public static List<SintomaPaciente> ConsultarAtendimentos(IBanco banco, double codPaciente)
        {
            return ConsultarSQL(banco, " Where CodPaciente = " + banco.ObterDuplo(codPaciente) + " Order By DataInsercao Desc");            
        }
        
    }
}
