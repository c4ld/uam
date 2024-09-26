using System;
using System.Collections.Generic;

public record Coche(string Marca, string Modelo, string Año); // Año como string

class Program
{
    static void Main(string[] args)
    {
        List<Coche> coches = new List<Coche>(); // Lista para almacenar los coches
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("[1] - Agregar coche");
            Console.WriteLine("[2] - Editar un coche");
            Console.WriteLine("[0] - Ver coches y salir");
            Console.Write("Selecciona una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarCoche(coches);
                    break;

                case "2":
                    EditarCoche(coches);
                    break;

                case "0":
                    VerCoches(coches);
                    salir = true; // Finaliza el programa después de ver los coches
                    break;

                default:
                    Console.WriteLine("Opción no válida, intenta nuevamente.");
                    break;
            }
        }
    }

    static void AgregarCoche(List<Coche> coches)
    {
        Console.WriteLine("\nIngresar información del nuevo coche:");

        Console.Write("Marca: ");
        string marca = Console.ReadLine();

        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        Console.Write("Año: ");
        string año = Console.ReadLine();

        // Agregar el nuevo coche a la lista
        coches.Add(new Coche(marca, modelo, año));

        Console.WriteLine("\nCoche agregado exitosamente.");
    }

    static void EditarCoche(List<Coche> coches)
    {
        if (coches.Count == 0)
        {
            Console.WriteLine("No hay coches para editar.");
            return;
        }

        Console.WriteLine("\nSelecciona el coche que deseas editar:");
        VerCoches(coches, soloLista: true); // Muestra la lista de coches sin tablas

        Console.Write("Ingresa el número del coche a editar: ");
        int indice;
        if (int.TryParse(Console.ReadLine(), out indice) && indice > 0 && indice <= coches.Count)
        {
            Coche coche = coches[indice - 1];

            Console.WriteLine($"\nEditando coche {indice}:");
            Console.WriteLine($"Marca actual: {coche.Marca}");
            Console.Write("Nueva marca (deja vacío para mantener): ");
            string nuevaMarca = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevaMarca)) coche = coche with { Marca = nuevaMarca };

            Console.WriteLine($"Modelo actual: {coche.Modelo}");
            Console.Write("Nuevo modelo (deja vacío para mantener): ");
            string nuevoModelo = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoModelo)) coche = coche with { Modelo = nuevoModelo };

            Console.WriteLine($"Año actual: {coche.Año}");
            Console.Write("Nuevo año (deja vacío para mantener): ");
            string nuevoAño = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoAño)) coche = coche with { Año = nuevoAño };

            coches[indice - 1] = coche; // Actualiza el coche en la lista

            Console.WriteLine("\nCoche editado exitosamente.");
        }
        else
        {
            Console.WriteLine("Número de coche no válido.");
        }
    }

    static void VerCoches(List<Coche> coches, bool soloLista = false)
    {
        if (coches.Count == 0)
        {
            Console.WriteLine("\nNo hay coches ingresados.");
            return;
        }

        if (soloLista)
        {
            for (int i = 0; i < coches.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {coches[i].Marca} {coches[i].Modelo} ({coches[i].Año})");
            }
            return;
        }

        // Mostrar coches en formato de tabla
        Console.WriteLine("\nCoches ingresados:");
        Console.WriteLine("╔═════════════════╦═════════════════╦═════════════════╗");
        Console.WriteLine("║ Marca           ║ Modelo          ║ Año             ║");
        Console.WriteLine("╠═════════════════╬═════════════════╬═════════════════╣");

        foreach (var coche in coches)
        {
            Console.WriteLine($"║ {coche.Marca,-15} ║ {coche.Modelo,-15} ║ {coche.Año,-15} ║");
        }

        Console.WriteLine("╚═════════════════╩═════════════════╩═════════════════╝");
    }
}
