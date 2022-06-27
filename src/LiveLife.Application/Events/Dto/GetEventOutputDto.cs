using Abp.AutoMapper;
using LiveLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Events.Dto
{
    [AutoMapFrom(typeof(Event))]
    public class GetEventOutputDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Description { get; set; }
       
        public bool IsLimit { get; set; }
        public int? PeopleLimit { get; set; }
        public EventAddressDto Address { get; set; }
    }
}
