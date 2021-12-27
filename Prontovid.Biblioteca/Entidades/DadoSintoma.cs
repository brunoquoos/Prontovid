using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
    //Esta classe não será sobreescrita pelo Telecode
    public partial class DadoSintoma
    {
        public enum eEpisodicidade
        {
            Novo = 0,
            EmCurso = 1,
            Indeterminado = 2
        }

        public enum eCategoriaGravidade
        {
            Leve = 0,
            Moderada = 1,
            Grave = 2
        }

        public enum eTipoInicio
        {
            Gradual = 0,
            Subito = 1,
        }

        public enum eProgressao
        {
            Piorando = 0,
            Imutavel = 1,
            Melhorando = 2,
            Resolvido = 3
        }


        public static bool TestarCampos(IBanco banco, DadoSintoma dadoSintoma)
        {
            return true;
        }

        public static bool Inserir(IBanco banco, DadoSintoma dadoSintoma)
        {
            return Inserir(banco, dadoSintoma, false);
        }

        public static bool Inserir(IBanco banco, DadoSintoma dadoSintoma, bool atribuirColunaIdentidade)
        {
            return InserirSQL(banco, dadoSintoma, atribuirColunaIdentidade);
        }

        public static bool Alterar(IBanco banco, DadoSintoma dadoSintoma)
        {
            return AlterarSQL(banco, dadoSintoma);
        }

        public static bool Excluir(IBanco banco, DadoSintoma dadoSintoma)
        {
            return ExcluirSQL(banco, dadoSintoma);
        }

        public static bool Gravar(IBanco banco, DadoSintoma dadoSintoma)
        {
            return GravarSQL(banco, dadoSintoma);
        }

        public static List<DadoSintoma> ConsultarPeloSintomasPaciente(IBanco banco, double codSintomasPaciente)
        {
            return ConsultarSQL(banco, " Where CodSintomasPaciente = " + banco.ObterDuplo(codSintomasPaciente));
        }

        public static DadoSintoma ConsultarChave(IBanco banco, double codTipoSintoma, double codSintomasPaciente)
        {
            var lista = ConsultarSQL(banco, " Where CodigoTipoSintoma = " + banco.ObterDuplo(codTipoSintoma) + " And CodSintomasPaciente = " + banco.ObterDuplo(codSintomasPaciente));

            if (lista.Count == 0)
                return null;

            return lista[0];
        }

    }
}
