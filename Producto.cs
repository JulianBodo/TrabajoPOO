class Producto
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public float Precio { get; set; }

    public Producto(){}

    public Producto(long id, string? nombre, float precio)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
    }
}
