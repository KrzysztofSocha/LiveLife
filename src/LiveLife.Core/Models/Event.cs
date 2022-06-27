using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Models
{
    public class Event: FullAuditedEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }       
        public string  Description { get; set; }
        [Required]
        public bool IsLimit { get; set; }
        public int? PeopleLimit { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public bool IsReported { get; set; }
        public DateTime? ReportTime { get; set; }
        public EventAddress Address { get; set; }
        public ICollection<EventUser> JoinedUsers { get; set; }


    }
}
