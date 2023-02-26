using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Cписок друзей:");


            if (friends.Count() == 0)
            {
                Console.WriteLine("Друзей нет.");
                return;
            }

            friends.ToList().ForEach(f =>
            {
                Console.WriteLine("{0} {1} - для связи: {2}", f.FirstName, f.LastName, f.AcceptorEmail);
            });
            Console.WriteLine();
        }
    }
}
