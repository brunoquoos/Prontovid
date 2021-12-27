using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class TipoExame
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public string NomeExame { get; set; }
        public string Observacoes { get; set; }
        public bool TipoLaboratorial { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_NOME_EXAME = "NomeExame";
        public const string COLUNA_OBSERVACOES = "Observacoes";
        public const string COLUNA_TIPO_LABORATORIAL = "TipoLaboratorial";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<TipoExame> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<TipoExame> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<TipoExame>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "NomeExame," + Texto.QuebraLinha;
                sql += "Observacoes," + Texto.QuebraLinha;
                sql += "TipoLaboratorial" + Texto.QuebraLinha;
                sql += " From TiposExames" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var tipoExame = ConverterDataReader(banco, dr);
                    lista.Add(tipoExame);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static TipoExame ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var tipoExame = new TipoExame();

                    tipoExame.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    tipoExame.NomeExame = dr["NomeExame"].ToString();
                    tipoExame.Observacoes = dr["Observacoes"].ToString();
                    tipoExame.TipoLaboratorial = banco.RecuperarBooelan(dr["TipoLaboratorial"].ToString());

			
			return tipoExame;
		}
		
		public static TipoExame ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, TipoExame tipoExame)
        {            
		return InserirSQL(banco, tipoExame,false);

        }
		
		private static bool InserirSQL(IBanco banco, TipoExame tipoExame,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, tipoExame))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(tipoExame.Codigo) + ",";

                }
                campos += "NomeExame, ";
                valores += banco.ObterTexto(tipoExame.NomeExame, 256) + ",";

                campos += "Observacoes, ";
                valores += banco.ObterTexto(tipoExame.Observacoes, 1024) + ",";

                campos += "TipoLaboratorial ";
                valores += banco.ObterVerdadeiroFalso(tipoExame.TipoLaboratorial);

                var sql = "Insert into TiposExames(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  TiposExames";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    tipoExame.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, TipoExame tipoExame)
        {            
			if (!TestarCampos(banco, tipoExame))
				return false;
					
			var sql = "Update TiposExames Set ";
			sql += "NomeExame = " + banco.ObterTexto(tipoExame.NomeExame, 256);
			sql += ", Observacoes = " + banco.ObterTexto(tipoExame.Observacoes, 1024);
			sql += ", TipoLaboratorial = " + banco.ObterVerdadeiroFalso(tipoExame.TipoLaboratorial);
			sql += " Where Codigo = " + banco.ObterDuplo(tipoExame.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, TipoExame tipoExame)
		{
			var sql = "Delete From TiposExames ";
			sql += " Where Codigo = " + banco.ObterDuplo(tipoExame.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, TipoExame tipoExame)
        {
            return AlterarSQL(banco, tipoExame) || InserirSQL(banco, tipoExame);
        }
		 
		#endregion
		 
    }
}
