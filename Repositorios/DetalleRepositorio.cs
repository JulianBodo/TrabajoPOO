using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

public class DetalleRepositorio
{
    private MongoDBManager<Detalle> connection;

    public DetalleRepositorio(MongoDBManager<Detalle> manager)
    {
        connection = manager;
    }

    // Obtiene todos los objetos de clase Detalle pertenecientes a la colección
    public List<Detalle> GetDetalles()
    {
        return connection.GetCollection().Find(new BsonDocument()).ToList();
    }

    public long GetMaxId()
    {
        var collection = connection.GetCollection();

        var maxIdDetalle = collection
            .Find(new BsonDocument())
            .SortByDescending(d => d.id)
            .FirstOrDefault();

        return maxIdDetalle != null ? maxIdDetalle.id : 0;
    }

    public void UploadDetalle(Detalle detalle)
    {
        detalle.id = GetMaxId() + 1;
        var collection = connection.GetCollection();
        collection.InsertOne(detalle);
    }

    public Detalle GetDetalleById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Detalle>.Filter.Eq(d => d.id, id);
        return collection.Find(filter).FirstOrDefault();
    }

    public void DeleteDetalleById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Detalle>.Filter.Eq(d => d.id, id);
        var result = collection.DeleteOne(filter);

        if (result.DeletedCount == 0)
        {
            Console.WriteLine("Ningún detalle con ese ID.");
        }
    }

    public void UpdateDetalle(Detalle detalle)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Detalle>.Filter.Eq(d => d.id, detalle.id);
        var result = collection.ReplaceOne(filter, detalle);

        if (result.ModifiedCount == 0)
        {
            Console.WriteLine("Ningún detalle con ese ID o ningún cambio efectuado.");
        }
    }
}
