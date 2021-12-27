using System;
using System.Collections.Generic;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.TiposDados;
using System.Data;

namespace [Namespace]
{
	//Esta classe será sobreescrita pelo Telecode
	[Serializable]
    public partial class [NomeClasse]
    {
		#region Propriedades
		
[Declaracoes]				

		#endregion
		
		#region Consultas ao Banco de Dados
		
		private static List<[NomeClasse]> ConsultarSQL(IBanco banco, string complementoSelect)
		{
			return ConsultarSQL(banco, complementoSelect, "");
		}
		
		private static List<[NomeClasse]> ConsultarSQL(IBanco banco, string complementoSelect, string prefixoAposSelect)
        {            				
				var lista = new List<[NomeClasse]>();

                var sql = " Select " + prefixoAposSelect + " ";				
				sql += Texto.QuebraLinha;
[CamposDoSelect]
                sql += " From [NomeTabela]" + Texto.QuebraLinha;
                sql += " " + complementoSelect;

				var dr = banco.Consultar(sql, 0);

                while (dr.Read())
                {
                    var [NomeObjeto] = ConverterDataReader(banco, dr);
                    lista.Add([NomeObjeto]);
                }
                dr.Close();
                dr.Dispose();				
				
                return lista;            
        }
		
		public static [NomeClasse] ConverterDataReader(IBanco banco, IDataReader dr)
		{
			var [NomeObjeto] = new [NomeClasse]();

[AtribuicoesDoDataReader]
			
			return [NomeObjeto];
		}
		
		public static [NomeClasse] ConsultarChave(IBanco banco, [ParametrosChavePrimaria])
        {            
			var lista = ConsultarSQL(banco, [WhereChavePrimaria]);
			
			if (lista.Count == 0)
				return null;            
			
			return lista[0];
        }											
		
		#endregion
		
		#region Manipulação dos dados

		private static bool InserirSQL(IBanco banco, [NomeClasse] [NomeObjeto])
        {            
		return InserirSQL(banco, [NomeObjeto],false);

        }
		
		private static bool InserirSQL(IBanco banco, [NomeClasse] [NomeObjeto],bool atribuirColunaIdentidade)
        {            
				if (!TestarCampos(banco, [NomeObjeto]))
					return false;
				
                string campos = "", valores = "";                

[AtribuicoesInsert]
                var sql = "Insert into [NomeTabela](" + campos + ") Values(" + valores + ") [ObterChaveIdentidadeInsert]";

				[ObterExecucaoInsert]			

        }
		
		private static bool AlterarSQL(IBanco banco, [NomeClasse] [NomeObjeto])
        {            
			if (!TestarCampos(banco, [NomeObjeto]))
				return false;
					
			var sql = "Update [NomeTabela] Set ";
			[AtribuicoesUpdate]
			sql += [WhereChavePrimariaPropriedade];
			
			var retorno = banco.Alterar(sql, true);            

            return retorno;
        }
		
        private static bool ExcluirSQL(IBanco banco, [NomeClasse] [NomeObjeto])
		{
			var sql = "Delete From [NomeTabela] ";
			sql += [WhereChavePrimariaPropriedade];
						
			var retorno = banco.Excluir(sql, true);

            return retorno;
		}								
		
		private static bool GravarSQL(IBanco banco, [NomeClasse] [NomeObjeto])
        {
            return AlterarSQL(banco, [NomeObjeto]) || InserirSQL(banco, [NomeObjeto]);
        }
		 
		#endregion
		 
    }
}
