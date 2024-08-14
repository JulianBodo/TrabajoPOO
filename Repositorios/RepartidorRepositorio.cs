using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

public class RepartidorRepositorio
{
    private MongoDBManager<Repartidor> connection;

    public RepartidorRepositorio(MongoDBManager<Repartidor> manager)
    {
        connection = manager;
    }

    // Obtiene todos los objetos de clase Repartidor pertenecientes a la colección
    public List<Repartidor> GetRepartidores()
    {
        return connection.GetCollection().Find(new BsonDocument()).ToList();
    }

    public long GetMaxId()
    {
        var collection = connection.GetCollection();

        var maxIdRepartidor = collection
            .Find(new BsonDocument())
            .SortByDescending(r => r.id)
            .FirstOrDefault();

        return maxIdRepartidor != null ? maxIdRepartidor.id : 0;
    }

    public void UploadRepartidor(Repartidor repartidor)
    {
        repartidor.id = GetMaxId() + 1;
        var collection = connection.GetCollection();
        collection.InsertOne(repartidor);
    }

    public Repartidor GetRepartidorById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Repartidor>.Filter.Eq(r => r.id, id);
        return collection.Find(filter).FirstOrDefault();
    }

    public void DeleteRepartidorById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Repartidor>.Filter.Eq(r => r.id, id);
        var result = collection.DeleteOne(filter);

        if (result.DeletedCount == 0)
        {
            Console.WriteLine("Ningún repartidor con ese ID.");
        }
    }

    public void UpdateRepartidor(Repartidor repartidor)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Repartidor>.Filter.Eq(r => r.id, repartidor.id);
        var result = collection.ReplaceOne(filter, repartidor);

        if (result.ModifiedCount == 0)
        {
            Console.WriteLine("Ningún repartidor con ese ID o ningún cambio efectuado.");
        }
    }

    public List<Repartidor> FindRepartidoresByNombre(string searchTerm)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Repartidor>.Filter.Or(
            Builders<Repartidor>.Filter.Regex(r => r.nombre, new BsonRegularExpression(searchTerm, "i")),
            Builders<Repartidor>.Filter.Regex(r => r.apellido, new BsonRegularExpression(searchTerm, "i"))
        );
        return collection.Find(filter).ToList();
    }
}
