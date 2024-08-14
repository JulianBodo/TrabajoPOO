class Producto
{
    public long Id { get; set; }
    public string? Nombre { get; set; }
    public float Precio { get; set; }

    public Producto(long Id, string Nombre, float Precio)
    {
        this.Id = Id;
        this.Nombre = Nombre;
        this.Precio = Precio;
    }
}
