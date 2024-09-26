using System;

public record Rectangulo(float Ancho, float Altura)
{
    // Método
    public float CalcularArea()
    {
        return Ancho * Altura;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangulo[] rectangulos = new Rectangulo[]
        {
            new Rectangulo(20, 10), 
            new Rectangulo(15, 25),
            new Rectangulo(30, 5),
            new Rectangulo(10, 10)
        };

        Console.WriteLine("╔═══════════════════════╦═══════════════════════════════╦═══════════════════════════════╗");
        Console.WriteLine("║ Ancho                 ║ Altura                        ║ Área                          ║");
        Console.WriteLine("╠═══════════════════════╬═══════════════════════════════╬═══════════════════════════════╣");

        foreach (var rectangulo in rectangulos)
        {
            Console.WriteLine($"║ {rectangulo.Ancho,-21} ║ {rectangulo.Altura,-29} ║ {rectangulo.CalcularArea(),-29} ║");
        }

        Console.WriteLine("╚═══════════════════════╩═══════════════════════════════╩═══════════════════════════════╝");
    }
}   