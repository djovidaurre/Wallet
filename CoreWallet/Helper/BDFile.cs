using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWallet.Helper
{
    public static class BDFile
    {
        public static void EscribeEnArchivo(string contenido, string rutaArchivo, bool sobrescribir = true)
        {
            StreamWriter sw = new StreamWriter(rutaArchivo, !sobrescribir);
            sw.Write(contenido);
            sw.Close();
        }

        public static string LeeArchivo(string rutaArchivo)
        {
            StreamReader sr = new StreamReader(rutaArchivo);
            string contenido = sr.ReadToEnd();
            sr.Close();
            return contenido;
        }
    }
}
