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

            var filter = Builders<BsonDocument>.Filter.Lt("rating", 50.ToString());
            var result = collection.DeleteMany(filter);
            Console.WriteLine($"Deleted articles with ranking less than 50 - {result.DeletedCount}");

            Console.WriteLine("Articles with ranking more than 50");
            var articles = collection.Find(new BsonDocument { }).ToList();
            foreach (var article in articles)
            {
                var author = article.GetElement("author").Value.AsString;
                var date = article.GetElement("date").Value.AsString;
                var name = article.GetElement("name").Value.AsString;
                var rating = article.GetElement("rating").Value.AsString;
                Console.WriteLine($"{author} - {date} - {name} - {rating}");
            }
        }
    }
}
