class RepartidorController
{
    static string url = Menu.connectionString;
    static string database = "Sublimes_Sabores";

    static RepartidorServicio repartidorServicio = new RepartidorServicio(
        new RepartidorRepositorio(new MongoDBManager<Repartidor>(url, database, "Repartidor"))
    );

    // Lista para almacenar los productos
    static List<Cliente> clientes = new List<Cliente>();
    static long currentId = 1;

    public static void repartidorMenu()
    {
        //Menú CRUD
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m\n");
            Console.WriteLine("Repartidores");
            Console.WriteLine(
                "╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗"
            );
            Console.WriteLine(
                "║    (1) Crear    ║    (2) Leer    ║    (3) Buscar    ║    (4) Actualizar    ║    (5) Eliminar    ║    (X) Atrás    ║"
            );
            Console.WriteLine(
                "╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝"
            );
            Console.Write("\r\nSeleccione una opción: ");

            var opcion = Console.ReadKey(intercept: true).KeyChar;

            switch (opcion)
            {
                case '1':
                    repartidorServicio.crearRepartidor();
                    break;
                case '2':
                    repartidorServicio.leerRepartidor();
                    break;
                case '3':
                    repartidorServicio.buscarRepartidor();
                    break;
                case '4':
                    repartidorServicio.actualizarRepartidor();
                    break;
                case '5':
                    repartidorServicio.deleteRepartidor();
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
}
