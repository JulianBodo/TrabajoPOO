using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

public class ProductoRepositorio
{
    private MongoDBManager<Producto> connection;

    public ProductoRepositorio(MongoDBManager<Producto> manager)
    {
        connection = manager;
    }

    // Obtiene todos los objetos de clase Producto pertenecientes a la colección
    public List<Producto> GetProductos()
    {
        return connection.GetCollection().Find(new BsonDocument()).ToList();
    }

    public long GetMaxId()
    {
        var collection = connection.GetCollection();

        var maxIdProducto = collection
            .Find(new BsonDocument())
            .SortByDescending(p => p.id)
            .FirstOrDefault();

        return maxIdProducto != null ? maxIdProducto.id : 0;
    }

    public void UploadProducto(Producto producto)
    {
        producto.id = GetMaxId() + 1;
        var collection = connection.GetCollection();
        collection.InsertOne(producto);
    }

    public Producto GetProductoById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Producto>.Filter.Eq(p => p.id, id);
        return collection.Find(filter).FirstOrDefault();
    }

    public void DeleteProductoById(long id)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Producto>.Filter.Eq(p => p.id, id);
        var result = collection.DeleteOne(filter);

        if (result.DeletedCount == 0)
        {
            Console.WriteLine("Ningún producto con ese ID.");
        }
    }

    public void UpdateProducto(Producto producto)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Producto>.Filter.Eq(p => p.id, producto.id);
        var result = collection.ReplaceOne(filter, producto);

        if (result.ModifiedCount == 0)
        {
            Console.WriteLine("Ningún producto con ese ID o ningún cambio efectuado.");
        }
    }

    public List<Producto> FindProductosByNombre(string searchTerm)
    {
        var collection = connection.GetCollection();
        var filter = Builders<Producto>.Filter.Regex(p => p.nombre, new BsonRegularExpression(searchTerm, "i"));
        return collection.Find(filter).ToList();
    }
}
