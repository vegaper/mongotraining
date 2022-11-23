using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace MongoDataAccess.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }


    }
}
