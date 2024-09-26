using System;

// 1. Crea un record llamado “Estudiante” con campos para Nombre, Edad, y Promedio. Luego, escribe un programa que cree una instancia de “Estudiante”, asigne valores a los campos, y muestre la información en la consola.

public record Estudiante
(
    string Nombre,
    int Edad,
    double Promedio
);

class Program
{
    static void Main(string[] args)
    {
        // Una instancia se crea
        Estudiante estudiante = new Estudiante("Roderick", 18, 93.2);

        // La información se muestra
        Console.WriteLine("Nombre: " + estudiante.Nombre);
        Console.WriteLine("Edad: " + estudiante.Edad);
        Console.WriteLine("Promedio: " + estudiante.Promedio);
    }
}