using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class ResponsavelAtivacao
    {
		#region Propriedades
		
        public double CodPaciente { get; set; }
        public double CodResponsavelAtivacao { get; set; }
        public DateTime DataAtivacao { get; set; }

        public const string COLUNA_COD_PACIENTE = "CodPaciente";
        public const string COLUNA_COD_RESPONSAVEL_ATIVACAO = "CodResponsavelAtivacao";
        public const string COLUNA_DATA_ATIVACAO = "DataAtivacao";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<ResponsavelAtivacao> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<ResponsavelAtivacao> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<ResponsavelAtivacao>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodPaciente," + Texto.QuebraLinha;
                sql += "CodResponsavelAtivacao," + Texto.QuebraLinha;
                sql += "DataAtivacao" + Texto.QuebraLinha;
                sql += " From ResponsavelAtivacao" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var responsavelAtivacao = ConverterDataReader(banco, dr);
                    lista.Add(responsavelAtivacao);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static ResponsavelAtivacao ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var responsavelAtivacao = new ResponsavelAtivacao();

                    responsavelAtivacao.CodPaciente = Convert.ToDouble(dr["CodPaciente"].ToString());
                    responsavelAtivacao.CodResponsavelAtivacao = Convert.ToDouble(dr["CodResponsavelAtivacao"].ToString());
                    responsavelAtivacao.DataAtivacao = Convert.ToDateTime(dr["DataAtivacao"].ToString());

			
			return responsavelAtivacao;
		}
		
		public static ResponsavelAtivacao ConsultarChave(IBanco banco, double codPaciente)
        {            
			var lista = ConsultarSQL(banco, " Where CodPaciente = " + banco.ObterDuplo(codPaciente));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {            
		return InserirSQL(banco, responsavelAtivacao,false);

        }
		
		private static bool InserirSQL(IBanco banco, ResponsavelAtivacao responsavelAtivacao,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, responsavelAtivacao))
					return false;
				
                string campos = "", valores = "";                

                campos += "CodPaciente, ";
                valores += banco.ObterDuplo(responsavelAtivacao.CodPaciente) + ",";

                campos += "CodResponsavelAtivacao, ";
                valores += banco.ObterDuplo(responsavelAtivacao.CodResponsavelAtivacao) + ",";

                campos += "DataAtivacao ";
                valores += banco.ObterDataHora(responsavelAtivacao.DataAtivacao);

                var sql = "Insert into ResponsavelAtivacao(" + campos + ") Values(" + valores + ") ";

				var retorno = banco.Inserir(sql, true);
                return retorno;
			

        }
		
		private static bool AlterarSQL(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {            
			if (!TestarCampos(banco, responsavelAtivacao))
				return false;
					
			var sql = "Update ResponsavelAtivacao Set ";
			sql += "CodResponsavelAtivacao = " + banco.ObterDuplo(responsavelAtivacao.CodResponsavelAtivacao);
			sql += ", DataAtivacao = " + banco.ObterDataHora(responsavelAtivacao.DataAtivacao);
			sql += " Where CodPaciente = " + banco.ObterDuplo(responsavelAtivacao.CodPaciente);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
		{
			var sql = "Delete From ResponsavelAtivacao ";
			sql += " Where CodPaciente = " + banco.ObterDuplo(responsavelAtivacao.CodPaciente);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, ResponsavelAtivacao responsavelAtivacao)
        {
            return AlterarSQL(banco, responsavelAtivacao) || InserirSQL(banco, responsavelAtivacao);
        }
		 
		#endregion
		 
    }
}
