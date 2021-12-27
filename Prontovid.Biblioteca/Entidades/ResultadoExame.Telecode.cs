using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class ResultadoExame
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public double CodExame { get; set; }
        public DateTime DataResultado { get; set; }
        public string Observacoes { get; set; }
        public double ResponsavelResultado { get; set; }
        public string Resultado { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_COD_EXAME = "CodExame";
        public const string COLUNA_DATA_RESULTADO = "DataResultado";
        public const string COLUNA_OBSERVACOES = "Observacoes";
        public const string COLUNA_RESPONSAVEL_RESULTADO = "ResponsavelResultado";
        public const string COLUNA_RESULTADO = "Resultado";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<ResultadoExame> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<ResultadoExame> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<ResultadoExame>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "CodExame," + Texto.QuebraLinha;
                sql += "DataResultado," + Texto.QuebraLinha;
                sql += "Observacoes," + Texto.QuebraLinha;
                sql += "ResponsavelResultado," + Texto.QuebraLinha;
                sql += "Resultado" + Texto.QuebraLinha;
                sql += " From ResultadoExame" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var resultadoExame = ConverterDataReader(banco, dr);
                    lista.Add(resultadoExame);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static ResultadoExame ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var resultadoExame = new ResultadoExame();

                    resultadoExame.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    resultadoExame.CodExame = Convert.ToDouble(dr["CodExame"].ToString());
                    resultadoExame.DataResultado = Convert.ToDateTime(dr["DataResultado"].ToString());
                    resultadoExame.Observacoes = dr["Observacoes"].ToString();
                    resultadoExame.ResponsavelResultado = Convert.ToDouble(dr["ResponsavelResultado"].ToString());
                    resultadoExame.Resultado = dr["Resultado"].ToString();

			
			return resultadoExame;
		}
		
		public static ResultadoExame ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, ResultadoExame resultadoExame)
        {            
		return InserirSQL(banco, resultadoExame,false);

        }
		
		private static bool InserirSQL(IBanco banco, ResultadoExame resultadoExame,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, resultadoExame))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(resultadoExame.Codigo) + ",";

                }
                campos += "CodExame, ";
                valores += banco.ObterDuplo(resultadoExame.CodExame) + ",";

                campos += "DataResultado, ";
                valores += banco.ObterDataHora(resultadoExame.DataResultado) + ",";

                campos += "Observacoes, ";
                valores += banco.ObterTexto(resultadoExame.Observacoes, 1024) + ",";

                campos += "ResponsavelResultado, ";
                valores += banco.ObterDuplo(resultadoExame.ResponsavelResultado) + ",";

                campos += "Resultado ";
                valores += banco.ObterTexto(resultadoExame.Resultado, 1024);

                var sql = "Insert into ResultadoExame(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  ResultadoExame";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    resultadoExame.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, ResultadoExame resultadoExame)
        {            
			if (!TestarCampos(banco, resultadoExame))
				return false;
					
			var sql = "Update ResultadoExame Set ";
			sql += "CodExame = " + banco.ObterDuplo(resultadoExame.CodExame);
			sql += ", DataResultado = " + banco.ObterDataHora(resultadoExame.DataResultado);
			sql += ", Observacoes = " + banco.ObterTexto(resultadoExame.Observacoes, 1024);
			sql += ", ResponsavelResultado = " + banco.ObterDuplo(resultadoExame.ResponsavelResultado);
			sql += ", Resultado = " + banco.ObterTexto(resultadoExame.Resultado, 1024);
			sql += " Where Codigo = " + banco.ObterDuplo(resultadoExame.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, ResultadoExame resultadoExame)
		{
			var sql = "Delete From ResultadoExame ";
			sql += " Where Codigo = " + banco.ObterDuplo(resultadoExame.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, ResultadoExame resultadoExame)
        {
            return AlterarSQL(banco, resultadoExame) || InserirSQL(banco, resultadoExame);
        }
		 
		#endregion
		 
    }
}
