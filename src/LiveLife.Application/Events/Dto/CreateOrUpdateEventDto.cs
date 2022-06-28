using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Events.Dto
{
    [AutoMapTo(typeof (Models.Event))]
    [AutoMapFrom(typeof (Models.Event))]
    public class CreateOrUpdateEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Description { get; set; }
       
        public bool IsLimit { get; set; }=false;
        public int? PeopleLimit { get; set; } = null;

        public bool IsPublic { get; set; } = true;
        public EventAddressDto Address { get; set; }
    }
    [AutoMapTo(typeof(Models.EventAddress))]
    [AutoMapFrom(typeof(Models.EventAddress))]
    public class EventAddressDto
    {
        public string City { get; set; }
        
        public string Address { get; set; }
        public string DescriptionPlace { get; set; }
    }
}
