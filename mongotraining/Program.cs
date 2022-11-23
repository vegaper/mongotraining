

using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;
using MongoDB.Driver;
using mongotraining;
using System.Globalization;

//simple implementation
string connectionString = "mongodb+srv://m001-student:<password>@sandbox.icgrf.mongodb.net/?retryWrites=true&w=majority";

string databaseName = "simple_db";
string collectionName = "people";

var client = new MongoClient(connectionString);
var db = client.GetDatabase(databaseName);
var collection = db.GetCollection<usermodel>(collectionName);

var person = new usermodel
{
Name = "Tim",
LastName = "Corey"
};

await collection.InsertOneAsync(person);
var results = await collection.FindAsync(_ => true);


foreach (var result in results.ToList())
{
    Console.WriteLine($"{result.Name} {result.LastName}");
}

//real live implementation.

ChoreDataAccess db1 = new ChoreDataAccess();
  
var person1= new UserModel
{
    Name = "Tim",
    LastName = "Corey2"
};

await db1.CreateUser(person1);

var users = await db1.GetAllUsers();
var chore = new Chores()
{
    Name = "mongo study",
    UserId = users.FirstOrDefault().Id
};

await db1.CreateChore(chore);





