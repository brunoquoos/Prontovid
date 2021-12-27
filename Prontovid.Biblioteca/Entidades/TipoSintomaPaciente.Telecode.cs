using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class TipoSintomaPaciente
    {
		#region Propriedades
		
        public double CodigoTipo { get; set; }
        public string DescricaoTipo { get; set; }
        public string NomeTipo { get; set; }

        public const string COLUNA_CODIGO_TIPO = "CodigoTipo";
        public const string COLUNA_DESCRICAO_TIPO = "DescricaoTipo";
        public const string COLUNA_NOME_TIPO = "NomeTipo";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<TipoSintomaPaciente> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<TipoSintomaPaciente> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<TipoSintomaPaciente>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodigoTipo," + Texto.QuebraLinha;
                sql += "DescricaoTipo," + Texto.QuebraLinha;
                sql += "NomeTipo" + Texto.QuebraLinha;
                sql += " From TiposSintomasPaciente" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var tipoSintomaPaciente = ConverterDataReader(banco, dr);
                    lista.Add(tipoSintomaPaciente);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static TipoSintomaPaciente ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var tipoSintomaPaciente = new TipoSintomaPaciente();

                    tipoSintomaPaciente.CodigoTipo = Convert.ToDouble(dr["CodigoTipo"].ToString());
                    tipoSintomaPaciente.DescricaoTipo = dr["DescricaoTipo"].ToString();
                    tipoSintomaPaciente.NomeTipo = dr["NomeTipo"].ToString();

			
			return tipoSintomaPaciente;
		}
		
		public static TipoSintomaPaciente ConsultarChave(IBanco banco, double codigoTipo)
        {            
			var lista = ConsultarSQL(banco, " Where CodigoTipo = " + banco.ObterDuplo(codigoTipo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {            
		return InserirSQL(banco, tipoSintomaPaciente,false);

        }
		
		private static bool InserirSQL(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, tipoSintomaPaciente))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "CodigoTipo, ";
                   valores += banco.ObterDuplo(tipoSintomaPaciente.CodigoTipo) + ",";

                }
                campos += "DescricaoTipo, ";
                valores += banco.ObterTexto(tipoSintomaPaciente.DescricaoTipo, 1024) + ",";

                campos += "NomeTipo ";
                valores += banco.ObterTexto(tipoSintomaPaciente.NomeTipo, 64);

                var sql = "Insert into TiposSintomasPaciente(" + campos + ") Values(" + valores + ")  SELECT MAX( CodigoTipo ) as CodigoTipo from  TiposSintomasPaciente";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    tipoSintomaPaciente.CodigoTipo = Convert.ToDouble(dr["CodigoTipo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {            
			if (!TestarCampos(banco, tipoSintomaPaciente))
				return false;
					
			var sql = "Update TiposSintomasPaciente Set ";
			sql += "DescricaoTipo = " + banco.ObterTexto(tipoSintomaPaciente.DescricaoTipo, 1024);
			sql += ", NomeTipo = " + banco.ObterTexto(tipoSintomaPaciente.NomeTipo, 64);
			sql += " Where CodigoTipo = " + banco.ObterDuplo(tipoSintomaPaciente.CodigoTipo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
		{
			var sql = "Delete From TiposSintomasPaciente ";
			sql += " Where CodigoTipo = " + banco.ObterDuplo(tipoSintomaPaciente.CodigoTipo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, TipoSintomaPaciente tipoSintomaPaciente)
        {
            return AlterarSQL(banco, tipoSintomaPaciente) || InserirSQL(banco, tipoSintomaPaciente);
        }
		 
		#endregion
		 
    }
}
