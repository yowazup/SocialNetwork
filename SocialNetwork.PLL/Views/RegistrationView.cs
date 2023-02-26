using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;
        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            var userRegistrationData = new UserRegistrationData();

            Console.WriteLine("Для создания нового профиля введите данные.");
            
            Console.Write("Имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Адрес электронной почты: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                this.userService.Register(userRegistrationData);

                SuccessMessage.Show("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение.");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при регистрации.");
            }
        }
    }
}
