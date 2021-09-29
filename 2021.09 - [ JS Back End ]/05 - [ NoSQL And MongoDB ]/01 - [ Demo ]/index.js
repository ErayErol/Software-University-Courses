const mongodb = require('mongodb');

const client = new mongodb.MongoClient('mongodb://localhost:27017');

client.connect()
    .then(() => {
        console.log('Connected');

        const db = client.db('myDB');
        const collection = db.collection('courses');

        return collection.find({}).toArray();
    }).then(courses => {
        console.log(courses);
    });