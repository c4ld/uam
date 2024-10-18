using System;

class CuentaBancaria
{
    static double saldo = 0.0;  // Variable que almacena el saldo de la cuenta

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            int opcion = ObtenerOpcion();

            switch (opcion)
            {
                case 1:
                    ConsultarSaldo();
                    break;
                case 2:
                    DepositarDinero();
                    break;
                case 3:
                    RetirarDinero();
                    break;
                case 4:
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("Menú de operaciones:");
        Console.WriteLine("1. Consultar saldo");
        Console.WriteLine("2. Depositar dinero");
        Console.WriteLine("3. Retirar dinero");
        Console.WriteLine("4. Salir");
        Console.Write("Selecciona una opción: ");
    }

    static int ObtenerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
        {
            Console.Write("Entrada no válida. Por favor, selecciona una opción entre 1 y 4: ");
        }
        return opcion;
    }

    static double ObtenerCantidad(string mensaje)
    {
        double cantidad;
        Console.Write(mensaje);
        while (!double.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
        {
            Console.Write("Cantidad no válida. Debe ser un número positivo. Intenta de nuevo: ");
        }
        return cantidad;
    }

    static void ConsultarSaldo()
    {
        Console.WriteLine($"El saldo actual es: {saldo:C2}");
    }

    static void DepositarDinero()
    {
        double cantidad = ObtenerCantidad("Introduce la cantidad a depositar: ");
        saldo += cantidad;
        Console.WriteLine($"Has depositado {cantidad:C2}. El nuevo saldo es: {saldo:C2}");
    }

    static void RetirarDinero()
    {
        double cantidad = ObtenerCantidad("Introduce la cantidad a retirar: ");
        if (cantidad > saldo)
        {
            Console.WriteLine($"No puedes retirar {cantidad:C2}. Saldo insuficiente.");
        }
        else
        {
            saldo -= cantidad;
            Console.WriteLine($"Has retirado {cantidad:C2}. El nuevo saldo es: {saldo:C2}");
        }
    }
}