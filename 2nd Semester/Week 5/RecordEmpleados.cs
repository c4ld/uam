using System;

// 4. Define un struct llamado “Empleado” que contenga un campo Nombre y otro Direccion, donde Direccion es otro struc` con campos para Calle, Ciudad, y CódigoPostal. Crea una instancia de ”Empleado”, asigna valores a todas las propiedades, y muestra la información completa del empleado en la consola.

public record Direccion
(
    string Calle,
    string Ciudad,
    string CodigoPostal
);

public record Empleado
(
    string Nombre,
    Direccion Direccion
);

class Program
{
    static void Main(string[] args)
    {
        // Crear un arreglo de empleados, incluyendo al nuevo empleado desde el principio
        Empleado[] empleados = new Empleado[]
        {
            new Empleado("Homer Simpson", new Direccion("Av. Siempre Viva 742", "Springfield", "12345")),
            new Empleado("Marge Simpson", new Direccion("Av. Siempre Viva 743", "Springfield", "12345")),
            new Empleado("Bart Simpson", new Direccion("Av. Principal 1", "Shelbyville", "54321")),
            new Empleado("Lisa Simpson", new Direccion("Calle Falsa 123", "Springfield", "12345")),
            new Empleado("Maggie Simpson", new Direccion("Calle Nueva 123", "Springfield", "67890"))
        };

        // Mostrar la información del nuevo empleado
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ Información del nuevo empleado                                                ║");
        Console.WriteLine("╠═════════════════════╦═════════════════════════════════════════════════════════╣");
        Console.WriteLine("║ Nombre              ║ Dirección                                               ║");
        Console.WriteLine("╠═════════════════════╬═════════════════════════════════════════════════════════╣");
        var nuevoEmpleado = empleados[0]; // Un empleado se imprime
        Console.WriteLine($"║ {nuevoEmpleado.Nombre,-19} ║ {nuevoEmpleado.Direccion.Calle}, {nuevoEmpleado.Direccion.Ciudad}, {nuevoEmpleado.Direccion.CodigoPostal,-20} ║");
        Console.WriteLine("╚═════════════════════╩═════════════════════════════════════════════════════════╝");

        // 5. Usa el struct “Empleado” del ejercicio anterior. Escribe un programa que filtre los empleados que viven en una ciudad específica y muestre la información de estos empleados.

        Console.Write("Ingrese la ciudad que desea buscar: ");
        string ciudadBuscada = Console.ReadLine();

        // Filtrar empleados por ciudad y mostrar en formato de tabla
        Console.WriteLine($"\nEmpleados que viven en {ciudadBuscada}:");
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║ Empleados en {ciudadBuscada, -64} ║");
        Console.WriteLine("╠═════════════════════╦═════════════════════════════════════════════════════════╣");
        Console.WriteLine("║ Nombre              ║ Dirección                                               ║");
        Console.WriteLine("╠═════════════════════╬═════════════════════════════════════════════════════════╣");

        bool hayEmpleados = false; // Para verificar si hay empleados en la ciudad
        foreach (var empleado in empleados)
        {
            if (empleado.Direccion.Ciudad == ciudadBuscada)
            {
                hayEmpleados = true;
                Console.WriteLine($"║ {empleado.Nombre, -19} ║ {empleado.Direccion.Calle}, {empleado.Direccion.Ciudad}, {empleado.Direccion.CodigoPostal,-20} ║");
            }
        }

        if (!hayEmpleados)
        {
            Console.WriteLine("║ No hay empleados en esta ciudad.                     ║");
        }

        Console.WriteLine("╚═════════════════════╩═════════════════════════════════════════════════════════╝");
    }
}
