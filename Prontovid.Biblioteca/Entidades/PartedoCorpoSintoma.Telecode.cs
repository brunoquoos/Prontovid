using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class PartedoCorpoSintoma
    {
		#region Propriedades
		
        public double CodPartedoCorpoSintoma { get; set; }
        public double CodSintoma { get; set; }
        public string Descricao { get; set; }

        public const string COLUNA_COD_PARTEDO_CORPO_SINTOMA = "CodPartedoCorpoSintoma";
        public const string COLUNA_COD_SINTOMA = "CodSintoma";
        public const string COLUNA_DESCRICAO = "Descricao";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<PartedoCorpoSintoma> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<PartedoCorpoSintoma> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<PartedoCorpoSintoma>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodPartedoCorpoSintoma," + Texto.QuebraLinha;
                sql += "CodSintoma," + Texto.QuebraLinha;
                sql += "Descricao" + Texto.QuebraLinha;
                sql += " From PartedoCorpoSintoma" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var partedoCorpoSintoma = ConverterDataReader(banco, dr);
                    lista.Add(partedoCorpoSintoma);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static PartedoCorpoSintoma ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var partedoCorpoSintoma = new PartedoCorpoSintoma();

                    partedoCorpoSintoma.CodPartedoCorpoSintoma = Convert.ToDouble(dr["CodPartedoCorpoSintoma"].ToString());
                    partedoCorpoSintoma.CodSintoma = Convert.ToDouble(dr["CodSintoma"].ToString());
                    partedoCorpoSintoma.Descricao = dr["Descricao"].ToString();

			
			return partedoCorpoSintoma;
		}
		
		public static PartedoCorpoSintoma ConsultarChave(IBanco banco, double codPartedoCorpoSintoma)
        {            
			var lista = ConsultarSQL(banco, " Where CodPartedoCorpoSintoma = " + banco.ObterDuplo(codPartedoCorpoSintoma));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {            
		return InserirSQL(banco, partedoCorpoSintoma,false);

        }
		
		private static bool InserirSQL(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, partedoCorpoSintoma))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "CodPartedoCorpoSintoma, ";
                   valores += banco.ObterDuplo(partedoCorpoSintoma.CodPartedoCorpoSintoma) + ",";

                }
                campos += "CodSintoma, ";
                valores += banco.ObterDuplo(partedoCorpoSintoma.CodSintoma) + ",";

                campos += "Descricao ";
                valores += banco.ObterTexto(partedoCorpoSintoma.Descricao, 256);

                var sql = "Insert into PartedoCorpoSintoma(" + campos + ") Values(" + valores + ")  SELECT MAX( CodPartedoCorpoSintoma ) as CodPartedoCorpoSintoma from  PartedoCorpoSintoma";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    partedoCorpoSintoma.CodPartedoCorpoSintoma = Convert.ToDouble(dr["CodPartedoCorpoSintoma"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {            
			if (!TestarCampos(banco, partedoCorpoSintoma))
				return false;
					
			var sql = "Update PartedoCorpoSintoma Set ";
			sql += "CodSintoma = " + banco.ObterDuplo(partedoCorpoSintoma.CodSintoma);
			sql += ", Descricao = " + banco.ObterTexto(partedoCorpoSintoma.Descricao, 256);
			sql += " Where CodPartedoCorpoSintoma = " + banco.ObterDuplo(partedoCorpoSintoma.CodPartedoCorpoSintoma);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
		{
			var sql = "Delete From PartedoCorpoSintoma ";
			sql += " Where CodPartedoCorpoSintoma = " + banco.ObterDuplo(partedoCorpoSintoma.CodPartedoCorpoSintoma);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, PartedoCorpoSintoma partedoCorpoSintoma)
        {
            return AlterarSQL(banco, partedoCorpoSintoma) || InserirSQL(banco, partedoCorpoSintoma);
        }
		 
		#endregion
		 
    }
}
