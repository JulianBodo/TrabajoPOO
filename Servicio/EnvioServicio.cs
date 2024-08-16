using System.Collections.Generic;
using MongoDB.Driver;

public class EnvioServicio
{
    string url = Menu.connectionString;
    string database = "Sublimes_Sabores";
    EnvioRepositorio repo;
    ProductoServicio service;

    public EnvioServicio(EnvioRepositorio repo)
    {
        this.repo = repo;
        service = new ProductoServicio(
            new ProductoRepositorio(new MongoDBManager<Producto>(url, database, "Producto"))
        );
    }

    public void crearEnvio() //Caso 1, método crear cliente
    {
        // Adquirir la lista de productos usando el método buscarProductos del servicio
        List<Producto> productos = service.buscarProductos();

        if (productos.Any())
        {
            Console.WriteLine(
                "Ingrese los IDs de los productos a seleccionar para el envío (separados por comas): "
            );
            string input = Console.ReadLine();
            var idsSeleccionados = input.Split(',').Select(id => id.Trim()).ToList();

            List<Producto> productosSeleccionados = new List<Producto>();

            foreach (var idStr in idsSeleccionados)
            {
                if (long.TryParse(idStr, out long id))
                {
                    Producto productoSeleccionado = productos.FirstOrDefault(p => p.id == id);
                    if (productoSeleccionado != null)
                    {
                        productosSeleccionados.Add(productoSeleccionado);
                    }
                    else
                    {
                        Console.WriteLine($"Producto con ID {id} no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine($"ID inválido: {idStr}");
                }
            }

            if (productosSeleccionados.Any())
            {
                Console.WriteLine("Productos seleccionados:");
                foreach (var producto in productosSeleccionados)
                {
                    Console.WriteLine(
                        $"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio:C}"
                    );
                }

                Console.WriteLine(
                    "¿Desea confirmar la creación del envío con estos productos? (S/N)"
                );
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Envio nuevoEnvio = new Envio(0, productosSeleccionados);
                    {
                        // Suponiendo que Envio tiene una lista de productos
                        productos = productosSeleccionados;
                    }
                    ;
                    // Guardar el envío en el repositorio
                    repo.UploadEnvio(nuevoEnvio);
                    Console.WriteLine("Envio creado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Creación de envío cancelada.");
                }
            }
            else
            {
                Console.WriteLine("No se seleccionaron productos válidos para el envío.");
            }
        }
        else
        {
            Console.WriteLine("No hay productos disponibles para seleccionar.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void leerEnvio() //Caso 2, método leer envio
    {
        Console.Clear();
        Console.WriteLine("Lista de envios:");

        List<Envio> envios = repo.GetEnvios();

        if (envios.Any())
        {
            foreach (var envio in envios)
            {
                Console.WriteLine($"Envío N°: {envio.id}");
                foreach (var producto in envio.productos)
                {
                    Console.WriteLine($"Nombre de producto: {producto.nombre}");
                    Console.WriteLine($"Precio: {producto.precio}");
                }
            }
        }
        else
        {
            Console.WriteLine("No hay envios disponibles.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void ActualizarEnvio()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Envío:");

        // Pedir el ID del envío a actualizar
        Console.Write("Ingrese el ID del envío a actualizar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("ID inválido. Ingrese un valor válido.");

        // Obtener el envío desde el repositorio
        Envio envio = repo.GetEnvioById(id);

        if (envio == null)
        {
            Console.WriteLine("No se encontró un envío con ese ID.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
            return;
        }

        // Obtener la lista de productos usando el método buscarProductos del servicio
        List<Producto> productos = service.buscarProductos();

        if (productos.Any())
        {
            Console.WriteLine(
                "Ingrese los IDs de los productos a seleccionar para actualizar el envío (separados por comas): "
            );
            string input = Console.ReadLine();
            var idsSeleccionados = input.Split(',').Select(id => id.Trim()).ToList();

            List<Producto> productosSeleccionados = new List<Producto>();

            foreach (var idStr in idsSeleccionados)
            {
                if (long.TryParse(idStr, out long prodId))
                {
                    Producto productoSeleccionado = productos.FirstOrDefault(p => p.id == prodId);
                    if (productoSeleccionado != null)
                    {
                        productosSeleccionados.Add(productoSeleccionado);
                    }
                    else
                    {
                        Console.WriteLine($"Producto con ID {prodId} no encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine($"ID inválido: {idStr}");
                }
            }

            if (productosSeleccionados.Any())
            {
                Console.WriteLine("Productos seleccionados para actualizar el envío:");
                foreach (var producto in productosSeleccionados)
                {
                    Console.WriteLine(
                        $"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio:C}"
                    );
                }

                Console.WriteLine(
                    "¿Desea confirmar la actualización del envío con estos productos? (S/N)"
                );
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    envio.Productos = productosSeleccionados; // Actualizar la lista de productos en el envío existente
                    repo.UploadEnvio(envio); // Asumiendo que este método también guarda cambios
                    Console.WriteLine("Envío actualizado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Actualización del envío cancelada.");
                }
            }
            else
            {
                Console.WriteLine(
                    "No se seleccionaron productos válidos para actualizar el envío."
                );
            }
        }
        else
        {
            Console.WriteLine("No hay productos disponibles para seleccionar.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void deleteEnvio() //Caso 5, método eliminar cliente
    {
        Console.Clear();
        Console.WriteLine("Eliminar Envio:");
        Console.Write("Ingrese el ID del envio a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Envio envio = repo.GetEnvioById(id);
        repo.DeleteEnvioById(envio.id);

        Console.WriteLine("Envio eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
