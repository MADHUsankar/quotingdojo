using System.ComponentModel.DataAnnotations;
using System;
namespace quotingdojo.Models
{
    public class Quote : BaseEntity
    {
         [Required]
         [MinLength(3)]
        public string Username { get; set; }
                 [Required]
         [MinLength(3)]
        public string Quotemsg { get; set; }
                public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Quote()
        {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
            
        }
    }
}