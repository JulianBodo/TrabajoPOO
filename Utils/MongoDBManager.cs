using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

public class MongoDBManager<T>
{
    private IMongoDatabase database;
    private IMongoCollection<T> collection;

    public MongoDBManager(string connectionString, string databaseName, string collectionName)
    {
        // Create MongoDB client and get the database
        var client = new MongoClient(connectionString);
        database = client.GetDatabase(databaseName);

        // Get the collection for Cliente objects
        collection = database.GetCollection<T>(collectionName);
    }

    public IMongoCollection<T> GetCollection()
    {
        return collection;
    }
 
}
