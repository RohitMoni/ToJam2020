using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

// Using drivers from https://github.com/Julian23517/Unity-mongo-csharp-driver-dlls

public class textfieldScript : MonoBehaviour
{
    private const string MONGO_URI = "mongodb://writer:vision2020@ds229078.mlab.com:29078/tojam2020db";
    private const string DATABASE_NAME = "tojam2020db";
    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
        collection = db.GetCollection<BsonDocument>("collection_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushTextToDb(string text)
    {
        var document = new BsonDocument { { "text_input", text } };
        collection.InsertOne(document);
    }
}
