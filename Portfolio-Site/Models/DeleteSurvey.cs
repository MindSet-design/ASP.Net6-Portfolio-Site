using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class DeleteSurvey
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; }

        [StringLength(20, ErrorMessage = "password length must be under 20 characters")]
        public string Password { get; set; }
    }
}
