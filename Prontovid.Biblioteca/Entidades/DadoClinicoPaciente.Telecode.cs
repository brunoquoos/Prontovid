using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class DadoClinicoPaciente
    {
		#region Propriedades
		
        public double Codigo { get; set; }
        public decimal Altura { get; set; }
        public double CodPaciente { get; set; }
        public bool Diabetes { get; set; }
        public bool DoencaCromossomica { get; set; }
        public bool DoencaRenalApartirGrau3 { get; set; }
        public bool GestanteAltoRisco { get; set; }
        public bool Hipertensao { get; set; }
        public bool ImunoDepressao { get; set; }
        public bool InsuficienciaCardiaca { get; set; }
        public bool NeoplasiaMaligna { get; set; }
        public decimal Peso { get; set; }
        public bool PneumopatiasGraves { get; set; }
        public bool Tabagismo { get; set; }

        public const string COLUNA_CODIGO = "Codigo";
        public const string COLUNA_ALTURA = "Altura";
        public const string COLUNA_COD_PACIENTE = "CodPaciente";
        public const string COLUNA_DIABETES = "Diabetes";
        public const string COLUNA_DOENCA_CROMOSSOMICA = "DoencaCromossomica";
        public const string COLUNA_DOENCA_RENAL_APARTIR_GRAU3 = "DoencaRenalApartirGrau3";
        public const string COLUNA_GESTANTE_ALTO_RISCO = "GestanteAltoRisco";
        public const string COLUNA_HIPERTENSAO = "Hipertensao";
        public const string COLUNA_IMUNO_DEPRESSAO = "ImunoDepressao";
        public const string COLUNA_INSUFICIENCIA_CARDIACA = "InsuficienciaCardiaca";
        public const string COLUNA_NEOPLASIA_MALIGNA = "NeoplasiaMaligna";
        public const string COLUNA_PESO = "Peso";
        public const string COLUNA_PNEUMOPATIAS_GRAVES = "PneumopatiasGraves";
        public const string COLUNA_TABAGISMO = "Tabagismo";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<DadoClinicoPaciente> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<DadoClinicoPaciente> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<DadoClinicoPaciente>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "Codigo," + Texto.QuebraLinha;
                sql += "Altura," + Texto.QuebraLinha;
                sql += "CodPaciente," + Texto.QuebraLinha;
                sql += "Diabetes," + Texto.QuebraLinha;
                sql += "DoencaCromossomica," + Texto.QuebraLinha;
                sql += "DoencaRenalApartirGrau3," + Texto.QuebraLinha;
                sql += "GestanteAltoRisco," + Texto.QuebraLinha;
                sql += "Hipertensao," + Texto.QuebraLinha;
                sql += "ImunoDepressao," + Texto.QuebraLinha;
                sql += "InsuficienciaCardiaca," + Texto.QuebraLinha;
                sql += "NeoplasiaMaligna," + Texto.QuebraLinha;
                sql += "Peso," + Texto.QuebraLinha;
                sql += "PneumopatiasGraves," + Texto.QuebraLinha;
                sql += "Tabagismo" + Texto.QuebraLinha;
                sql += " From DadosClinicosPaciente" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var dadoClinicoPaciente = ConverterDataReader(banco, dr);
                    lista.Add(dadoClinicoPaciente);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static DadoClinicoPaciente ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var dadoClinicoPaciente = new DadoClinicoPaciente();

                    dadoClinicoPaciente.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                    dadoClinicoPaciente.Altura = Convert.ToDecimal(dr["Altura"].ToString());
                    dadoClinicoPaciente.CodPaciente = Convert.ToDouble(dr["CodPaciente"].ToString());
                    dadoClinicoPaciente.Diabetes = banco.RecuperarBooelan(dr["Diabetes"].ToString());
                    dadoClinicoPaciente.DoencaCromossomica = banco.RecuperarBooelan(dr["DoencaCromossomica"].ToString());
                    dadoClinicoPaciente.DoencaRenalApartirGrau3 = banco.RecuperarBooelan(dr["DoencaRenalApartirGrau3"].ToString());
                    dadoClinicoPaciente.GestanteAltoRisco = banco.RecuperarBooelan(dr["GestanteAltoRisco"].ToString());
                    dadoClinicoPaciente.Hipertensao = banco.RecuperarBooelan(dr["Hipertensao"].ToString());
                    dadoClinicoPaciente.ImunoDepressao = banco.RecuperarBooelan(dr["ImunoDepressao"].ToString());
                    dadoClinicoPaciente.InsuficienciaCardiaca = banco.RecuperarBooelan(dr["InsuficienciaCardiaca"].ToString());
                    dadoClinicoPaciente.NeoplasiaMaligna = banco.RecuperarBooelan(dr["NeoplasiaMaligna"].ToString());
                    dadoClinicoPaciente.Peso = Convert.ToDecimal(dr["Peso"].ToString());
                    dadoClinicoPaciente.PneumopatiasGraves = banco.RecuperarBooelan(dr["PneumopatiasGraves"].ToString());
                    dadoClinicoPaciente.Tabagismo = banco.RecuperarBooelan(dr["Tabagismo"].ToString());

			
			return dadoClinicoPaciente;
		}
		
		public static DadoClinicoPaciente ConsultarChave(IBanco banco, double codigo)
        {            
			var lista = ConsultarSQL(banco, " Where Codigo = " + banco.ObterDuplo(codigo));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {            
		return InserirSQL(banco, dadoClinicoPaciente,false);

        }
		
		private static bool InserirSQL(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, dadoClinicoPaciente))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "Codigo, ";
                   valores += banco.ObterDuplo(dadoClinicoPaciente.Codigo) + ",";

                }
                campos += "Altura, ";
                valores += banco.ObterMoeda(dadoClinicoPaciente.Altura, 2) + ",";

                campos += "CodPaciente, ";
                valores += banco.ObterDuplo(dadoClinicoPaciente.CodPaciente) + ",";

                campos += "Diabetes, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.Diabetes) + ",";

                campos += "DoencaCromossomica, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.DoencaCromossomica) + ",";

                campos += "DoencaRenalApartirGrau3, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.DoencaRenalApartirGrau3) + ",";

                campos += "GestanteAltoRisco, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.GestanteAltoRisco) + ",";

                campos += "Hipertensao, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.Hipertensao) + ",";

                campos += "ImunoDepressao, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.ImunoDepressao) + ",";

                campos += "InsuficienciaCardiaca, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.InsuficienciaCardiaca) + ",";

                campos += "NeoplasiaMaligna, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.NeoplasiaMaligna) + ",";

                campos += "Peso, ";
                valores += banco.ObterMoeda(dadoClinicoPaciente.Peso, 2) + ",";

                campos += "PneumopatiasGraves, ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.PneumopatiasGraves) + ",";

                campos += "Tabagismo ";
                valores += banco.ObterVerdadeiroFalso(dadoClinicoPaciente.Tabagismo);

                var sql = "Insert into DadosClinicosPaciente(" + campos + ") Values(" + valores + ")  SELECT MAX( Codigo ) as Codigo from  DadosClinicosPaciente";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    dadoClinicoPaciente.Codigo = Convert.ToDouble(dr["Codigo"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {            
			if (!TestarCampos(banco, dadoClinicoPaciente))
				return false;
					
			var sql = "Update DadosClinicosPaciente Set ";
			sql += "Altura = " + banco.ObterMoeda(dadoClinicoPaciente.Altura, 2);
			sql += ", CodPaciente = " + banco.ObterDuplo(dadoClinicoPaciente.CodPaciente);
			sql += ", Diabetes = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.Diabetes);
			sql += ", DoencaCromossomica = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.DoencaCromossomica);
			sql += ", DoencaRenalApartirGrau3 = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.DoencaRenalApartirGrau3);
			sql += ", GestanteAltoRisco = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.GestanteAltoRisco);
			sql += ", Hipertensao = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.Hipertensao);
			sql += ", ImunoDepressao = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.ImunoDepressao);
			sql += ", InsuficienciaCardiaca = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.InsuficienciaCardiaca);
			sql += ", NeoplasiaMaligna = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.NeoplasiaMaligna);
			sql += ", Peso = " + banco.ObterMoeda(dadoClinicoPaciente.Peso, 2);
			sql += ", PneumopatiasGraves = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.PneumopatiasGraves);
			sql += ", Tabagismo = " + banco.ObterVerdadeiroFalso(dadoClinicoPaciente.Tabagismo);
			sql += " Where Codigo = " + banco.ObterDuplo(dadoClinicoPaciente.Codigo);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
		{
			var sql = "Delete From DadosClinicosPaciente ";
			sql += " Where Codigo = " + banco.ObterDuplo(dadoClinicoPaciente.Codigo);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, DadoClinicoPaciente dadoClinicoPaciente)
        {
            return AlterarSQL(banco, dadoClinicoPaciente) || InserirSQL(banco, dadoClinicoPaciente);
        }
		 
		#endregion
		 
    }
}
