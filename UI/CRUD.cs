using System;
using System.Collections.Generic;
using System.Linq;

class CRUD
{
    // Lista para almacenar los productos
    static List<Producto> productos = new List<Producto>();
    static long currentId = 1;

    public static void productMenu()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m\n");
            Console.WriteLine("Productos");
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    (1) Crear    ║    (2) Leer    ║    (3) Actualizar    ║    (4) Eliminar    ║    (X) Atrás    ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.Write("\r\nSeleccione una opción: ");

            var opcion = Console.ReadKey(intercept: true).KeyChar;

            switch (opcion)
            {
                case '1':
                    CrearProducto();
                    break;
                case '2':
                    LeerProductos();
                    break;
                case '3':
                    ActualizarProducto();
                    break;
                case '4':
                    EliminarProducto();
                    break;
                case 'x':
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presione Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CrearProducto()
    {
        Console.Clear();
        Console.WriteLine("Crear Producto:");
        
        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine();
        
        Console.Write("Precio: ");
        float precio;
        while (!float.TryParse(Console.ReadLine(), out precio))
        {
            Console.Write("Por favor ingrese un precio válido: ");
        }

        productos.Add(new Producto(currentId++, nombre, precio, ""));
        Console.WriteLine("Producto creado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    static void LeerProductos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Productos:");

        if (productos.Any())
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio:C}");
            }
        }
        else
        {
            Console.WriteLine("No hay productos disponibles.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    static void ActualizarProducto()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Producto:");

        Console.Write("Ingrese el ID del producto a actualizar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id) || !productos.Any(p => p.id == id))
        {
            Console.Write("ID no válido. Inténtelo nuevamente: ");
        }

        var producto = productos.First(p => p.id == id);

        Console.Write($"Nombre actual ({producto.nombre}): ");
        string? nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre))
        {
            producto.nombre = nombre;
        }

        Console.Write($"Precio actual ({producto.precio:C}): ");
        float precio;
        if (float.TryParse(Console.ReadLine(), out precio))
        {
            producto.precio = precio;
        }

        Console.WriteLine("Producto actualizado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    static void EliminarProducto()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Producto:");

        Console.Write("Ingrese el ID del producto a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id) || !productos.Any(p => p.id == id))
        {
            Console.Write("ID no válido. Inténtelo nuevamente: ");
        }

        var producto = productos.First(p => p.id == id);
        productos.Remove(producto);

        Console.WriteLine("Producto eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
