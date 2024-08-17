
class DetalleController
{
    static string url = Menu.connectionString;
    static string database = "Sublimes_Sabores";

    static DetalleServicio detalleServicio = new DetalleServicio(
        new DetalleRepositorio(new MongoDBManager<Detalle>(url, database, "Detalle"))
    );

    // Lista para almacenar los detalles
    static List<Detalle> detalles = new List<Detalle>();
    static long currentId = 1;

    public static void detalleMenu()
    {
        //Menú CRUD
        bool continuar = true;
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m\n");
            Console.WriteLine("Detalles");
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
                    detalleServicio.crearDetalle();
                    break;
                case '2':
                    detalleServicio.leerDetalle();
                    break;
                case '3':
                    detalleServicio.actualizarDetalle();
                    break;
                case '4':
                    detalleServicio.eliminarDetalle();
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
