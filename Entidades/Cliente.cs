public class Cliente
{
    public long id { get; set; }
    public string nombre { get; set; }
    public string address { get; set; }

    public Cliente(long id, string nombre, string address)
    {
        this.id = id;
        this.nombre = nombre;
        this.address = address;
    }
}
