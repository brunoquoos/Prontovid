using System.IO;

namespace Prontovid.Biblioteca
{
    public class PastasUtil
    {
        public static string RaizServidor { get; set; }
        public static string Temp { get { return Path.Combine(RaizServidor, "Temp"); } }



    }
}
