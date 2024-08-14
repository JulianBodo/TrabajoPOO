class ClienteController
{
    static string url = "string de conexion";
    static string database = "Sublimes_Sabores";

    static ClienteServicio clienteServicio = new ClienteServicio(
        new ClienteRepositorio(new MongoDBManager<Cliente>(url, database, "Cliente"))
    );

    // Lista para almacenar los productos
    static List<Cliente> clientes = new List<Cliente>();
    static long currentId = 1;

    public static void clientMenu()
    {
        //Menú CRUD
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m\n");
            Console.WriteLine("Productos");
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
                    clienteServicio.crearCliente();
                    break;
                case '2':
                    clienteServicio.leerCliente();
                    break;
                case '3':
                    clienteServicio.buscarCliente();
                    break;
                case '4':
                    clienteServicio.actualizarCliente();
                    break;
                case '5':
                    clienteServicio.eliminarCLiente();
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
