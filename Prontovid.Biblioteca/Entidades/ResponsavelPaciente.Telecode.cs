using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class ResponsavelPaciente
    {
		#region Propriedades
		
        public double CodPaciente { get; set; }
        public double CodResponsavel { get; set; }

        public const string COLUNA_COD_PACIENTE = "CodPaciente";
        public const string COLUNA_COD_RESPONSAVEL = "CodResponsavel";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<ResponsavelPaciente> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<ResponsavelPaciente> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<ResponsavelPaciente>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodPaciente," + Texto.QuebraLinha;
                sql += "CodResponsavel" + Texto.QuebraLinha;
                sql += " From ResponsavelPaciente" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var responsavelPaciente = ConverterDataReader(banco, dr);
                    lista.Add(responsavelPaciente);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static ResponsavelPaciente ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var responsavelPaciente = new ResponsavelPaciente();

                    responsavelPaciente.CodPaciente = Convert.ToDouble(dr["CodPaciente"].ToString());
                    responsavelPaciente.CodResponsavel = Convert.ToDouble(dr["CodResponsavel"].ToString());

			
			return responsavelPaciente;
		}
		
		public static ResponsavelPaciente ConsultarChave(IBanco banco, double codPaciente)
        {            
			var lista = ConsultarSQL(banco, " Where CodPaciente = " + banco.ObterDuplo(codPaciente));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {            
		return InserirSQL(banco, responsavelPaciente,false);

        }
		
		private static bool InserirSQL(IBanco banco, ResponsavelPaciente responsavelPaciente,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, responsavelPaciente))
					return false;
				
                string campos = "", valores = "";                

                campos += "CodPaciente, ";
                valores += banco.ObterDuplo(responsavelPaciente.CodPaciente) + ",";

                campos += "CodResponsavel ";
                valores += banco.ObterDuplo(responsavelPaciente.CodResponsavel);

                var sql = "Insert into ResponsavelPaciente(" + campos + ") Values(" + valores + ") ";

				var retorno = banco.Inserir(sql, true);
                return retorno;
			

        }
		
		private static bool AlterarSQL(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {            
			if (!TestarCampos(banco, responsavelPaciente))
				return false;
					
			var sql = "Update ResponsavelPaciente Set ";
			sql += "CodResponsavel = " + banco.ObterDuplo(responsavelPaciente.CodResponsavel);
			sql += " Where CodPaciente = " + banco.ObterDuplo(responsavelPaciente.CodPaciente);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, ResponsavelPaciente responsavelPaciente)
		{
			var sql = "Delete From ResponsavelPaciente ";
			sql += " Where CodPaciente = " + banco.ObterDuplo(responsavelPaciente.CodPaciente);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, ResponsavelPaciente responsavelPaciente)
        {
            return AlterarSQL(banco, responsavelPaciente) || InserirSQL(banco, responsavelPaciente);
        }
		 
		#endregion
		 
    }
}
