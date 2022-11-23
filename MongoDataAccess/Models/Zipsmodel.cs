using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDataAccess.Models
{
    public class Zipsmodel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set;   }
        public string City { get; set; }
        public string Zip { get; set; }
        public coordinates Coor { get; set; }
        public int Pop { get; set; }
        public string State { get; set; }   


    }

    public class coordinates
    {
        public double y { get; set; }
        public double x { get; set; }
    }
}
