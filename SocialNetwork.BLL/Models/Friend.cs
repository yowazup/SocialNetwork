using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public string RequestorEmail { get; }
        public string AcceptorEmail { get; }
        public string FirstName { get; }
        public string LastName { get; }


        public Friend(int id, string requestorEmail, string acceptorEmail, string firstName, string lastName)
        {
            this.Id = id;
            this.RequestorEmail = requestorEmail;
            this.AcceptorEmail = acceptorEmail;
            this.FirstName = firstName; 
            this.LastName = lastName;
        }

    }
}
