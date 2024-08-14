
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

        List<Repartidor> repartidores = repo.GetRepartidor();

        if (clientes.Any())
        {
            foreach (var repartidor in repartidores)
            {
                Console.WriteLine(
                    $"ID: {repartidor.id}, Nombre: {repartidor.nombre}, Apellido: {repartidor.apellido}"
                );
            }
        }
        else
        {
            Console.WriteLine("No hay repartidores disponibles.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void buscarRepartidor() // Caso 3, método buscar repartidor
    {
        Console.Clear();
        Console.WriteLine("Buscar Repartidor:");

        Console.Write("Ingrese el nombre del repartidor a buscar: ");
        string searchTerm = Console.ReadLine();

        List<Repartidor> clientes = repo.FindRepartidoresByNombre(searchTerm);

        if (clientes.Any())
        {
            foreach (var repartidor in repartidores)
            {
                Console.WriteLine(
                    $"ID: {repartidor.id}, Nombre: {repartidor.nombre}, Apellido: {repartidor.apellido}"
                );
            }
        }
        else
        {
            Console.WriteLine("No se encontraron repartidores con ese nombre.");
        }
        Console.WriteLine("Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void actualizarRepartidor() //Caso 4, método actualizar repartidor
    {
        Console.Clear();
        Console.WriteLine("Actualizar Repartidor:");

        Console.Write("Ingrese el ID del repartidor a actualizar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Repartidor repartidor = repo.GetRepartidorById(id);

        Console.Write($"Nombre actual ({repartidor.nombre}): ");
        string? nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre))
        {
            repartidor.nombre = nombre;
        }

        Console.Write($"Dirección actual ({repartidor.address}): ");
        string? address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
            repartidor.address = address;
        }
        repo.UpdateCliente(repartidor);
        Console.WriteLine("Repartidor actualizado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void deleteCliente() //Caso 5, método eliminar repartidor
    {
        Console.Clear();
        Console.WriteLine("Eliminar Repartidor:");
        Console.Write("Ingrese el ID del repartidor a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Repartidor repartidor = repo.GetClienteById(id);
        repo.DeleteClienteById(repartidor.id);

        Console.WriteLine("Repartidor eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
