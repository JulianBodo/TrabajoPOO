using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
public class ClienteRepositorio
{
    MongoDBManager connection;
    long currentId;

    public ClienteRepositorio(MongoDBManager manager)
    {
        connection = manager;
    }

    // Obtiene todos los objetos de clase Cliente pertenecientes a la colección
    public List<Cliente> GetClientes()
    {
        return connection.GetCollection().Find(new BsonDocument()).ToList();
    }
}
