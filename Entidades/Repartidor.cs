class Repartidor
{
    long id;
    string nombre;
    string apellido;

    public Repartidor(long id, string name, string lastName)
    {
        setId(id);
        setNombre(name);
        setApellido(lastName);
    }

    public void setId(long id)
    {
        this.id = id;
    }
    public void setNombre(string name)
    {
        nombre = name;
    }

    public void setApellido(string lastName)
    {
        nombre = lastName;
    }

    public long getId()
    {
        return id;
    }

    public string getName()
    {
        return nombre;
    }

    public string getApellido()
    {
        return apellido;
    }
}