using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class DadoSintoma
    {
		#region Propriedades
		
        public double CodSintoma { get; set; }
        public int CategoriaGravidade { get; set; }
        public int ClassificacaoGravidade { get; set; }
        public double CodigoTipoSintoma { get; set; }
        public double CodSintomasPaciente { get; set; }
        public string DescricaoEpisodio { get; set; }
        public string DescricaoEpisodiosPrevios { get; set; }
        public string DescricaoSintoma { get; set; }
        public string Duracao { get; set; }
        public int Episodicidade { get; set; }
        public string Impacto { get; set; }
        public DateTime InicioEpisodio { get; set; }
        public bool NaoSignificante { get; set; }
        public string NomeSintoma { get; set; }
        public string Padrao { get; set; }
        public bool PrimeiraVez { get; set; }
        public int Progressao { get; set; }
        public int TipoDeInicio { get; set; }
        public DateTime? FimEpisodio { get; set; }

        public const string COLUNA_COD_SINTOMA = "CodSintoma";
        public const string COLUNA_CATEGORIA_GRAVIDADE = "CategoriaGravidade";
        public const string COLUNA_CLASSIFICACAO_GRAVIDADE = "ClassificacaoGravidade";
        public const string COLUNA_CODIGO_TIPO_SINTOMA = "CodigoTipoSintoma";
        public const string COLUNA_COD_SINTOMAS_PACIENTE = "CodSintomasPaciente";
        public const string COLUNA_DESCRICAO_EPISODIO = "DescricaoEpisodio";
        public const string COLUNA_DESCRICAO_EPISODIOS_PREVIOS = "DescricaoEpisodiosPrevios";
        public const string COLUNA_DESCRICAO_SINTOMA = "DescricaoSintoma";
        public const string COLUNA_DURACAO = "Duracao";
        public const string COLUNA_EPISODICIDADE = "Episodicidade";
        public const string COLUNA_IMPACTO = "Impacto";
        public const string COLUNA_INICIO_EPISODIO = "InicioEpisodio";
        public const string COLUNA_NAO_SIGNIFICANTE = "NaoSignificante";
        public const string COLUNA_NOME_SINTOMA = "NomeSintoma";
        public const string COLUNA_PADRAO = "Padrao";
        public const string COLUNA_PRIMEIRA_VEZ = "PrimeiraVez";
        public const string COLUNA_PROGRESSAO = "Progressao";
        public const string COLUNA_TIPO_DE_INICIO = "TipoDeInicio";
        public const string COLUNA_FIM_EPISODIO = "FimEpisodio";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<DadoSintoma> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<DadoSintoma> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<DadoSintoma>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodSintoma," + Texto.QuebraLinha;
                sql += "CategoriaGravidade," + Texto.QuebraLinha;
                sql += "ClassificacaoGravidade," + Texto.QuebraLinha;
                sql += "CodigoTipoSintoma," + Texto.QuebraLinha;
                sql += "CodSintomasPaciente," + Texto.QuebraLinha;
                sql += "DescricaoEpisodio," + Texto.QuebraLinha;
                sql += "DescricaoEpisodiosPrevios," + Texto.QuebraLinha;
                sql += "DescricaoSintoma," + Texto.QuebraLinha;
                sql += "Duracao," + Texto.QuebraLinha;
                sql += "Episodicidade," + Texto.QuebraLinha;
                sql += "Impacto," + Texto.QuebraLinha;
                sql += "InicioEpisodio," + Texto.QuebraLinha;
                sql += "NaoSignificante," + Texto.QuebraLinha;
                sql += "NomeSintoma," + Texto.QuebraLinha;
                sql += "Padrao," + Texto.QuebraLinha;
                sql += "PrimeiraVez," + Texto.QuebraLinha;
                sql += "Progressao," + Texto.QuebraLinha;
                sql += "TipoDeInicio," + Texto.QuebraLinha;
                sql += "FimEpisodio" + Texto.QuebraLinha;
                sql += " From DadosSintoma" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var dadoSintoma = ConverterDataReader(banco, dr);
                    lista.Add(dadoSintoma);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static DadoSintoma ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var dadoSintoma = new DadoSintoma();

                    dadoSintoma.CodSintoma = Convert.ToDouble(dr["CodSintoma"].ToString());
                    dadoSintoma.CategoriaGravidade = Convert.ToInt32(dr["CategoriaGravidade"].ToString());
                    dadoSintoma.ClassificacaoGravidade = Convert.ToInt32(dr["ClassificacaoGravidade"].ToString());
                    dadoSintoma.CodigoTipoSintoma = Convert.ToDouble(dr["CodigoTipoSintoma"].ToString());
                    dadoSintoma.CodSintomasPaciente = Convert.ToDouble(dr["CodSintomasPaciente"].ToString());
                    dadoSintoma.DescricaoEpisodio = dr["DescricaoEpisodio"].ToString();
                    dadoSintoma.DescricaoEpisodiosPrevios = dr["DescricaoEpisodiosPrevios"].ToString();
                    dadoSintoma.DescricaoSintoma = dr["DescricaoSintoma"].ToString();
                    dadoSintoma.Duracao = dr["Duracao"].ToString();
                    dadoSintoma.Episodicidade = Convert.ToInt32(dr["Episodicidade"].ToString());
                    dadoSintoma.Impacto = dr["Impacto"].ToString();
                    dadoSintoma.InicioEpisodio = Convert.ToDateTime(dr["InicioEpisodio"].ToString());
                    dadoSintoma.NaoSignificante = banco.RecuperarBooelan(dr["NaoSignificante"].ToString());
                    dadoSintoma.NomeSintoma = dr["NomeSintoma"].ToString();
                    dadoSintoma.Padrao = dr["Padrao"].ToString();
                    dadoSintoma.PrimeiraVez = banco.RecuperarBooelan(dr["PrimeiraVez"].ToString());
                    dadoSintoma.Progressao = Convert.ToInt32(dr["Progressao"].ToString());
                    dadoSintoma.TipoDeInicio = Convert.ToInt32(dr["TipoDeInicio"].ToString());
                    dadoSintoma.FimEpisodio = banco.ConverterDataNull(dr["FimEpisodio"].ToString());

			
			return dadoSintoma;
		}
		
		public static DadoSintoma ConsultarChave(IBanco banco, double codSintoma)
        {            
			var lista = ConsultarSQL(banco, " Where CodSintoma = " + banco.ObterDuplo(codSintoma));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, DadoSintoma dadoSintoma)
        {            
		return InserirSQL(banco, dadoSintoma,false);

        }
		
		private static bool InserirSQL(IBanco banco, DadoSintoma dadoSintoma,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, dadoSintoma))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "CodSintoma, ";
                   valores += banco.ObterDuplo(dadoSintoma.CodSintoma) + ",";

                }
                campos += "CategoriaGravidade, ";
                valores += banco.ObterInteiro(dadoSintoma.CategoriaGravidade) + ",";

                campos += "ClassificacaoGravidade, ";
                valores += banco.ObterInteiro(dadoSintoma.ClassificacaoGravidade) + ",";

                campos += "CodigoTipoSintoma, ";
                valores += banco.ObterDuplo(dadoSintoma.CodigoTipoSintoma) + ",";

                campos += "CodSintomasPaciente, ";
                valores += banco.ObterDuplo(dadoSintoma.CodSintomasPaciente) + ",";

                campos += "DescricaoEpisodio, ";
                valores += banco.ObterTexto(dadoSintoma.DescricaoEpisodio, 2048) + ",";

                campos += "DescricaoEpisodiosPrevios, ";
                valores += banco.ObterTexto(dadoSintoma.DescricaoEpisodiosPrevios, 2048) + ",";

                campos += "DescricaoSintoma, ";
                valores += banco.ObterTexto(dadoSintoma.DescricaoSintoma, 2048) + ",";

                campos += "Duracao, ";
                valores += banco.ObterTexto(dadoSintoma.Duracao, 32) + ",";

                campos += "Episodicidade, ";
                valores += banco.ObterInteiro(dadoSintoma.Episodicidade) + ",";

                campos += "Impacto, ";
                valores += banco.ObterTexto(dadoSintoma.Impacto, 2048) + ",";

                campos += "InicioEpisodio, ";
                valores += banco.ObterDataHora(dadoSintoma.InicioEpisodio) + ",";

                campos += "NaoSignificante, ";
                valores += banco.ObterVerdadeiroFalso(dadoSintoma.NaoSignificante) + ",";

                campos += "NomeSintoma, ";
                valores += banco.ObterTexto(dadoSintoma.NomeSintoma, 64) + ",";

                campos += "Padrao, ";
                valores += banco.ObterTexto(dadoSintoma.Padrao, 2048) + ",";

                campos += "PrimeiraVez, ";
                valores += banco.ObterVerdadeiroFalso(dadoSintoma.PrimeiraVez) + ",";

                campos += "Progressao, ";
                valores += banco.ObterInteiro(dadoSintoma.Progressao) + ",";

                campos += "TipoDeInicio, ";
                valores += banco.ObterInteiro(dadoSintoma.TipoDeInicio) + ",";

                campos += "FimEpisodio ";
                valores += banco.ObterDataHora(dadoSintoma.FimEpisodio);

                var sql = "Insert into DadosSintoma(" + campos + ") Values(" + valores + ")  SELECT MAX( CodSintoma ) as CodSintoma from  DadosSintoma";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    dadoSintoma.CodSintoma = Convert.ToDouble(dr["CodSintoma"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, DadoSintoma dadoSintoma)
        {            
			if (!TestarCampos(banco, dadoSintoma))
				return false;
					
			var sql = "Update DadosSintoma Set ";
			sql += "CategoriaGravidade = " + banco.ObterInteiro(dadoSintoma.CategoriaGravidade);
			sql += ", ClassificacaoGravidade = " + banco.ObterInteiro(dadoSintoma.ClassificacaoGravidade);
			sql += ", CodigoTipoSintoma = " + banco.ObterDuplo(dadoSintoma.CodigoTipoSintoma);
			sql += ", CodSintomasPaciente = " + banco.ObterDuplo(dadoSintoma.CodSintomasPaciente);
			sql += ", DescricaoEpisodio = " + banco.ObterTexto(dadoSintoma.DescricaoEpisodio, 2048);
			sql += ", DescricaoEpisodiosPrevios = " + banco.ObterTexto(dadoSintoma.DescricaoEpisodiosPrevios, 2048);
			sql += ", DescricaoSintoma = " + banco.ObterTexto(dadoSintoma.DescricaoSintoma, 2048);
			sql += ", Duracao = " + banco.ObterTexto(dadoSintoma.Duracao, 32);
			sql += ", Episodicidade = " + banco.ObterInteiro(dadoSintoma.Episodicidade);
			sql += ", Impacto = " + banco.ObterTexto(dadoSintoma.Impacto, 2048);
			sql += ", InicioEpisodio = " + banco.ObterDataHora(dadoSintoma.InicioEpisodio);
			sql += ", NaoSignificante = " + banco.ObterVerdadeiroFalso(dadoSintoma.NaoSignificante);
			sql += ", NomeSintoma = " + banco.ObterTexto(dadoSintoma.NomeSintoma, 64);
			sql += ", Padrao = " + banco.ObterTexto(dadoSintoma.Padrao, 2048);
			sql += ", PrimeiraVez = " + banco.ObterVerdadeiroFalso(dadoSintoma.PrimeiraVez);
			sql += ", Progressao = " + banco.ObterInteiro(dadoSintoma.Progressao);
			sql += ", TipoDeInicio = " + banco.ObterInteiro(dadoSintoma.TipoDeInicio);
			sql += ", FimEpisodio = " + banco.ObterDataHora(dadoSintoma.FimEpisodio);
			sql += " Where CodSintoma = " + banco.ObterDuplo(dadoSintoma.CodSintoma);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, DadoSintoma dadoSintoma)
		{
			var sql = "Delete From DadosSintoma ";
			sql += " Where CodSintoma = " + banco.ObterDuplo(dadoSintoma.CodSintoma);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, DadoSintoma dadoSintoma)
        {
            return AlterarSQL(banco, dadoSintoma) || InserirSQL(banco, dadoSintoma);
        }
		 
		#endregion
		 
    }
}
