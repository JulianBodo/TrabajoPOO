
class Envio
{
    long id { set; get; }
    List<Producto> productos { set; get; }

    public Envio(long id, List<Producto> productos)
    {
        this.id = id;
        this.productos = productos;
    }
}