using System.Collections.Generic;
using MongoDB.Driver;

public class ProductoServicio
{
    ProductoRepositorio repo;

    public ProductoServicio(ProductoRepositorio repo)
    {
        this.repo = repo;
    }

    public void crearProducto() //Caso 1, método crear producto
    {
        Console.Clear();
        Console.WriteLine("Crear Producto:");

        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine();
        Console.Write("Observaciones: ");
        string? observaciones = Console.ReadLine();
        Console.Write("Precio: ");
        float precio;
        while (!float.TryParse(Console.ReadLine(), out precio))
        {
            Console.Write("Por favor ingrese un precio válido: ");
        }

        repo.UploadProducto(new Producto(0, nombre, precio, observaciones));
        Console.WriteLine("Producto creado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void leerProductos() //Caso 2, método leer producto
    {
        Console.Clear();
        Console.WriteLine("Lista de Productos:");

        List<Producto> productos = repo.GetProductos();

        if (productos.Any())
        {
            foreach (var producto in productos)
            {
                Console.WriteLine(
                    $"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio:C}, Observaciones: {producto.observacion}"
                );
            }
        }
        else
        {
            Console.WriteLine("No hay productos disponibles.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void buscarProductos() // Caso 3, método buscar producto
    {
        Console.Clear();
        Console.WriteLine("Buscar Productos:");

        Console.Write("Ingrese el nombre del producto a buscar: ");
        string searchTerm = Console.ReadLine();

        List<Producto> productos = repo.FindProductosByNombre(searchTerm);

        if (productos.Any())
        {
            foreach (var producto in productos)
            {
                Console.WriteLine(
                    $"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio:C}"
                );
            }
        }
        else
        {
            Console.WriteLine("No se encontraron productos con ese nombre.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void actualizarProducto() //Caso 4, método actualizar producto
    {
        Console.Clear();
        Console.WriteLine("Actualizar Producto:");

        Console.Write("Ingrese el ID del producto a actualizar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Producto producto = repo.GetProductoById(id);

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
        repo.UpdateProducto(producto);
        Console.WriteLine("Producto actualizado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void eliminarProducto() //Caso 5, método eliminar producto
    {
        Console.Clear();
        Console.WriteLine("Eliminar Producto:");

        Console.Write("Ingrese el ID del producto a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Producto producto = repo.GetProductoById(id);
        repo.DeleteProductoById(producto.id);

        Console.WriteLine("Producto eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
