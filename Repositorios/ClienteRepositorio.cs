using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

public class ClienteRepositorio
{
    MongoDBManager<Cliente> connection;

    public ClienteRepositorio(MongoDBManager<Cliente> manager)
    {
        connection = manager;
    }

    // Obtiene todos los objetos de clase Cliente pertenecientes a la colección
    public List<Cliente> GetClientes()
    {
        return connection.GetCollection().Find(new BsonDocument()).ToList();
    }

    public long GetMaxId()
    {
        var collection = connection.GetCollection();

        var maxIdCliente = collection
            .Find(new BsonDocument())
            .SortByDescending(c => c.id)
            .FirstOrDefault();

        return maxIdCliente != null ? maxIdCliente.id : 0;
    }

    public void UploadCliente(Cliente cliente)
    {
        cliente.id = GetMaxId() + 1;
        var collection = connection.GetCollection();
        collection.InsertOne(cliente);
    }

    public Cliente GetClienteById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Cliente>.Filter.Eq(c => c.id, id);
        return collection.Find(filter).FirstOrDefault();
    }

    public void DeleteClienteById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Cliente>.Filter.Eq(c => c.id, id);
        var result = collection.DeleteOne(filter);

        if (result.DeletedCount == 0)
        {
            Console.WriteLine("No Cliente found with the specified ID.");
        }
    }

     public void UpdateCliente(Cliente cliente)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Cliente>.Filter.Eq(c => c.id, cliente.id);

        var result = collection.ReplaceOne(filter, cliente);

        if (result.ModifiedCount == 0)
        {
            Console.WriteLine("No Cliente found with the specified ID, or no changes were made.");
        }
    }
}
