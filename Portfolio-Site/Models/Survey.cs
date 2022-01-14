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

        [Required(ErrorMessage ="A company name is requiered")]
        [StringLength(56, ErrorMessage = "Sorry your name was to long")]
        public string Company { get; set; }

        [Required(ErrorMessage = "A job position  is requiered")]
        [StringLength(56, ErrorMessage = "Sorry your name was to long")]
        public string Position { get; set; }

        [Required(ErrorMessage = "A city is requiered")]
        [StringLength(56, ErrorMessage = "Sorry your name was to long")]
        public string City { get; set; }

        [Required(ErrorMessage = "A province/state is requiered")]
        [StringLength(56, ErrorMessage = "Sorry your name was to long")]
        public string Province { get; set; }

        [Required(ErrorMessage = "A country is requiered")]
        [StringLength(56, ErrorMessage ="Sorry your name was to long")]
        public string Country { get; set; }

        [Required(ErrorMessage = "An interest level is requiered")]
        [StringLength(15, ErrorMessage ="wtf did you send")]
        public string Interest { get; set; }

        [StringLength(250, ErrorMessage = "Sorry your message was to long")]
        public string? Comments { get; set; }

        [StringLength(20, ErrorMessage ="password length must be under 20 characters")]
        public string? Password { get; set; }

    }

}
