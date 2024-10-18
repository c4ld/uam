using System;

/*
Escribe un programa que implemente una calculadora con un menú de opciones para realizar diversas operaciones matemáticas. El programa debe incluir funciones para cada operación y debe validar las entradas del usuario.

Menú de opciones:
    1. Suma
    2. Resta
    3. Multiplicación
    4. División
    5. Potencia
    6. Raíz cuadrada
    7. Salir
El programa debe permitir al usuario seleccionar una opción del menú, solicitar los valores necesarios y mostrar el resultado. Si se elige la opción 7, el programa se debe cerrar.
*/

class Calculadora
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
                    Suma();
                    break;
                case 2:
                    Resta();
                    break;
                case 3:
                    Multiplicacion();
                    break;
                case 4:
                    Division();
                    break;
                case 5:
                    Potencia();
                    break;
                case 6:
                    RaizCuadrada();
                    break;
                case 7:
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
        Console.Clear();

        Console.WriteLine("Menú de opciones:");
        Console.WriteLine("1. Suma");
        Console.WriteLine("2. Resta");
        Console.WriteLine("3. Multiplicación");
        Console.WriteLine("4. División");
        Console.WriteLine("5. Potencia");
        Console.WriteLine("6. Raíz Cuadrada");
        Console.WriteLine("7. Salir");
        Console.Write("Selecciona una opción: ");
    }

    static int ObtenerOpcion()
    {
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 7)
        {
            Console.Write("Entrada no válida. Por favor, selecciona una opción entre 1 y 7: ");
        }
        return opcion;
    }

    static double ObtenerNumero(string mensaje)
    {
        double numero;
        Console.Write(mensaje);
        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.Write("Entrada no válida. Intenta nuevamente: ");
        }
        return numero;
    }

    static void Suma()
    {
        Console.Clear();

        double num1 = ObtenerNumero("Introduce el primer número: ");
        double num2 = ObtenerNumero("Introduce el segundo número: ");
        Console.WriteLine($"El resultado de la suma es: {num1 + num2}");

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
    }

    static void Resta()
    {
        Console.Clear();

        double num1 = ObtenerNumero("Introduce el primer número: ");
        double num2 = ObtenerNumero("Introduce el segundo número: ");
        Console.WriteLine($"El resultado de la resta es: {num1 - num2}");

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
    }

    static void Multiplicacion()
    {
        Console.Clear();

        double num1 = ObtenerNumero("Introduce el primer número: ");
        double num2 = ObtenerNumero("Introduce el segundo número: ");
        Console.WriteLine($"El resultado de la multiplicación es: {num1 * num2}");

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
    }

    static void Division()
    {
        Console.Clear();

        double num1 = ObtenerNumero("Introduce el dividendo: ");
        double num2 = ObtenerNumero("Introduce el divisor: ");
        while (num2 == 0)
        {
            Console.WriteLine("El divisor no puede ser 0. Inténtalo de nuevo.");
            num2 = ObtenerNumero("Introduce el divisor: ");
        }
        Console.WriteLine($"El resultado de la división es: {num1 / num2}");

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
    }

    static void Potencia()
    {
        Console.Clear();

        double baseNum = ObtenerNumero("Introduce la base: ");
        double exponente = ObtenerNumero("Introduce el exponente: ");
        Console.WriteLine($"El resultado de {baseNum} elevado a {exponente} es: {Math.Pow(baseNum, exponente)}");

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
    }

    static void RaizCuadrada()
    {
        Console.Clear();

        double numero = ObtenerNumero("Introduce el número: ");
        while (numero < 0)
        {
            Console.WriteLine("No se puede calcular la raíz cuadrada de un número negativo.");
            numero = ObtenerNumero("Introduce un número válido: ");
        }
        Console.WriteLine($"El resultado de la raíz cuadrada de {numero} es: {Math.Sqrt(numero)}");

        Console.WriteLine("Ingrese cualquier cosa para continuar");
        string x = Console.ReadLine();
    }
}