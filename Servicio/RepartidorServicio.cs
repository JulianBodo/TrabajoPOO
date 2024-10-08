
using MongoDB.Driver;

public class RepartidorServicio
{
    public RepartidorRepositorio repo;

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

        repo.UploadRepartidor(new Repartidor(0, nombre, apellido));
        Console.WriteLine("Repartidor creado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

 public List<Repartidor> leerRepartidor() //Caso 2, método leer repartidor
{
    Console.Clear();
    Console.WriteLine("Lista de Repartidores:");

    List<Repartidor> repartidores = repo.GetRepartidores();

    if (repartidores.Any())
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

    // Return the list of repartidores
    return repartidores;
}

    public void buscarRepartidor() // Caso 3, método buscar repartidor
    {
        Console.Clear();
        Console.WriteLine("Buscar Repartidor:");

        Console.Write("Ingrese el nombre del repartidor a buscar: ");
        string searchTerm = Console.ReadLine();

        List<Repartidor> repartidores = repo.FindRepartidoresByNombre(searchTerm);

        if (repartidores.Any())
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

        Console.Write($"Apellido actual ({repartidor.apellido}): ");
        string? address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
            repartidor.apellido = address;
        }
        repo.UpdateRepartidor(repartidor);
        Console.WriteLine("Repartidor actualizado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }

    public void deleteRepartidor() //Caso 5, método eliminar repartidor
    {
        Console.Clear();
        Console.WriteLine("Eliminar Repartidor:");
        Console.Write("Ingrese el ID del repartidor a eliminar: ");
        long id;
        while (!long.TryParse(Console.ReadLine(), out id))
            Console.WriteLine("Id inexistente. Ingrese un valor válido.");

        Repartidor repartidor = repo.GetRepartidorById(id);
        repo.DeleteRepartidorById(repartidor.id);

        Console.WriteLine("Repartidor eliminado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}
