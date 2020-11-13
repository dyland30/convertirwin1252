using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambiar_codificacion_txt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Codificador codificador = new Codificador();
                if (args.Length < 2 || args.Length > 4)
                {
                    string ayuda = @"
                Opciones disponibles:
                cambiar_codificacion_txt.exe -f <ruta_archivo>
                cambiar_codificacion_txt.exe -r <ruta_carpeta> (por defecto extensión .txt)
                cambiar_codificacion_txt.exe -r <ruta_carpeta> -e <extension>
                Ejemplo: cambiar_codificacion_txt.exe -r D:\carpeta -e csv";
                    Console.Write(ayuda);
                    Console.ReadLine();
                }
                else
                {
                    if (args[0].ToLower() == "-r" && args.Length == 2)
                    {
                        //extensión txt por defecto
                        string rutaCarpeta = args[1];
                        string[] fileArray = Directory.GetFiles(rutaCarpeta, "*.txt");
                        if (fileArray != null && fileArray.Length > 0)
                        {
                            codificador.ConvertirListaWindows1252(fileArray);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún archivo con la extensión txt");
                        }

                        

                    }
                    else if (args[0].ToLower() == "-r" && args.Length == 4)
                    {
                        //extension personalizada
                        string rutaCarpeta = args[1];
                        string ext = args[3].ToLower();

                        string[] fileArray = Directory.GetFiles(rutaCarpeta, $"*.{ext}");

                        if (fileArray != null && fileArray.Length > 0)
                        {
                            codificador.ConvertirListaWindows1252(fileArray);
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró ningún archivo con la extensión {ext}");
                        }

                       

                    }

                    else if (args[0].ToLower() == "-f")
                    {

                        string archivo = args[1];
                        codificador.ConvertirArchivoWindows1252(archivo);
                        Console.WriteLine($"Se cambió la codificación del archivo {archivo}");
                        

                    }

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);



            }

           

        }
    }
}
