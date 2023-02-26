using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend> GetFriends(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var requestorUserEntity = userRepository.FindById(f.user_id);
                var acceptorUserEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, requestorUserEntity.email, acceptorUserEntity.email, acceptorUserEntity.firstname, acceptorUserEntity.lastname));
            });

            return friends;
        }

        public void SendFriendRequest(FriendRequestData friendRequestData)
        {
            if (String.IsNullOrEmpty(friendRequestData.AcceptorEmail))
                throw new ArgumentNullException();

            var findFriendEntity = this.userRepository.FindByEmail(friendRequestData.AcceptorEmail);
            if (findFriendEntity is null) throw new UserNotFoundException();

            var friendEntityRequestor = new FriendEntity()
            {
                user_id = friendRequestData.RequestorId,
                friend_id = findFriendEntity.id
            };

            if (this.friendRepository.Create(friendEntityRequestor) == 0)
                throw new Exception();

            var friendEntityAcceptor = new FriendEntity()
            {
                user_id = findFriendEntity.id,
                friend_id = friendRequestData.RequestorId
            };

            if (this.friendRepository.Create(friendEntityAcceptor) == 0)
                throw new Exception();
        }
    }
}
