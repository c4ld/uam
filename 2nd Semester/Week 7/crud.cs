using System;
using System.IO;

class Programa
{
    static void Main()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("1. Crear archivo");
            Console.WriteLine("2. Leer archivo");
            Console.WriteLine("3. Actualizar archivo");
            Console.WriteLine("4. Eliminar archivo");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearArchivo();
                    break;
                case "2":
                    LeerArchivo();
                    break;
                case "3":
                    ActualizarArchivo();
                    break;
                case "4":
                    EliminarArchivo();
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

    static void CrearArchivo()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();
        Console.Write("Escribe el contenido del archivo: ");
        string contenido = Console.ReadLine();

        try
        {
            File.WriteAllText(nombreArchivo, contenido);
            Console.WriteLine("Archivo creado exitosamente");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al crear el archivo: " + error.Message);
        }
    }

    static void LeerArchivo()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            string contenido = File.ReadAllText(nombreArchivo);
            Console.WriteLine("Contenido del archivo:");
            Console.WriteLine(contenido);
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al leer el archivo: " + error.Message);
        }
    }

    static void ActualizarArchivo()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            if (File.Exists(nombreArchivo))
            {
                Console.Write("Escribe el nuevo contenido del archivo: ");
                string nuevoContenido = Console.ReadLine();
                File.WriteAllText(nombreArchivo, nuevoContenido);
                Console.WriteLine("Archivo actualizado exitosamente");
            }
            else
            {
                Console.WriteLine("El archivo no existe");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al actualizar el archivo: " + error.Message);
        }
    }

    static void EliminarArchivo()
    {
        Console.Write("Escribe el nombre del archivo (con extensión): ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            File.Delete(nombreArchivo);
            Console.WriteLine("Archivo eliminado exitosamente");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al eliminar el archivo: " + error.Message);
        }
    }
}
