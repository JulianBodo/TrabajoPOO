using MongoDB.Driver;
public class ProductoServicio {

ProductoRepositorio repo;

public ProductoServicio(ProductoRepositorio repo){
this.repo = repo;
}

public void crearProducto() //Caso 1, método crear producto
    {
        Console.Clear();
        Console.WriteLine("Crear Producto:");

        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine();
        Console.Write("Observaciones: ");
        string? observaciones = Console.ReadLine();
        Console.Write("Precio: ");
        float precio;
        while (!float.TryParse(Console.ReadLine(), out precio))
        {
            Console.Write("Por favor ingrese un precio válido: ");
        }

        repo.UploadProducto(new Producto(0, nombre, precio, observaciones));
        Console.WriteLine("Producto creado exitosamente. Presione Enter para continuar...");
        Console.ReadLine();
    }
}