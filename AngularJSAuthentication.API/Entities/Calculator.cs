using AngularJSAuthentication.API.Models;

namespace AngularJSAuthentication.API.Entities
{
 
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class Calculator
    {
        [BsonId]
        public string Id { get; set; }
        
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Number1 { get; set; }
        [Required]
        public decimal Number2 { get; set; }
        [Required]
        public OperationTypes OperationType { get; set; }
        [Required]
        public decimal Result { get; set; }
    }
}