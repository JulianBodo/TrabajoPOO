﻿using System;

class Menu
{
    public static string connectionString = "mongodb+srv://TrabajoPOO:TrabajoPOO@personal.t9z4q.mongodb.net/";

    static void Main(string[] args)
    {
        //Menú principal
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\u001b[1mMENÚ DE SISTEMA - \"Sublimes Sabores\"\u001b[0m\n");
            Console.WriteLine(
                "╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗"
            );
            Console.WriteLine(
                "║    (1) Producto    ║    (2) Cliente    ║    (3) Repartidor    ║    (4) Envio    ║    (5) Detalle    ║   (X) Salir    ║"
            );
            Console.WriteLine(
                "╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝"
            );
            Console.Write("\r\nSeleccione una opción: ");

            //Captura una tecla sin necesidad de presionar "Enter"
            var keyInfo = Console.ReadKey(intercept: true);
            char keyPressed = keyInfo.KeyChar;

            //Procesa la tecla presionada
            switch (keyPressed)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("● \u001b[1m\u001b[4mPRODUCTO\u001b[0m\u001b[0m");
                    ProductoController.productMenu();
                    Console.WriteLine("\r\nPresione Enter para volver al menú principal");
                    Console.ReadLine();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine(" ● \u001b[1m\u001b[4mCLIENTES\u001b[0m\u001b[0m");
                    ClienteController.clientMenu();
                    Console.WriteLine(
                        "\r\nSeleccione una opción o presione Enter para volver a atrás"
                    );
                    Console.ReadLine();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine(" ● \u001b[1m\u001b[4mREPARTIDORES\u001b[0m\u001b[0m");
                    RepartidorController.repartidorMenu();
                    Console.WriteLine(
                        "\r\nSeleccione una opción o presione Enter para volver a atrás"
                    );
                    Console.ReadLine();
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine(" ● \u001b[1m\u001b[4mENVIOS\u001b[0m\u001b[0m");
                    EnvioController.envioMenu();
                    Console.WriteLine(
                        "\r\nSeleccione una opción o presione Enter para volver a atrás"
                    );
                    Console.ReadLine();
                    break;
                case '5':
                    Console.Clear();
                    Console.WriteLine(" ● \u001b[1m\u001b[4mDETALLES\u001b[0m\u001b[0m");
                    DetalleController.detalleMenu();
                    Console.WriteLine(
                        "\r\nSeleccione una opción o presione Enter para volver a atrás"
                    );
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
