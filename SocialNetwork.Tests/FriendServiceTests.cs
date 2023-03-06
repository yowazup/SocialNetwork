using Dapper;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.Data.SQLite;
using System.Runtime.Intrinsics.X86;
using System.Linq;

namespace SocialNetwork.Tests
{
    public class FriendServiceTests
    {
        private int user1Id;
        private int user2Id;
        private IEnumerable<Friend> friendsUser1;

        [SetUp]
        public void Setup()
        {
            var connection = new SQLiteConnection("Data Source = DB/SocialNetworkDB.db; Version = 3");
            connection.Open();

            //создаем в БД первого пользователя
            connection.Execute(@"insert into users (firstname,lastname,password,email) 
                             values ('Никита','Захаров','12345678','nikita@gmail.com')");
            user1Id = (int)connection.LastInsertRowId;

            //создаем в БД второго пользователя
            connection.Execute(@"insert into users (firstname,lastname,password,email) 
                             values ('Лев','Захаров','12345678','lev@gmail.com')");
            user2Id = (int)connection.LastInsertRowId;

            //делаем пользователей друзьями
            var friendRequestData = new FriendRequestData()
            {
                AcceptorEmail = "lev@gmail.com",
                RequestorId = user1Id
            };
            var friendService = new FriendService();
            friendService.SendFriendRequest(friendRequestData);
            friendsUser1 = friendService.GetFriends(user1Id);
        }

        [Test]
        public void CanAddFriend()
        {
            Assert.That(friendsUser1.Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddedFriendToRequestorIsCorrect()
        {
            Assert.That(friendsUser1.Select(f => f.AcceptorEmail).Count(), Is.EqualTo(1));
        }

        [Test]
        public void AddedFriendToAcceptorIsCorrect()
        {
            Assert.That(friendsUser1.Select(f => f.RequestorEmail).Count(), Is.EqualTo(1));
        }
    }
}