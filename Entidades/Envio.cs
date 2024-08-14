public class Envio
{
    public long id { set; get; }
    public List<Producto> productos { set; get; }

    public Envio(long id, List<Producto> productos)
    {
        this.id = id;
        this.productos = productos;
    }
}