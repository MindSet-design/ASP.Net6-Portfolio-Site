using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Models
{
    public class Survey
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? Id { get; set; }

        [Required, MaxLength(56)]
        public string? Company { get; set; }

        [Required, MaxLength(56)]
        public string? Position { get; set; }

        [Required, MaxLength(56)]
        public string? City { get; set; }

        [Required, MaxLength(56)]
        public string? Province { get; set; }

        [Required, MaxLength(56)]
        public string? Country { get; set; }

        [Required, MaxLength(15)]
        public string? Interest { get; set; }

        [StringLength(250, ErrorMessage = "Sorry your message was to long")]
        public string? Comments { get; set; }

        [Required,MaxLength(20)]
        public string? Password { get; set; }

    }
}
