using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDataAccess.Models;
namespace MongoDataAccess.DataAccess
{
    public class ChoreDataAccess
    {
        private const string ConnectionString ="mongodb+srv://m001-student:cwMs4i8DcBH01gJ4@sandbox.icgrf.mongodb.net/?retryWrites=true&w=majority";
        private const string SimpleDatabaseName = "simple_db";
        private const string UsersCollectionName = "people";
        private const string ChoresCollectionName = "chores";

        //if we have more collections we can reuse this code for all of them.
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(SimpleDatabaseName);
            return db.GetCollection<T>(collection);
            
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var usersCollection = ConnectToMongo<UserModel>(UsersCollectionName);
            var results = await usersCollection.FindAsync(_ => true);
            return results.ToList();    

        }

        public async Task<List<Chores>> GetAllChores()
        {
            var choresCollection = ConnectToMongo<Chores>(ChoresCollectionName);
            var results = await choresCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<Chores>> GetUserChores(UserModel user)
        {

            var choresCollection = ConnectToMongo<Chores>(ChoresCollectionName);
            var results = await choresCollection.FindAsync(c => c.UserId==user.Id);
            return results.ToList();
        }

        public Task CreateUser(UserModel user)
        {
            var usersCollection = ConnectToMongo<UserModel>(UsersCollectionName);
            return usersCollection.InsertOneAsync(user);
        }

        public Task CreateChore (Chores chore)
        {
            var choresCollection = ConnectToMongo<Chores>(ChoresCollectionName);
            return choresCollection.InsertOneAsync(chore);  

        }

        public Task UpdateChore(Chores chore)
        {
            var choresCollection = ConnectToMongo<Chores>(ChoresCollectionName);
            var filter = Builders<Chores>.Filter.Eq("Id", chore.Id);
            return choresCollection.ReplaceOneAsync(filter, chore, new ReplaceOptions { IsUpsert = true });

        }

        public Task DeleteChore (Chores chore)
        {
            var choresCollection = ConnectToMongo<Chores>(ChoresCollectionName);
            return choresCollection.DeleteOneAsync(c => c.Id == chore.Id);
        }
    }
}
