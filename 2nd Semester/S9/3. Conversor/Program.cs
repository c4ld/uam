using System;

class ConversorUnidades
{
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
                    MetrosAKilometros();
                    break;
                case 2:
                    KilogramosAGramos();
                    break;
                case 3:
                    LitrosAMililitros();
                    break;
                case 4:
                    CelsiusAFahrenheit();
                    break;
                case 5:
                    HorasAMinutos();
                    break;
                case 6:
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
        Console.WriteLine("Menú de conversiones:");
        Console.WriteLine("1. Convertir metros a kilómetros");
        Console.WriteLine("2. Convertir kilogramos a gramos");
        Console.WriteLine("3. Convertir litros a mililitros");
        Console.WriteLine("4. Convertir Celsius a Fahrenheit");
        Console.WriteLine("5. Convertir horas a minutos");
        Console.WriteLine("6. Salir");
        Console.Write("Selecciona una opción: ");
    }

    static int ObtenerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
        {
            Console.Write("Entrada no válida. Por favor, selecciona una opción entre 1 y 6: ");
        }
        return opcion;
    }

    static double ObtenerNumero(string mensaje)
    {
        double numero;
        Console.Write(mensaje);
        while (!double.TryParse(Console.ReadLine(), out numero) || numero < 0)
        {
            Console.Write("Entrada no válida. Ingresa un valor positivo: ");
        }
        return numero;
    }

    static void MetrosAKilometros()
    {
        double metros = ObtenerNumero("Introduce la cantidad de metros: ");
        Console.WriteLine($"{metros} metros son {metros / 1000} kilómetros.");
    }

    static void KilogramosAGramos()
    {
        double kilogramos = ObtenerNumero("Introduce la cantidad de kilogramos: ");
        Console.WriteLine($"{kilogramos} kilogramos son {kilogramos * 1000} gramos.");
    }

    static void LitrosAMililitros()
    {
        double litros = ObtenerNumero("Introduce la cantidad de litros: ");
        Console.WriteLine($"{litros} litros son {litros * 1000} mililitros.");
    }

    static void CelsiusAFahrenheit()
    {
        double celsius = ObtenerNumero("Introduce la temperatura en grados Celsius: ");
        double fahrenheit = (celsius * 9 / 5) + 32;
        Console.WriteLine($"{celsius} grados Celsius son {fahrenheit} grados Fahrenheit.");
    }

    static void HorasAMinutos()
    {
        double horas = ObtenerNumero("Introduce la cantidad de horas: ");
        Console.WriteLine($"{horas} horas son {horas * 60} minutos.");
    }
}
