using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

public class EnvioRepositorio
{
    private MongoDBManager<Envio> connection;

    public EnvioRepositorio(MongoDBManager<Envio> manager)
    {
        connection = manager;
    }

    // Obtiene todos los objetos de clase Envio pertenecientes a la colección
    public List<Envio> GetEnvios()
    {
        return connection.GetCollection().Find(new BsonDocument()).ToList();
    }

    public long GetMaxId()
    {
        var collection = connection.GetCollection();

        var maxIdEnvio = collection
            .Find(new BsonDocument())
            .SortByDescending(e => e.id)
            .FirstOrDefault();

        return maxIdEnvio != null ? maxIdEnvio.id : 0;
    }

    public void UploadEnvio(Envio envio)
    {
        envio.id = GetMaxId() + 1;
        var collection = connection.GetCollection();
        collection.InsertOne(envio);
    }

    public Envio GetEnvioById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Envio>.Filter.Eq(e => e.id, id);
        return collection.Find(filter).FirstOrDefault();
    }

    public void DeleteEnvioById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Envio>.Filter.Eq(e => e.id, id);
        var result = collection.DeleteOne(filter);

        if (result.DeletedCount == 0)
        {
            Console.WriteLine("Ningún envío con ese ID.");
        }
    }

    public void UpdateEnvio(Envio envio)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Envio>.Filter.Eq(e => e.id, envio.id);
        var result = collection.ReplaceOne(filter, envio);

        if (result.ModifiedCount == 0)
        {
            Console.WriteLine("Ningún envío con ese ID o ningún cambio efectuado.");
        }
    }
}
