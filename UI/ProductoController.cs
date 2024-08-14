
class ProductoController
{
    static string url = Menu.connectionString;
    static string database = "Sublimes_Sabores";

    static ProductoServicio productoServicio = new ProductoServicio(
        new ProductoRepositorio(new MongoDBManager<Producto>(url, database, "Producto"))
    );

    // Lista para almacenar los productos
    static List<Producto> productos = new List<Producto>();
    static long currentId = 1;

    public static void productMenu()
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
                    productoServicio.crearProducto();
                    break;
                case '2':
                    productoServicio.leerProductos();
                    break;
                case '3':
                    productoServicio.buscarProductos();
                    break;
                case '4':
                    productoServicio.actualizarProducto();
                    break;
                case '5':
                    productoServicio.eliminarProducto();
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
