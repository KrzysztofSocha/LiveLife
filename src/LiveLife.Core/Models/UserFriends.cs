using Abp.Domain.Entities.Auditing;
using LiveLife.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveLife.Models
{
    public class UserFriend:IHasCreationTime
    {
      
        public long SenderUserId { get; set; }
        
        public User SenderUser { get; set; }
       
        public long ReceiverUserId { get; set; }
       
        public User ReceiverUser { get; set; }
        public DateTime CreationTime { get ; set; }
    }
}
