class Repartidor
{
    long id { get; set; }
    string nombre { get; set; }
    string apellido { get; set; }
    public Repartidor(long id, string nombre, string apellido)
    {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
    }
}