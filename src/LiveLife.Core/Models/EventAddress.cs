using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace LiveLife.Models
{
    public class EventAddress:Entity
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string City { get; set; }
        [MaxLength(25)]
        public string Address { get; set; }
        public string DescriptionPlace { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}