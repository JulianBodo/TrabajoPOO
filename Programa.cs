using System;

class Programa
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
        Console.WriteLine("MENÚ SISTEMA - \"Sabores Sublimes\"");
        Console.WriteLine("Seleccione una opción:");
        Console.WriteLine("1) Opción 1");
        Console.WriteLine("2) Opción 2");
        Console.WriteLine("3) Opción 3");
        Console.WriteLine("4) Salir");
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
        Console.WriteLine("Has seleccionado la Opción 2");
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
}
