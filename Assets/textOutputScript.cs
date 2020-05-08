using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;

// Using drivers from https://github.com/Julian23517/Unity-mongo-csharp-driver-dlls

public class textOutputScript : MonoBehaviour
{
    private TextMeshProUGUI textfield;

    private const string MONGO_URI = "mongodb://writer:vision2020@ds229078.mlab.com:29078/tojam2020db";
    private const string DATABASE_NAME = "tojam2020db";
    private MongoClient client;
    private IMongoDatabase db;
    private IMongoCollection<BsonDocument> collection;

    // Start is called before the first frame update
    void Start()
    {
        textfield = GetComponent<TextMeshProUGUI>();

        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
        collection = db.GetCollection<BsonDocument>("collection_1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTextValue(string text)
    {
        var filter = Builders<BsonDocument>.Filter.Empty;
        var list = collection.Find(filter).ToList();

        if (list.Count < 1)
        {
            return;
        }

        int index = Random.Range(0, list.Count-1);

        textfield.SetText(list[index].GetElement("text_input").Value.ToString());
    }
}
