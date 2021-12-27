using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class NivelPermissao
    {
		#region Propriedades
		
        public double CodNivel { get; set; }
        public string DescricaoNivel { get; set; }

        public const string COLUNA_COD_NIVEL = "CodNivel";
        public const string COLUNA_DESCRICAO_NIVEL = "DescricaoNivel";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<NivelPermissao> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<NivelPermissao> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<NivelPermissao>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodNivel," + Texto.QuebraLinha;
                sql += "DescricaoNivel" + Texto.QuebraLinha;
                sql += " From NiveisPermissao" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var nivelPermissao = ConverterDataReader(banco, dr);
                    lista.Add(nivelPermissao);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static NivelPermissao ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var nivelPermissao = new NivelPermissao();

                    nivelPermissao.CodNivel = Convert.ToDouble(dr["CodNivel"].ToString());
                    nivelPermissao.DescricaoNivel = banco.ConverterTextoNull(dr["DescricaoNivel"].ToString());

			
			return nivelPermissao;
		}
		
		public static NivelPermissao ConsultarChave(IBanco banco, double codNivel)
        {            
			var lista = ConsultarSQL(banco, " Where CodNivel = " + banco.ObterDuplo(codNivel));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, NivelPermissao nivelPermissao)
        {            
		return InserirSQL(banco, nivelPermissao,false);

        }
		
		private static bool InserirSQL(IBanco banco, NivelPermissao nivelPermissao,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, nivelPermissao))
					return false;
				
                string campos = "", valores = "";                

                if(atribuirColunaIdentidade)
                {
                   campos += "CodNivel, ";
                   valores += banco.ObterDuplo(nivelPermissao.CodNivel) + ",";

                }
                campos += "DescricaoNivel ";
                valores += banco.ObterTexto(nivelPermissao.DescricaoNivel, 128);

                var sql = "Insert into NiveisPermissao(" + campos + ") Values(" + valores + ")  SELECT MAX( CodNivel ) as CodNivel from  NiveisPermissao";

				IDataReader dr = banco.Consultar(sql);
                if (dr.Read()) 
                    nivelPermissao.CodNivel = Convert.ToDouble(dr["CodNivel"].ToString());
                dr.Close();
                dr.Dispose();
                return true;
			

        }
		
		private static bool AlterarSQL(IBanco banco, NivelPermissao nivelPermissao)
        {            
			if (!TestarCampos(banco, nivelPermissao))
				return false;
					
			var sql = "Update NiveisPermissao Set ";
			sql += "DescricaoNivel = " + banco.ObterTexto(nivelPermissao.DescricaoNivel, 128);
			sql += " Where CodNivel = " + banco.ObterDuplo(nivelPermissao.CodNivel);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, NivelPermissao nivelPermissao)
		{
			var sql = "Delete From NiveisPermissao ";
			sql += " Where CodNivel = " + banco.ObterDuplo(nivelPermissao.CodNivel);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, NivelPermissao nivelPermissao)
        {
            return AlterarSQL(banco, nivelPermissao) || InserirSQL(banco, nivelPermissao);
        }
		 
		#endregion
		 
    }
}
