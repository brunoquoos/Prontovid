using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class DadoClinicoPaciente
    {
        public static bool TestarCampos(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {
            return Inserir(banco, dadoClinicoPaciente, false);
        }

        public static bool Inserir(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, dadoClinicoPaciente, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {
            return AlterarSQL(banco, dadoClinicoPaciente);
        }

        public static bool Excluir(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {
            return ExcluirSQL(banco, dadoClinicoPaciente);
        }

        public static bool Gravar(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {
            return GravarSQL(banco, dadoClinicoPaciente);
        }

        public static double ObterProximoCodigo(IBanco banco)
        {
            return banco.ObterProcuraFuro("DadosClinicosPaciente", "Codigo");
        }

        public static DadoClinicoPaciente ConsultarPeloPaciente(IBanco banco, double codPaciente)
        {
            var lista = ConsultarSQL(banco, " Where CodPaciente = " + banco.ObterDuplo(codPaciente));

            if (lista.Count == 0)
                return null;

            return lista[0];
        }
    }
}
