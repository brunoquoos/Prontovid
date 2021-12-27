using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using uni = Telecon.Genericos.Classes.Outros.Universal;
using tele = Telecon.Genericos.Classes;
using msg = Telecon.Genericos.Classes.Outros.Msg;
using [Namespace].Modelo;
using [Namespace].Dados;

namespace [Namespace].Logica
{
	//Esta classe não será sobreescrita pelo Telecode
    internal static class [NomeClasse]Logica
    {
		internal static [NomeClasse] ConsultarChave([ParametrosChavePrimaria])
        {            
			List<[NomeClasse]> lista = [NomeClasse]Dados.Consultar([WhereChavePrimaria]);
			
			if (lista.Count == 0)
				return null;            
			else
				return lista[0];
        }
		
		public static bool Inserir([NomeClasse] [NomeObjeto])
        {            
            [SugerirProximoCodigo]
            if (TestarCampos([NomeObjeto]))
                return [NomeClasse]Dados.Inserir([NomeObjeto]);
            else
                return false;
        }
		
		public static bool Alterar([NomeClasse] [NomeObjeto])
        {            
			if (TestarCampos([NomeObjeto]))
                return [NomeClasse]Dados.Alterar([NomeObjeto]);
            else
                return false;
        }
		
		public static bool TestarCampos([NomeClasse] [NomeObjeto])
        {            
            return true;
        }
		
		public static bool Gravar([NomeClasse] [NomeObjeto])
        {
            if (Alterar([NomeObjeto]))
                return true;

            return Inserir([NomeObjeto]);
        }
		
        public static bool Excluir([NomeClasse] [NomeObjeto])
        {
            return [NomeClasse]Dados.Excluir([NomeObjeto]);
        }
    }
}
