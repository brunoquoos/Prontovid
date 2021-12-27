using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class Exame
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public double CodPaciente { get; set; }
        public DateTime DataExame { get; set; }
        public DateTime DataProvavelResultado { get; set; }
        public double TipoExame { get; set; }
        public string Observacoes { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_COD_PACIENTE = "CodPaciente";
        public const string COLUNA_DATA_EXAME = "DataExame";
        public const string COLUNA_DATA_PROVAVEL_RESULTADO = "DataProvavelResultado";
        public const string COLUNA_TIPO_EXAME = "TipoExame";
        public const string COLUNA_OBSERVACOES = "Observacoes";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<Exame> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<Exame> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<Exame>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "CodPaciente," + Texto.QuebraLinha;
                sql += "DataExame," + Texto.QuebraLinha;
                sql += "DataProvavelResultado," + Texto.QuebraLinha;
                sql += "TipoExame," + Texto.QuebraLinha;
                sql += "Observacoes" + Texto.QuebraLinha;
                sql += " From Exame" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var exame = ConverterDataReader(banco, dr);
                    lista.Add(exame);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static Exame ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var exame = new Exame();

                    exame.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    exame.CodPaciente = Convert.ToDouble(dr["CodPaciente"].ToString());
                    exame.DataExame = Convert.ToDateTime(dr["DataExame"].ToString());
                    exame.DataProvavelResultado = Convert.ToDateTime(dr["DataProvavelResultado"].ToString());
                    exame.TipoExame = Convert.ToDouble(dr["TipoExame"].ToString());
                    exame.Observacoes = banco.ConverterTextoNull(dr["Observacoes"].ToString());

			
			return exame;
		}
		
		public static Exame ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, Exame exame)
        {            
		return InserirSQL(banco, exame,false);

        }
		
		private static bool InserirSQL(IBanco banco, Exame exame,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, exame))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(exame.Codigo) + ",";

                }
                campos += "CodPaciente, ";
                valores += banco.ObterDuplo(exame.CodPaciente) + ",";

                campos += "DataExame, ";
                valores += banco.ObterDataHora(exame.DataExame) + ",";

                campos += "DataProvavelResultado, ";
                valores += banco.ObterDataHora(exame.DataProvavelResultado) + ",";

                campos += "TipoExame, ";
                valores += banco.ObterDuplo(exame.TipoExame) + ",";

                campos += "Observacoes ";
                valores += banco.ObterTexto(exame.Observacoes, 1024);

                var sql = "Insert into Exame(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  Exame";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    exame.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, Exame exame)
        {            
			if (!TestarCampos(banco, exame))
				return false;
					
			var sql = "Update Exame Set ";
			sql += "CodPaciente = " + banco.ObterDuplo(exame.CodPaciente);
			sql += ", DataExame = " + banco.ObterDataHora(exame.DataExame);
			sql += ", DataProvavelResultado = " + banco.ObterDataHora(exame.DataProvavelResultado);
			sql += ", TipoExame = " + banco.ObterDuplo(exame.TipoExame);
			sql += ", Observacoes = " + banco.ObterTexto(exame.Observacoes, 1024);
			sql += " Where Codigo = " + banco.ObterDuplo(exame.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, Exame exame)
		{
			var sql = "Delete From Exame ";
			sql += " Where Codigo = " + banco.ObterDuplo(exame.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, Exame exame)
        {
            return AlterarSQL(banco, exame) || InserirSQL(banco, exame);
        }
		 
		#endregion
		 
    }
}
