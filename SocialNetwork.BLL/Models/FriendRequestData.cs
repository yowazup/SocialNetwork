using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class FriendRequestData
    {
        public int RequestorId { get; set; }
        public string AcceptorEmail { get; set; }
    }
}
