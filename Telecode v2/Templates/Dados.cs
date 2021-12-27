using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using uni = Telecon.Genericos.Classes.Outros.Universal;
using tele = Telecon.Genericos.Classes;
using msg = Telecon.Genericos.Classes.Outros.Msg;
using [Namespace].Modelo;

namespace [Namespace].Dados
{
	//Esta classe será sobreescrita pelo Telecode
    internal static class [NomeClasse]Dados
    {
		internal static List<[NomeClasse]> Consultar(string complementoSelect)
        {            
                List<[NomeClasse]> lista = new List<[NomeClasse]>();

                string sql;
                sql = " Select " + tele.TiposDados.Texto.QuebraLinha;
[CamposDoSelect]
                sql += " From [NomeTabela]" + tele.TiposDados.Texto.QuebraLinha;
                sql += " " + complementoSelect;

				IDataReader dr = uni.BancoDados.Consultar(sql);

                while (dr.Read())
                {
                    [NomeClasse] [NomeObjeto] = new [NomeClasse]();

[AtribuicoesDoDataReader]
                    lista.Add([NomeObjeto]);
                }
                dr.Close();
                dr.Dispose();

                return lista;            
        }
		
		internal static bool Inserir([NomeClasse] [NomeObjeto])
        {            
                string campos = "", valores = "";                

[AtribuicoesInsert]
                string sql = "Insert into [NomeTabela](" + campos + ") Values(" + valores + ")";

				try
				{
					int registrosAfetados = uni.BancoDados.ExecutarComando(sql);

					if (registrosAfetados > 0)
						return true;
					else
					{
						uni.UltimoErro = "Nenhum registro foi inserido!";
						return false;
					}
				}
				catch(Exception erro)
				{
					uni.UltimoErro = erro.Message;
					return false;
				}				
        }
		
		internal static bool Alterar([NomeClasse] [NomeObjeto])
        {            
			string sql = "Update [NomeTabela] Set ";
			[AtribuicoesUpdate]
			[WhereChavePrimaria]											
			try
			{
				int registrosAfetados = uni.BancoDados.ExecutarComando(sql);

				if (registrosAfetados > 0)
					return true;
				else
				{
					uni.UltimoErro = "Nenhum registro foi alterado!";
					return false;
				}

			}
			catch(Exception erro)
			{
				uni.UltimoErro = erro.Message;
				return false;
			}				
        }
		
        internal static bool Excluir([NomeClasse] [NomeObjeto])
		{
			string sql = "Delete From [NomeTabela] ";
			[WhereChavePrimaria]								
			try
			{
				int registrosAfetados = uni.BancoDados.ExecutarComando(sql);				
				if (registrosAfetados > 0)
					return true;
				else
				{
					uni.UltimoErro = "Nenhum registro foi excluído!";
					return false;
				}
				
			}
			catch(Exception erro)
			{
				uni.UltimoErro = erro.Message;
				return false;
			}
		}
    }
}
