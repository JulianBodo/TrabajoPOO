using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

public class MongoDBManager
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Cliente> _collection;

    public MongoDBManager(string connectionString, string databaseName, string collectionName)
    {
        // Create MongoDB client and get the database
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);

        // Get the collection for Cliente objects
        _collection = _database.GetCollection<Cliente>(collectionName);
    }

    // Method to insert a list of Cliente objects into the collection
    public void InsertClientes(List<Cliente> clientes)
    {
        _collection.InsertMany(clientes);
    }

    // Method to retrieve all Cliente objects from the collection
    public List<Cliente> GetClientes()
    {
        return _collection.Find(new BsonDocument()).ToList();
    }
}
