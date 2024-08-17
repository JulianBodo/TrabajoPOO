using System;
using System.Collections.Generic;
using MongoDB.Driver;

public class DetalleServicio
{
    private DetalleRepositorio repo;
    private RepartidorServicio repartidorService;
    private ClienteServicio clienteService;
    private EnvioServicio envioService;
    string url = Menu.connectionString;
    string database = "Sabores_Sublimes";

    public DetalleServicio(DetalleRepositorio repo)
    {
        this.repo = repo;
        // Assuming the other services are initialized similarly
        repartidorService = new RepartidorServicio(
            new RepartidorRepositorio(new MongoDBManager<Repartidor>(url, database, "Repartidor"))
        );
        clienteService = new ClienteServicio(
            new ClienteRepositorio(new MongoDBManager<Cliente>(url, database, "Cliente"))
        );
        envioService = new EnvioServicio(
            new EnvioRepositorio(new MongoDBManager<Envio>(url, database, "Envio"))
        );
    }

    public void crearDetalle()
    {
        Console.Clear();
        Console.WriteLine("Crear Detalle:");

        // Selecting a Repartidor
        Console.WriteLine("Seleccione un repartidor:");
        List<Repartidor> repartidores = repartidorService.leerRepartidor();
        if (!repartidores.Any())
        {
            Console.WriteLine("No hay repartidores disponibles.");
            return;
        }

        foreach (var repartidor in repartidores)
        {
            Console.WriteLine($"ID: {repartidor.id}, Nombre: {repartidor.nombre}");
        }

        Console.Write("Ingrese el ID del repartidor: ");
        long repartidorId = long.Parse(Console.ReadLine());
        var repartidorSeleccionado = repartidores.FirstOrDefault(r => r.id == repartidorId);

        if (repartidorSeleccionado == null)
        {
            Console.WriteLine("Repartidor no encontrado.");
            return;
        }

        // Selecting a Cliente
        Console.WriteLine("Seleccione un cliente:");
        List<Cliente> clientes = clienteService.leerCliente();
        if (!clientes.Any())
        {
            Console.WriteLine("No hay clientes disponibles.");
            return;
        }

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.id}, Nombre: {cliente.nombre}");
        }

        Console.Write("Ingrese el ID del cliente: ");
        long clienteId = long.Parse(Console.ReadLine());
        var clienteSeleccionado = clientes.FirstOrDefault(c => c.id == clienteId);

        if (clienteSeleccionado == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        // Selecting an Envio
        Console.WriteLine("Seleccione un envío:");
        List<Envio> envios = envioService.leerEnvio();
        if (!envios.Any())
        {
            Console.WriteLine("No hay envíos disponibles.");
            return;
        }

        foreach (var envio in envios)
        {
            Console.WriteLine($"ID: {envio.id}, Productos: {string.Join(", ", envio.productos.Select(p => p.nombre))}");
        }

        Console.Write("Ingrese el ID del envío: ");
        long envioId = long.Parse(Console.ReadLine());
        var envioSeleccionado = envios.FirstOrDefault(e => e.id == envioId);

        if (envioSeleccionado == null)
        {
            Console.WriteLine("Envío no encontrado.");
            return;
        }

        // Creating the Detalle
        Detalle nuevoDetalle = new Detalle(0, repartidorSeleccionado, clienteSeleccionado, envioSeleccionado);
        repo.UploadDetalle(nuevoDetalle);
        Console.WriteLine("Detalle creado exitosamente.");
    }

    public void leerDetalle()
    {
        Console.Clear();
        Console.WriteLine("Lista de detalles:");

        var detalles = repo.GetDetalles();

        if (detalles.Any())
        {
            foreach (var detalle in detalles)
            {
                Console.WriteLine($"ID Detalle: {detalle.id}");
                Console.WriteLine($"Repartidor: {detalle.repartidor.nombre}");
                Console.WriteLine($"Cliente: {detalle.cliente.nombre}");
                Console.WriteLine($"Envío ID: {detalle.envio.id}");
                Console.WriteLine("Productos en el envío:");
                foreach (var producto in detalle.envio.productos)
                {
                    Console.WriteLine($" - {producto.nombre}: {producto.precio:C}");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No hay detalles disponibles.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void actualizarDetalle()
    {
        Console.Clear();
        Console.WriteLine("Actualizar Detalle:");

        Console.Write("Ingrese el ID del detalle a actualizar: ");
        long id = long.Parse(Console.ReadLine());
        var detalle = repo.GetDetalleById(id);

        if (detalle == null)
        {
            Console.WriteLine("No se encontró un detalle con ese ID.");
            return;
        }

        // Updating the Repartidor, Cliente, or Envio if needed (similar process as in CrearDetalle)
        Console.WriteLine("¿Desea actualizar el repartidor? (S/N)");
        if (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Seleccione un repartidor:");
            var repartidores = repartidorService.leerRepartidor();

            foreach (var repartidor in repartidores)
            {
                Console.WriteLine($"ID: {repartidor.id}, Nombre: {repartidor.nombre}");
            }

            Console.Write("Ingrese el ID del repartidor: ");
            long repartidorId = long.Parse(Console.ReadLine());
            detalle.repartidor = repartidores.FirstOrDefault(r => r.id == repartidorId);
        }

        Console.WriteLine("¿Desea actualizar el cliente? (S/N)");
        if (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Seleccione un cliente:");
            var clientes = clienteService.leerCliente();

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.id}, Nombre: {cliente.nombre}");
            }

            Console.Write("Ingrese el ID del cliente: ");
            long clienteId = long.Parse(Console.ReadLine());
            detalle.cliente = clientes.FirstOrDefault(c => c.id == clienteId);
        }

        Console.WriteLine("¿Desea actualizar el envío? (S/N)");
        if (Console.ReadLine().Equals("S", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Seleccione un envío:");
            var envios = envioService.leerEnvio();

            foreach (var envio in envios)
            {
                Console.WriteLine($"ID: {envio.id}, Productos: {string.Join(", ", envio.productos.Select(p => p.nombre))}");
            }

            Console.Write("Ingrese el ID del envío: ");
            long envioId = long.Parse(Console.ReadLine());
            detalle.envio = envios.FirstOrDefault(e => e.id == envioId);
        }

        repo.UpdateDetalle(detalle);
        Console.WriteLine("Detalle actualizado exitosamente.");
    }

    public void eliminarDetalle()
    {
        Console.Clear();
        Console.WriteLine("Eliminar Detalle:");
        Console.Write("Ingrese el ID del detalle a eliminar: ");
        long id = long.Parse(Console.ReadLine());

        var detalle = repo.GetDetalleById(id);

        if (detalle != null)
        {
            repo.DeleteDetalleById(id);
            Console.WriteLine("Detalle eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró un detalle con ese ID.");
        }

        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }
}
