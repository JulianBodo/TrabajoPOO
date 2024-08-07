

class Menu
{
    static void Main()
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }

    private static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("MENÚ DE SISTEMA - \"Sublimes Sabores\"");
        Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║    (1) Producto    ║    (2) Detalle     ║     (X) Salir     ║");
        Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
        Console.WriteLine("Presione X para salir.");
        Console.Write("\r\nSeleccione una opción: ");

        switch (Console.ReadLine())
        {
            case "1":
                Option1();
                return true;
            case "2":
                Option2();
                return true;
            case "3":
                Option3();
                return true;
            case "4":
                Option4();
                return true;
            case "5":
                Option5();
                return true;    
            case "x":
                return false;
            default:
                return true;
        }
    }

    private static void Option1()
    {
        Console.Clear();
        Console.WriteLine("Has seleccionado la Opción 1");
        Console.WriteLine("\r\nPresione Enter para volver al menú principal");
        Console.ReadLine();
    }

    private static void Option2()
    {
        Console.Clear();
        Console.WriteLine(" ● \u001b[1m\u001b[4mDETALLE\u001b[0m\u001b[0m");
        Console.WriteLine(" ╠○ (1) Repartidor");
        Console.WriteLine(" ╠○ (2) Cliente");
        Console.WriteLine(" ╚○ (3) Envío");
        Console.WriteLine("\r\nPresione Enter para volver al menú principal");
        Console.ReadLine();
    }

    private static void Option3()
    {
        Console.Clear();
        Console.WriteLine("Has seleccionado la Opción 3");
        Console.WriteLine("\r\nPresione Enter para volver al menú principal");
        Console.ReadLine();
    }

    private static void Option4()
    {
        Console.Clear();
        Console.WriteLine("Has seleccionado la Opción 4");
        Console.WriteLine("\r\nPresione Enter para volver al menú principal");
        Console.ReadLine();
    }

    private static void Option5()
    {
        Console.Clear();
        Console.WriteLine("Has seleccionado la Opción 5");
        Console.WriteLine("\r\nPresione Enter para volver al menú principal");
        Console.ReadLine();
    }
}
