using System;

// 8. Crea un struct llamado “CuentaBancaria” con campos para NumeroDeCuenta, NombreTitular, y Saldo. Agrega un constructor que permita inicializar todos los campos. Crea un arreglo de “CuentaBancaria”, inicialízalo usando el constructor, y muestra la información de cada cuenta.

public record CuentaBancaria
(
string NumeroDeCuenta,
string NombreTitular,
decimal Saldo
);

class Program
{
    static void Main(string[] args)
    {
        CuentaBancaria[] cuentas = new CuentaBancaria[]
        {
            new CuentaBancaria("123456789", "Juan Pérez", 1500.50m),
            new CuentaBancaria("987654321", "Ana Gómez", 3200.75m),
            new CuentaBancaria("456789123", "Luis García", 500.00m),
            new CuentaBancaria("789123456", "María López", 9800.10m)
        };

        Console.WriteLine("╔═══════════════════════╦═══════════════════════════════╦═════════════════════╗");
        Console.WriteLine("║ Número de Cuenta      ║ Nombre del Titular            ║ Saldo               ║");
        Console.WriteLine("╠═══════════════════════╬═══════════════════════════════╬═════════════════════╣");

        foreach (var cuenta in cuentas)
        {
            Console.WriteLine($"║ {cuenta.NumeroDeCuenta,-21} ║ {cuenta.NombreTitular,-29} ║ {cuenta.Saldo,-19:C} ║");
        }

        Console.WriteLine("╚═══════════════════════╩═══════════════════════════════╩═════════════════════╝");
    }
}
