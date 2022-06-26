using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Models
{
    public class Event: FullAuditedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }       
        public string  Description { get; set; }
        public bool IsLimit { get; set; }
        public int? PeopleLimit { get; set; }


    }
}
