using Abp.Domain.Entities;
using LiveLife.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Models
{
    public class UserPage:Entity
    {
        public int Id { get; set; }
        public string UserDescription { get; set; }
        public ICollection<UserInterest> Interests { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
