using System;
using System.Collections.Generic;
using System.Linq;

class CRUD
{
    // Lista para almacenar los productos
    static List<Producto> productos = new List<Producto>();
    static long currentId = 1;

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("Menú CRUD de Productos:");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Leer Productos");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");

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
                case '5':
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presiona Enter para continuar...");
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
            Console.Write("Por favor ingresa un precio válido: ");
        }

        productos.Add(new Producto { Id = currentId++, Nombre = nombre, Precio = precio });
        Console.WriteLine("Producto creado exitosamente. Presiona Enter para continuar...");
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
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio:C}");
            }
        }
        else
        {
            Console.WriteLine("No hay productos disponibles.");
        }
        Console.WriteLine("Presiona Enter para continuar...");
        Console.ReadLine();
    }

    static void ActualizarProducto()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Producto:");

        Console.Write("Ingresa el ID del producto a actualizar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id) || !productos.Any(p => p.Id == id))
        {
            Console.Write("ID no válido. Inténtalo de nuevo: ");
        }

        var producto = productos.First(p => p.Id == id);

        Console.Write($"Nombre actual ({producto.Nombre}): ");
        string? nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre))
        {
            producto.Nombre = nombre;
        }

        Console.Write($"Precio actual ({producto.Precio:C}): ");
        float precio;
        if (float.TryParse(Console.ReadLine(), out precio))
        {
            producto.Precio = precio;
        }

        Console.WriteLine("Producto actualizado exitosamente. Presiona Enter para continuar...");
        Console.ReadLine();
    }

    static void EliminarProducto()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Producto:");

        Console.Write("Ingresa el ID del producto a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id) || !productos.Any(p => p.Id == id))
        {
            Console.Write("ID no válido. Inténtalo de nuevo: ");
        }

        var producto = productos.First(p => p.Id == id);
        productos.Remove(producto);

        Console.WriteLine("Producto eliminado exitosamente. Presiona Enter para continuar...");
        Console.ReadLine();
    }
}
