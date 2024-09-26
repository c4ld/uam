using System;

// 2. Crea un struct llamado “Producto” con campos para ID, Nombre, y Precio. Define un arreglo de “Producto” con 5 elementos, inicialízalo con datos de ejemplo, y escribe un programa que muestre los detalles de todos los productos en el arreglo.

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

        // 3. Utiliza el struct “Producto” del ejercicio anterior. Modifica el programa para calcular el precio total de todos los productos en el arreglo y muestra el resultado.
        
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

        // 6. Modifica el struct “Producto” para incluir un campo CantidadEnStock. Escribe un programa que busque todos los productos en el arreglo que tienen existencia baja es decir que la cantidad en stock es menor o igual que 5.  Muestre la lista de todos los productos que cumplen la condición de búsqueda.

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
