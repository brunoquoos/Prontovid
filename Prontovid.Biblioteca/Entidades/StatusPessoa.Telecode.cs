using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class StatusPessoa
    {
		#region Propriedades
		
        public double CodPaciente { get; set; }
        public double CodResponsavel { get; set; }
        public DateTime DataStatus { get; set; }
        public int CodStatus { get; set; }

        public const string COLUNA_COD_PACIENTE = "CodPaciente";
        public const string COLUNA_COD_RESPONSAVEL = "CodResponsavel";
        public const string COLUNA_DATA_STATUS = "DataStatus";
        public const string COLUNA_COD_STATUS = "CodStatus";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<StatusPessoa> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<StatusPessoa> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<StatusPessoa>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodPaciente," + Texto.QuebraLinha;
                sql += "CodResponsavel," + Texto.QuebraLinha;
                sql += "DataStatus," + Texto.QuebraLinha;
                sql += "CodStatus" + Texto.QuebraLinha;
                sql += " From StatusPessoa" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var statusPessoa = ConverterDataReader(banco, dr);
                    lista.Add(statusPessoa);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static StatusPessoa ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var statusPessoa = new StatusPessoa();

                    statusPessoa.CodPaciente = Convert.ToDouble(dr["CodPaciente"].ToString());
                    statusPessoa.CodResponsavel = Convert.ToDouble(dr["CodResponsavel"].ToString());
                    statusPessoa.DataStatus = Convert.ToDateTime(dr["DataStatus"].ToString());
                    statusPessoa.CodStatus = Convert.ToInt32(dr["CodStatus"].ToString());

			
			return statusPessoa;
		}
		
		public static StatusPessoa ConsultarChave(IBanco banco, double codPaciente, double codResponsavel, DateTime dataStatus)
        {            
			var lista = ConsultarSQL(banco, " Where CodPaciente = " + banco.ObterDuplo(codPaciente) + " and CodResponsavel = " + banco.ObterDuplo(codResponsavel) + " and DataStatus = " + banco.ObterDataHora(dataStatus));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, StatusPessoa statusPessoa)
        {            
		return InserirSQL(banco, statusPessoa,false);

        }
		
		private static bool InserirSQL(IBanco banco, StatusPessoa statusPessoa,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, statusPessoa))
					return false;
				
                string campos = "", valores = "";                

                campos += "CodPaciente, ";
                valores += banco.ObterDuplo(statusPessoa.CodPaciente) + ",";

                campos += "CodResponsavel, ";
                valores += banco.ObterDuplo(statusPessoa.CodResponsavel) + ",";

                campos += "DataStatus, ";
                valores += banco.ObterDataHora(statusPessoa.DataStatus) + ",";

                campos += "CodStatus ";
                valores += banco.ObterInteiro(statusPessoa.CodStatus);

                var sql = "Insert into StatusPessoa(" + campos + ") Values(" + valores + ") ";

				var retorno = banco.Inserir(sql, true);
                return retorno;
			

        }
		
		private static bool AlterarSQL(IBanco banco, StatusPessoa statusPessoa)
        {            
			if (!TestarCampos(banco, statusPessoa))
				return false;
					
			var sql = "Update StatusPessoa Set ";
			sql += "CodStatus = " + banco.ObterInteiro(statusPessoa.CodStatus);
			sql += " Where CodPaciente = " + banco.ObterDuplo(statusPessoa.CodPaciente) + " and CodResponsavel = " + banco.ObterDuplo(statusPessoa.CodResponsavel) + " and DataStatus = " + banco.ObterDataHora(statusPessoa.DataStatus);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, StatusPessoa statusPessoa)
		{
			var sql = "Delete From StatusPessoa ";
			sql += " Where CodPaciente = " + banco.ObterDuplo(statusPessoa.CodPaciente) + " and CodResponsavel = " + banco.ObterDuplo(statusPessoa.CodResponsavel) + " and DataStatus = " + banco.ObterDataHora(statusPessoa.DataStatus);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, StatusPessoa statusPessoa)
        {
            return AlterarSQL(banco, statusPessoa) || InserirSQL(banco, statusPessoa);
        }
		 
		#endregion
		 
    }
}
