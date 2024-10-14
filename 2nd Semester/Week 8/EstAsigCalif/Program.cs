using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Crear los registros Estudiante, Asignatura y Calificaciones, relacionados por campos, para una aplicación que permita realizar el CRUD para gestionar las calificaciones obtenidas por los estudiantes que cursas diferentes asignaturas en un semestre dado.

public struct Estudiante
{
    public string Nombre { get; set; }
    public string Matricula { get; set; }
}

public struct Asignatura
{
    public string Nombre { get; set; }
    public string Codigo { get; set; }
}

public struct Calificacion
{
    public Estudiante Estudiante { get; set; }
    public Asignatura Asignatura { get; set; }
    public float Nota { get; set; }
}

class Program
{
    static List<Calificacion> listaCalificaciones = new List<Calificacion>();
    static string filePath = "calificaciones.json";

    static void Main(string[] args)
    {
        CargarDatos();
        int opcion;
        do
        {
            Console.WriteLine(@"   _____      _ _  __ _                _                       
  / ____|    | (_)/ _(_)              (_)                      
 | |     __ _| |_| |_ _  ___ __ _  ___ _  ___  _ __   ___  ___ 
 | |    / _` | | |  _| |/ __/ _` |/ __| |/ _ \| '_ \ / _ \/ __|
 | |___| (_| | | | | | | (_| (_| | (__| | (_) | | | |  __/\__ \
  \_____\__,_|_|_|_| |_|\___\__,_|\___|_|\___/|_| |_|\___||___/                                                     
╔═══════════════════════════════╗
║         Menú principal        ║
╠═══╦════════════╦══════════╦═══╣
║ 1 ║ Crear      ║ Eliminar ║ 4 ║
╠═══╬════════════╬══════════╬═══╣
║ 2 ║ Leer       ║    Salir ║ 5 ║
╠═══╬════════════╬══════════╩═══╝
║ 3 ║ Actualizar ║ 
╚═══╩════════════╝");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Crear();
                    break;
                case 2:
                    Leer();
                    break;
                case 3:
                    Actualizar();
                    break;
                case 4:
                    Eliminar();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }

static void CargarDatos()
{
    if (File.Exists(filePath))
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            listaCalificaciones = JsonSerializer.Deserialize<List<Calificacion>>(fs);
        }
    }
}

static void Guardar()
{
    // Serializar la lista actualizada y sobrescribir el archivo
    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
    {
        // Para mayor legibilidad
        var options = new JsonSerializerOptions { WriteIndented = true };
        JsonSerializer.Serialize(fs, listaCalificaciones, options);
    }
}

static void Crear()
{
    Console.Clear();

    Console.WriteLine("Ingrese los datos de la calificación:");
    
    // Los datos del estudiante y de la asignatura son solicitados
    Estudiante estudiante = new Estudiante();
    Console.Write("Nombre del Estudiante: ");
    estudiante.Nombre = Console.ReadLine();
    Console.Write("Matrícula del Estudiante: ");
    estudiante.Matricula = Console.ReadLine();

    Asignatura asignatura = new Asignatura();
    Console.Write("Nombre de la Asignatura: ");
    asignatura.Nombre = Console.ReadLine();
    Console.Write("Código de la Asignatura: ");
    asignatura.Codigo = Console.ReadLine();

    // Validar si ya existe una calificación para el mismo estudiante y la misma asignatura
    bool existeCalificacion = listaCalificaciones.Exists(c => 
        c.Estudiante.Matricula == estudiante.Matricula && 
        c.Asignatura.Codigo == asignatura.Codigo);

    if (existeCalificacion)
    {
        Console.WriteLine("Error: Ya existe una calificación para este estudiante en esta asignatura.");
        Console.WriteLine("Ingrese cualquier cosa para continuar.");
        Console.ReadLine();
        Console.Clear();
        return; // No continúa con la creación de la nueva calificación
    }


    Calificacion calificacion = new Calificacion();
    calificacion.Estudiante = estudiante;
    calificacion.Asignatura = asignatura;
    
    int nota;
    while (true)
    {
        Console.Write("Nota (0-100): ");
        if (int.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 100)
        {
            calificacion.Nota = nota;
            break; // Salir del bucle si la nota es válida
        }
        else
        {
            Console.WriteLine("Error: La nota debe estar entre 0 y 100. Inténtalo de nuevo.");
        }
    }

    listaCalificaciones.Add(calificacion);
    Guardar();

    Console.Clear();
}
static void Leer()
{
    Console.Clear();

    if (File.Exists(filePath))
{
    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
        listaCalificaciones = JsonSerializer.Deserialize<List<Calificacion>>(fs);
    }

    Console.WriteLine(@"╔═══════════════════════╦══════════════╦════════════════════╦══════════╦════════════════╗
║ Estudiante            ║ Matrícula    ║ Asignatura         ║ Código   ║ Calificación   ║
╠═══════════════════════╩══════════════╩════════════════════╩══════════╩════════════════╣
║                                                                                       ║");

    foreach (var calificacion in listaCalificaciones)
    {
        Console.WriteLine($"║ {calificacion.Estudiante.Nombre,-21}   " +
                          $"{calificacion.Estudiante.Matricula,-12}   " +
                          $"{calificacion.Asignatura.Nombre,-18}   " +
                          $"{calificacion.Asignatura.Codigo,-8}   " +
                          $"{calificacion.Nota,-14} ║");
        Console.WriteLine("║                                                                                       ║");
    }
    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════╝");
}
    else
    {
        Console.WriteLine("El archivo no existe. \n");
    }
    Console.WriteLine("Ingrese cualquier cosa para continuar");
    string x = Console.ReadLine();
    Console.Clear();
}

    static void Actualizar()
{
    Console.Clear();

    if (File.Exists(filePath))
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            listaCalificaciones = JsonSerializer.Deserialize<List<Calificacion>>(fs);
        }

        Console.WriteLine(@"╔═══════════════════════╦══════════════╦════════════════════╦══════════╦════════════════╗
║ Estudiante            ║ Matrícula    ║ Asignatura         ║ Código   ║ Calificación   ║
╠═══════════════════════╩══════════════╩════════════════════╩══════════╩════════════════╣
║                                                                                       ║");

        foreach (var calificacion in listaCalificaciones)
        {
            Console.WriteLine($"║ {calificacion.Estudiante.Nombre,-21}   " +
                              $"{calificacion.Estudiante.Matricula,-12}   " +
                              $"{calificacion.Asignatura.Nombre,-18}   " +
                              $"{calificacion.Asignatura.Codigo,-8}   " +
                              $"{calificacion.Nota,-14} ║");
            Console.WriteLine("║                                                                                       ║");
        }
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════╝");
    }
    else
    {
        Console.WriteLine("El archivo no existe. \n");
    }

    Console.Write("Ingrese la matrícula del estudiante a actualizar: ");
    string matricula = Console.ReadLine();
    Console.Write("Ingrese el código de la asignatura a actualizar: ");
    string codigoAsignatura = Console.ReadLine();

    Calificacion? calificacionEncontrada = listaCalificaciones.Find(c => 
        c.Estudiante.Matricula == matricula && c.Asignatura.Codigo == codigoAsignatura);

    if (calificacionEncontrada.HasValue)
    {
        Calificacion calificacion = calificacionEncontrada.Value;

        // Actualización de la nota con validación
        int nuevaNota;
        while (true)
        {
            Console.Write($"Nueva Nota (actual: {calificacion.Nota}, 0-100): ");
            if (int.TryParse(Console.ReadLine(), out nuevaNota) && nuevaNota >= 0 && nuevaNota <= 100)
            {
                calificacion.Nota = nuevaNota;
                break; // Salir del bucle si la nueva nota es válida
            }
            else
            {
                Console.WriteLine("Error: La nota debe estar entre 0 y 100. Inténtalo de nuevo.");
            }
        }

        // Recorre la lista de calificaciones para encontrar la posición del primer elemento que cumpla con las condiciones
        int index = listaCalificaciones.FindIndex(c => 
            c.Estudiante.Matricula == matricula && c.Asignatura.Codigo == codigoAsignatura);
        listaCalificaciones[index] = calificacion;

        Console.WriteLine("Calificación actualizada exitosamente.");
    }
    else
    {
        Console.WriteLine("Calificación no encontrada.");
    }
    Guardar();

    Console.WriteLine("Ingrese cualquier cosa para continuar");
    string x = Console.ReadLine();
    Console.Clear();
}

    static void Eliminar()
    {
        Console.Clear();

    if (File.Exists(filePath))
    {
    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
    {
        listaCalificaciones = JsonSerializer.Deserialize<List<Calificacion>>(fs);
    }

    Console.WriteLine(@"╔═══════════════════════╦══════════════╦════════════════════╦══════════╦════════════════╗
║ Estudiante            ║ Matrícula    ║ Asignatura         ║ Código   ║ Calificación   ║
╠═══════════════════════╩══════════════╩════════════════════╩══════════╩════════════════╣
║                                                                                       ║");

    foreach (var calificacion in listaCalificaciones)
    {
        Console.WriteLine($"║ {calificacion.Estudiante.Nombre,-21}   " +
                          $"{calificacion.Estudiante.Matricula,-12}   " +
                          $"{calificacion.Asignatura.Nombre,-18}   " +
                          $"{calificacion.Asignatura.Codigo,-8}   " +
                          $"{calificacion.Nota,-14} ║");
        Console.WriteLine("║                                                                                       ║");
    }
    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════╝");
}
    else
    {
        Console.WriteLine("El archivo no existe. \n");
    }

        Console.Write("Ingrese la matrícula del estudiante a eliminar: ");
        string matricula = Console.ReadLine();
        Console.Write("Ingrese el código de la asignatura a eliminar: ");
        string codigoAsignatura = Console.ReadLine();

        int index = listaCalificaciones.FindIndex(c => 
            c.Estudiante.Matricula == matricula && c.Asignatura.Codigo == codigoAsignatura);

        if (index != -1)
        {
            listaCalificaciones.RemoveAt(index);
            Console.WriteLine("Calificación eliminada exitosamente.");
        }
        else
        {
            Console.WriteLine("Calificación no encontrada.");
        }
        Guardar();

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
        Console.Clear();
    }
}
