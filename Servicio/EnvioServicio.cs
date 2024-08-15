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
        new ProductoRepositorio(new MongoDBManager<Producto>(url, database, "Producto")));
    }

    public void crearEnvio() //Caso 1, método crear cliente
    {
        // Adquirir la lista de productos usando el método buscarProductos del servicio
        List<Producto> productos = service.buscarProductos();

        if (productos.Any())
        {
            Console.WriteLine("Ingrese los IDs de los productos a seleccionar para el envío (separados por comas): ");
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
                    Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio:C}");
                }

                Console.WriteLine("¿Desea confirmar la creación del envío con estos productos? (S/N)");
                string confirmacion = Console.ReadLine();

                if (confirmacion.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Envio nuevoEnvio = new Envio
                    {
                        // Suponiendo que Envio tiene una lista de productos
                        Productos = productosSeleccionados
                    };
                    // Guardar el envío en el repositorio
                    repo.GuardarEnvio(nuevoEnvio);
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


    public void leerCliente() //Caso 2, método leer cliente
    {
        Console.Clear();
        Console.WriteLine("Lista de envios:");

        List<Envio> envios = repo.GetEnvios();

        if (envios.Any())
        {
            foreach (var envio in envios)
            {
                Console.WriteLine(
                    $"ID: {envio.id}, Productos: {envio.productos}"
                );
            }
        }
        else
        {
            Console.WriteLine("No hay envios disponibles.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void actualizarCliente() //Caso 4, método actualizar cliente
    {
        Console.Clear();
        Console.WriteLine("Actualizar Cliente:");

        Console.Write("Ingrese el ID del cliente a actualizar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

//        Cliente cliente = repo.GetClienteById(id);

  //      Console.Write($"Nombre actual ({cliente.nombre}): ");
        string? nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre))
        {
//            cliente.nombre = nombre;
        }

   //     Console.Write($"Dirección actual ({cliente.address}): ");
        string? address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
     //       cliente.address = address;
        }
       // repo.UpdateCliente(cliente);
        Console.WriteLine("Cliente actualizado exitosamente. Presione Enter para continuar...");
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
        //repo.DeleteClienteById(envio.id);

        Console.WriteLine("Envio eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
