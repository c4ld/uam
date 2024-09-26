using System;

public record Producto
(
    string ID,
    string Nombre,
    double Precio,
    int CantidadEnStock
);

class Program
{
    static void Main(string[] args)
    {
        Producto[] productos = new Producto[]
        {
            new Producto("P001", "Laptop", 950.99, 3),
            new Producto("P002", "Mouse", 25.50, 10),
            new Producto("P003", "Teclado", 45.00, 2),
            new Producto("P004", "Monitor", 199.99, 7),
            new Producto("P005", "Impresora", 120.00, 5)
        };

        double precioTotal = 0;

        // Mostrar los productos
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║Lista de productos                                      ║");
        Console.WriteLine("╠══════════╦═════════════════╦═══════════════╦═══════════╣");
        Console.WriteLine("║ID        ║Nombre           ║Precio         ║En stock   ║");
        Console.WriteLine("╠══════════╬═════════════════╬═══════════════╬═══════════╣");
        foreach (var producto in productos)
        {
            Console.WriteLine($"║{producto.ID,-10}║{producto.Nombre,-17}║{producto.Precio,-15:C}║{producto.CantidadEnStock,-11}║");
            precioTotal += producto.Precio * producto.CantidadEnStock;
        }
        Console.WriteLine("╠══════════╩═╦═══════════════╩═══════════════╩═══════════╣");
        Console.WriteLine($"║Precio total║{precioTotal,43:C}║");
        Console.WriteLine("╚════════════╩═══════════════════════════════════════════╝");

        double precioTotalStockBajo = 0;

        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║Productos en stock bajo (≤5)                            ║");
        Console.WriteLine("╠══════════╦═════════════════╦═══════════════╦═══════════╣");
        Console.WriteLine("║ID        ║Nombre           ║Precio         ║En stock   ║");
        Console.WriteLine("╠══════════╬═════════════════╬═══════════════╬═══════════╣");
        foreach (var producto in productos)
        {
            if (producto.CantidadEnStock <= 5)
            {
                Console.WriteLine($"║{producto.ID,-10}║{producto.Nombre,-17}║{producto.Precio,-15:C}║{producto.CantidadEnStock,-11}║");
                precioTotalStockBajo += producto.Precio * producto.CantidadEnStock;
            }
        }
        Console.WriteLine("╠══════════╩═╦═══════════════╩═══════════════╩═══════════╣");
        Console.WriteLine($"║Precio total║{precioTotalStockBajo,43:C}║");
        Console.WriteLine("╚════════════╩═══════════════════════════════════════════╝");
    }
}
