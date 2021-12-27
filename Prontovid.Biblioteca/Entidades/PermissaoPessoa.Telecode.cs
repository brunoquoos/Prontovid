using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace Prontovid.Biblioteca.Biblioteca.Entidades
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class PermissaoPessoa
    {
		#region Propriedades
		
        public double CodPermissao { get; set; }
        public double CodPessoa { get; set; }
        public double? CodAdmin { get; set; }

        public const string COLUNA_COD_PERMISSAO = "CodPermissao";
        public const string COLUNA_COD_PESSOA = "CodPessoa";
        public const string COLUNA_COD_ADMIN = "CodAdmin";
				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<PermissaoPessoa> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<PermissaoPessoa> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<PermissaoPessoa>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
                sql += "CodPermissao," + Texto.QuebraLinha;
                sql += "CodPessoa," + Texto.QuebraLinha;
                sql += "CodAdmin" + Texto.QuebraLinha;
                sql += " From PermissaoPessoa" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var permissaoPessoa = ConverterDataReader(banco, dr);
                    lista.Add(permissaoPessoa);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static PermissaoPessoa ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var permissaoPessoa = new PermissaoPessoa();

                    permissaoPessoa.CodPermissao = Convert.ToDouble(dr["CodPermissao"].ToString());
                    permissaoPessoa.CodPessoa = Convert.ToDouble(dr["CodPessoa"].ToString());
                    permissaoPessoa.CodAdmin = banco.ConverterDoubleNull(dr["CodAdmin"].ToString());

			
			return permissaoPessoa;
		}
		
		public static PermissaoPessoa ConsultarChave(IBanco banco, double codPermissao, double codPessoa)
        {            
			var lista = ConsultarSQL(banco, " Where CodPermissao = " + banco.ObterDuplo(codPermissao) + " and CodPessoa = " + banco.ObterDuplo(codPessoa));
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, PermissaoPessoa permissaoPessoa)
        {            
		return InserirSQL(banco, permissaoPessoa,false);

        }
		
		private static bool InserirSQL(IBanco banco, PermissaoPessoa permissaoPessoa,bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, permissaoPessoa))
					return false;
				
                string campos = "", valores = "";                

                campos += "CodPermissao, ";
                valores += banco.ObterDuplo(permissaoPessoa.CodPermissao) + ",";

                campos += "CodPessoa, ";
                valores += banco.ObterDuplo(permissaoPessoa.CodPessoa) + ",";

                campos += "CodAdmin ";
                valores += banco.ObterDuplo(permissaoPessoa.CodAdmin);

                var sql = "Insert into PermissaoPessoa(" + campos + ") Values(" + valores + ") ";

				var retorno = banco.Inserir(sql, true);
                return retorno;
			

        }
		
		private static bool AlterarSQL(IBanco banco, PermissaoPessoa permissaoPessoa)
        {            
			if (!TestarCampos(banco, permissaoPessoa))
				return false;
					
			var sql = "Update PermissaoPessoa Set ";
			sql += "CodAdmin = " + banco.ObterDuplo(permissaoPessoa.CodAdmin);
			sql += " Where CodPermissao = " + banco.ObterDuplo(permissaoPessoa.CodPermissao) + " and CodPessoa = " + banco.ObterDuplo(permissaoPessoa.CodPessoa);
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, PermissaoPessoa permissaoPessoa)
		{
			var sql = "Delete From PermissaoPessoa ";
			sql += " Where CodPermissao = " + banco.ObterDuplo(permissaoPessoa.CodPermissao) + " and CodPessoa = " + banco.ObterDuplo(permissaoPessoa.CodPessoa);
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, PermissaoPessoa permissaoPessoa)
        {
            return AlterarSQL(banco, permissaoPessoa) || InserirSQL(banco, permissaoPessoa);
        }
		 
		#endregion
		 
    }
}
