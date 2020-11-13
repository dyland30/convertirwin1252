using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambiar_codificacion_txt
{
    public class Codificador
    {
        public void ConvertirListaWindows1252(string[] archivos)
        {

            foreach (string archivo in archivos)
            {
                ConvertirArchivoWindows1252(archivo);
                Console.WriteLine($"Se cambió la codificación del archivo {archivo}");

            }
        }

        public void ConvertirArchivoWindows1252(string archivo)
        {
            //leer archivo
            String[] lineas = File.ReadAllLines(archivo);
            //crear archivo
            //eliminar archivo anterior
            File.Delete(archivo);
            using (TextWriter tw = new StreamWriter(archivo, true, Encoding.GetEncoding(1252)))
            {
                foreach (String linea in lineas)
                {
                    tw.WriteLine(linea);
                }
            }
        }

    }
}
