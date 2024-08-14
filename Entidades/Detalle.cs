public class Detalle
{
    public long id { set; get; }
    public Repartidor repartidor { set; get; }
    public Cliente cliente { set; get; }
    public Envio envio { set; get; }

    public Detalle(long id, Repartidor repartidor, Cliente cliente, Envio envio)
    {
        this.id = id;
        this.repartidor = repartidor;
        this.cliente = cliente;
        this.envio = envio;
    }
}