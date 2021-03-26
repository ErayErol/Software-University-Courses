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
                int newRating = int.Parse(article.GetElement("rating").Value.AsString) + 10;
                var filter = Builders<BsonDocument>.Filter.Eq("_id", article.GetElement("_id").Value);
                var update = Builders<BsonDocument>.Update.Set("rating", newRating.ToString());
                collection.UpdateOne(filter, update);

                var rating = article.GetElement("rating").Value.AsString;
                Console.WriteLine(rating);
            }
        }
    }
}