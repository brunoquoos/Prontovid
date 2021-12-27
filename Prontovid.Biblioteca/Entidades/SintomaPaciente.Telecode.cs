using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class SintomaPaciente
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public double CodPaciente { get; set; }
        public double CodStatusPessoa { get; set; }
        public DateTime DataInsercao { get; set; }
        public int EstadoGeral { get; set; }
        public double ResponsavelInsercao { get; set; }
        public double Saturacao { get; set; }
        public decimal Temperatura { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_COD_PACIENTE = "CodPaciente";
        public const string COLUNA_COD_STATUS_PESSOA = "CodStatusPessoa";
        public const string COLUNA_DATA_INSERCAO = "DataInsercao";
        public const string COLUNA_ESTADO_GERAL = "EstadoGeral";
        public const string COLUNA_RESPONSAVEL_INSERCAO = "ResponsavelInsercao";
        public const string COLUNA_SATURACAO = "Saturacao";
        public const string COLUNA_TEMPERATURA = "Temperatura";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<SintomaPaciente> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<SintomaPaciente> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<SintomaPaciente>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "CodPaciente," + Texto.QuebraLinha;
                sql += "CodStatusPessoa," + Texto.QuebraLinha;
                sql += "DataInsercao," + Texto.QuebraLinha;
                sql += "EstadoGeral," + Texto.QuebraLinha;
                sql += "ResponsavelInsercao," + Texto.QuebraLinha;
                sql += "Saturacao," + Texto.QuebraLinha;
                sql += "Temperatura" + Texto.QuebraLinha;
                sql += " From SintomasPaciente" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var sintomaPaciente = ConverterDataReader(banco, dr);
                    lista.Add(sintomaPaciente);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static SintomaPaciente ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var sintomaPaciente = new SintomaPaciente();

                    sintomaPaciente.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    sintomaPaciente.CodPaciente = Convert.ToDouble(dr["CodPaciente"].ToString());
                    sintomaPaciente.CodStatusPessoa = Convert.ToDouble(dr["CodStatusPessoa"].ToString());
                    sintomaPaciente.DataInsercao = Convert.ToDateTime(dr["DataInsercao"].ToString());
                    sintomaPaciente.EstadoGeral = Convert.ToInt32(dr["EstadoGeral"].ToString());
                    sintomaPaciente.ResponsavelInsercao = Convert.ToDouble(dr["ResponsavelInsercao"].ToString());
                    sintomaPaciente.Saturacao = Convert.ToDouble(dr["Saturacao"].ToString());
                    sintomaPaciente.Temperatura = Convert.ToDecimal(dr["Temperatura"].ToString());

			
			return sintomaPaciente;
		}
		
		public static SintomaPaciente ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, SintomaPaciente sintomaPaciente)
        {            
		return InserirSQL(banco, sintomaPaciente,false);

        }
		
		private static bool InserirSQL(IBanco banco, SintomaPaciente sintomaPaciente,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, sintomaPaciente))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(sintomaPaciente.Codigo) + ",";

                }
                campos += "CodPaciente, ";
                valores += banco.ObterDuplo(sintomaPaciente.CodPaciente) + ",";

                campos += "CodStatusPessoa, ";
                valores += banco.ObterDuplo(sintomaPaciente.CodStatusPessoa) + ",";

                campos += "DataInsercao, ";
                valores += banco.ObterDataHora(sintomaPaciente.DataInsercao) + ",";

                campos += "EstadoGeral, ";
                valores += banco.ObterInteiro(sintomaPaciente.EstadoGeral) + ",";

                campos += "ResponsavelInsercao, ";
                valores += banco.ObterDuplo(sintomaPaciente.ResponsavelInsercao) + ",";

                campos += "Saturacao, ";
                valores += banco.ObterDuplo(sintomaPaciente.Saturacao) + ",";

                campos += "Temperatura ";
                valores += banco.ObterMoeda(sintomaPaciente.Temperatura, 2);

                var sql = "Insert into SintomasPaciente(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  SintomasPaciente";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    sintomaPaciente.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, SintomaPaciente sintomaPaciente)
        {            
			if (!TestarCampos(banco, sintomaPaciente))
				return false;
					
			var sql = "Update SintomasPaciente Set ";
			sql += "CodPaciente = " + banco.ObterDuplo(sintomaPaciente.CodPaciente);
			sql += ", CodStatusPessoa = " + banco.ObterDuplo(sintomaPaciente.CodStatusPessoa);
			sql += ", DataInsercao = " + banco.ObterDataHora(sintomaPaciente.DataInsercao);
			sql += ", EstadoGeral = " + banco.ObterInteiro(sintomaPaciente.EstadoGeral);
			sql += ", ResponsavelInsercao = " + banco.ObterDuplo(sintomaPaciente.ResponsavelInsercao);
			sql += ", Saturacao = " + banco.ObterDuplo(sintomaPaciente.Saturacao);
			sql += ", Temperatura = " + banco.ObterMoeda(sintomaPaciente.Temperatura, 2);
			sql += " Where Codigo = " + banco.ObterDuplo(sintomaPaciente.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, SintomaPaciente sintomaPaciente)
		{
			var sql = "Delete From SintomasPaciente ";
			sql += " Where Codigo = " + banco.ObterDuplo(sintomaPaciente.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, SintomaPaciente sintomaPaciente)
        {
            return AlterarSQL(banco, sintomaPaciente) || InserirSQL(banco, sintomaPaciente);
        }
		 
		#endregion
		 
    }
}
