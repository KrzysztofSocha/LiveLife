using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Models
{
    public class UserInterest:Entity
    {
        public int Id { get; set; }
        public int InetestId { get; set; }
        public Interest Interest { get; set; }
        public int UserPageId { get; set; }
        public UserPage UserPage { get; set; }
        public ICollection<UserPagePost> Posts { get; set; }
    }
}
