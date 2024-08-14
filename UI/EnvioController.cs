class EnvioController
{
    static string url = Menu.connectionString;
    static string database = "Sublimes_Sabores";

    static RepartidorServicio repartidorServicio = new RepartidorServicio(
        new RepartidorRepositorio(new MongoDBManager<Repartidor>(url, database, "Envio"))
    );

    public static void repartidorMenu()
    {
        //Menú CRUD
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m\n");
            Console.WriteLine("Envíos");
            Console.WriteLine(
                "╔════════════════════════════════════════════════════════════════════════════════════════════════╗"
            );
            Console.WriteLine(
                "║    (1) Crear    ║    (2) Leer    ║    (3) Actualizar    ║    (4) Eliminar    ║    (X) Atrás    ║"
            );
            Console.WriteLine(
                "╚════════════════════════════════════════════════════════════════════════════════════════════════╝"
            );
            Console.Write("\r\nSeleccione una opción: ");

            var opcion = Console.ReadKey(intercept: true).KeyChar;

            switch (opcion)
            {
                case '1':
                    //        repartidorServicio.crearCliente();
                    break;
                case '2':
                    //      repartidorServicio.leerCliente();
                    break;
                case '3':
                    //    repartidorServicio.actualizarCliente();
                    break;
                case '4':
                    //    repartidorServicio.deleteCliente();
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
