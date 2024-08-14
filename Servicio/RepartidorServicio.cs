
using MongoDB.Driver;

public class RepartidorServicio
{
    RepartidorRepositorio repo;

    public RepartidorServicio(RepartidorRepositorio repo)
    {
        this.repo = repo;
    }

    public void crearRepartidor() //Caso 1, método crear repartidor
    {
        Console.Clear();
        Console.WriteLine("Crear Repartidor:");

        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine();
        Console.Write("apellido: ");
        string? apellido = Console.ReadLine();

        repo.UploadCliente(new Repartidor(0, nombre, apellido));
        Console.WriteLine("Repartidor creado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void leerRepartidor() //Caso 2, método leer repartidor
    {
        Console.Clear();
        Console.WriteLine("Lista de Repartidores:");

        List<Repartidor> clientes = repo.GetClientes();

        if (clientes.Any())
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine(
                    $"ID: {cliente.id}, Nombre: {cliente.nombre}, Dirección: {cliente.address}"
                );
            }
        }
        else
        {
            Console.WriteLine("No hay clientes disponibles.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void buscarCliente() // Caso 3, método buscar cliente
    {
        Console.Clear();
        Console.WriteLine("Buscar Clientes:");

        Console.Write("Ingrese el nombre del cliente a buscar: ");
        string searchTerm = Console.ReadLine();

        List<Cliente> clientes = repo.FindClientesByNombre(searchTerm);

        if (clientes.Any())
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine(
                    $"ID: {cliente.id}, Nombre: {cliente.nombre}, Dirección: {cliente.address}"
                );
            }
        }
        else
        {
            Console.WriteLine("No se encontraron clientes con ese nombre.");
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

        Cliente cliente = repo.GetClienteById(id);

        Console.Write($"Nombre actual ({cliente.nombre}): ");
        string? nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre))
        {
            cliente.nombre = nombre;
        }

        Console.Write($"Dirección actual ({cliente.address}): ");
        string? address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
            cliente.address = address;
        }
        repo.UpdateCliente(cliente);
        Console.WriteLine("Cliente actualizado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void deleteCliente() //Caso 5, método eliminar cliente
    {
        Console.Clear();
        Console.WriteLine("Eliminar Cliente:");
        Console.Write("Ingrese el ID del cliente a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Cliente cliente = repo.GetClienteById(id);
        repo.DeleteClienteById(cliente.id);

        Console.WriteLine("Cliente eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
