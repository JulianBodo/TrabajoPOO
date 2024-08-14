public class Repartidor
{
    public long id { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public Repartidor(long id, string nombre, string apellido)
    {
        this.id = id;
        this.nombre = nombre;
        this.apellido = apellido;
    }
}