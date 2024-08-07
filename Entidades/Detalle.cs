class Detalle
{
    long id { set; get; }
    Repartidor repartidor { set; get; }
    Cliente cliente { set; get; }
    Envio envio { set; get; }

    public Detalle(long id, Repartidor repartidor, Cliente cliente, Envio envio)
    {
        this.id = id;
        this.repartidor = repartidor;
        this.cliente = cliente;
        this.envio = envio;
    }
}