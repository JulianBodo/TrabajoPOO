class Producto
{
    long id { set; get; }
    string nombre { set; get; }
    float precio { set; get; }
    string observacion { set; get; }

    public Producto(long id, string nombre, float precio, string observacion)
    {
        this.id = id;
        this.nombre = nombre;
        this.precio = precio;
        this.observacion = observacion;
    }
}