using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendRequestView
    {
        UserService userService;
        FriendService friendService;
        public FriendRequestView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.Write("Введите почтовый адрес друга: ");
            friendRequestData.AcceptorEmail = Console.ReadLine();

            friendRequestData.RequestorId = user.Id;

            try
            {
                friendService.SendFriendRequest(friendRequestData);

                SuccessMessage.Show("Друг успешно добавлен!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отправке запроса в друзья!");
            }

        }
    }
}
