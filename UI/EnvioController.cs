class EnvioController
{
    static string url = Menu.connectionString;
    static string database = "Sublimes_Sabores";

    static EnvioServicio envioServicio = new EnvioServicio(
        new EnvioRepositorio(new MongoDBManager<Envio>(url, database, "Envio"))
    );

    public static void envioMenu()
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
                    envioServicio.crearEnvio();
                    break;
                case '2':
                envioServicio.leerEnvio();
                    break;
                case '3':
envioServicio.actualizarEnvio();
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
