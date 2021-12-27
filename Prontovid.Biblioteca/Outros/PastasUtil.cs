using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Telecon.Genericos.Classes.Arquivos;

namespace Prontovid.Biblioteca.Outros
{
    public class PastasUtil
    {
        public static string RaizServidor { get; set; }
        public static string Temp { get { return Path.Combine(RaizServidor, "Temp"); } }
        public static void LimparTemp()
        {
            var lista = Directory.GetFiles(Temp, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var arquivo in lista)
            {
                var ultimaModificacao = File.GetLastWriteTime(arquivo);
                if (ultimaModificacao < DateTime.Today.AddHours(-2))
                    Arquivo.Excluir(arquivo);
            }
        }


        
    }
}
