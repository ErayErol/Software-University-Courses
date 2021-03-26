namespace NoSQL
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("NoSQL");
            var collection = database.GetCollection<BsonDocument>("softuniArticles");

            var articles = collection.Find(new BsonDocument { }).ToList();
            foreach (var article in articles)
            {
                string name = article.GetElement("name").Value.AsString;
                Console.WriteLine(name);
            }
        }
    }
}
