public class Producto
{
    public long id { set; get; }
    public string nombre { set; get; }
    public float precio { set; get; }
    public string observacion { set; get; }

    public Producto(long id, string nombre, float precio, string observacion)
    {
        this.id = id;
        this.nombre = nombre;
        this.precio = precio;
        this.observacion = observacion;
    }
}