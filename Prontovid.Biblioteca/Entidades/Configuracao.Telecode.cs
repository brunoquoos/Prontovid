using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class Configuracao
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public string Descricao { get; set; }
        public string VALOR { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_DESCRICAO = "Descricao";
        public const string COLUNA_V_A_L_O_R = "VALOR";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<Configuracao> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<Configuracao> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<Configuracao>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "Descricao," + Texto.QuebraLinha;
                sql += "VALOR" + Texto.QuebraLinha;
                sql += " From Configuracoes" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var configuracao = ConverterDataReader(banco, dr);
                    lista.Add(configuracao);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static Configuracao ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var configuracao = new Configuracao();

                    configuracao.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    configuracao.Descricao = dr["Descricao"].ToString();
                    configuracao.VALOR = dr["VALOR"].ToString();

			
			return configuracao;
		}
		
		public static Configuracao ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, Configuracao configuracao)
        {            
		return InserirSQL(banco, configuracao,false);

        }
		
		private static bool InserirSQL(IBanco banco, Configuracao configuracao,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, configuracao))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(configuracao.Codigo) + ",";

                }
                campos += "Descricao, ";
                valores += banco.ObterTexto(configuracao.Descricao, 50) + ",";

                campos += "VALOR ";
                valores += banco.ObterTexto(configuracao.VALOR, 10);

                var sql = "Insert into Configuracoes(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  Configuracoes";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    configuracao.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, Configuracao configuracao)
        {            
			if (!TestarCampos(banco, configuracao))
				return false;
					
			var sql = "Update Configuracoes Set ";
			sql += "Descricao = " + banco.ObterTexto(configuracao.Descricao, 50);
			sql += ", VALOR = " + banco.ObterTexto(configuracao.VALOR, 10);
			sql += " Where Codigo = " + banco.ObterDuplo(configuracao.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, Configuracao configuracao)
		{
			var sql = "Delete From Configuracoes ";
			sql += " Where Codigo = " + banco.ObterDuplo(configuracao.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, Configuracao configuracao)
        {
            return AlterarSQL(banco, configuracao) || InserirSQL(banco, configuracao);
        }
		 
		#endregion
		 
    }
}
