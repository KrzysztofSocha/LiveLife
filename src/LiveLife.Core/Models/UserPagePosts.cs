using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Models
{
    public class UserPagePost:IHasCreationTime
    {
        public int Id { get; set; }
        public DateTime CreationTime { get ; set ; }
        public string  Description { get; set; }
    }
}
