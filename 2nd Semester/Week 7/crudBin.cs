using System;
using System.IO;

class Programa
{
    static void Main()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("1. Crear archivo binario");
            Console.WriteLine("2. Leer archivo binario");
            Console.WriteLine("3. Actualizar archivo binario");
            Console.WriteLine("4. Eliminar archivo binario");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearArchivoBinario();
                    break;
                case "2":
                    LeerArchivoBinario();
                    break;
                case "3":
                    ActualizarArchivoBinario();
                    break;
                case "4":
                    EliminarArchivoBinario();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    static void CrearArchivoBinario()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();
        Console.Write("Escribe el contenido (texto) que será guardado en binario: ");
        string contenido = Console.ReadLine();

        try
        {
            using (BinaryWriter escritor = new BinaryWriter(File.Open(nombreArchivo, FileMode.Create)))
            {
                escritor.Write(contenido);
            }
            Console.WriteLine("Archivo binario creado exitosamente");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al crear el archivo binario: " + error.Message);
        }
    }

    static void LeerArchivoBinario()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            using (BinaryReader lector = new BinaryReader(File.Open(nombreArchivo, FileMode.Open)))
            {
                string contenido = lector.ReadString();
                Console.WriteLine("Contenido del archivo binario:");
                Console.WriteLine(contenido);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al leer el archivo binario: " + error.Message);
        }
    }

    static void ActualizarArchivoBinario()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            if (File.Exists(nombreArchivo))
            {
                Console.Write("Escribe el nuevo contenido (texto) que será guardado en binario: ");
                string nuevoContenido = Console.ReadLine();
                using (BinaryWriter escritor = new BinaryWriter(File.Open(nombreArchivo, FileMode.Create)))
                {
                    escritor.Write(nuevoContenido);
                }
                Console.WriteLine("Archivo binario actualizado exitosamente");
            }
            else
            {
                Console.WriteLine("El archivo no existe");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al actualizar el archivo binario: " + error.Message);
        }
    }

    static void EliminarArchivoBinario()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            File.Delete(nombreArchivo);
            Console.WriteLine("Archivo binario eliminado exitosamente");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al eliminar el archivo binario: " + error.Message);
        }
    }
}
