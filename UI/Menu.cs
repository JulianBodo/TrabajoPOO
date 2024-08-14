using System;

class Program
{
    static string url = "";
    static string database = "Sabores_sublimes";

    static string collection = "clientes";
    public MongoDBManager connection = new MongoDBManager(url, database, collection);
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m");
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    (1) Producto    ║    (2) Detalle     ║     (X) Salir     ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.Write("\r\nSeleccione una opción: ");

            // Captura una tecla sin necesidad de presionar "Enter"
            var keyInfo = Console.ReadKey(intercept: true);
            char keyPressed = keyInfo.KeyChar;

            // Procesa la tecla presionada
            switch (keyPressed)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("● \u001b[1m\u001b[4mPRODUCTO\u001b[0m\u001b[0m");
                    CRUD.productMenu();
                    Console.WriteLine("\r\nPresione Enter para volver al menú principal");
                    Console.ReadLine();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine(" ● \u001b[1m\u001b[4mDETALLE\u001b[0m\u001b[0m");
                    Console.WriteLine(" ╠○ (1) Repartidor");
                    Console.WriteLine(" ╠○ (2) Cliente");
                    Console.WriteLine(" ╚○ (3) Envío");
                    Console.WriteLine("\r\nSeleccione una opción o presione Enter para volver a atrás");
                    Console.ReadLine();
                    break;
                case 'x':
                    Console.WriteLine("\nSaliendo...");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("\nOpción no válida.");
                    Console.WriteLine("\r\nPresione Enter para volver al menú principal");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
