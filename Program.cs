using MySql.Data.MySqlClient;
using StepikPetProject.Models;
using StepikPetProject.Services;

namespace StepikPetProject
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine(@"
                ************************************************
                * Добро пожаловать на онлайн платформу Stepik! *
                ************************************************

                Выберите действие (введите число и нажмите Enter):

                1. Зарегистрироваться
                2. Закрыть приложение

                ************************************************
                ");

                var cmd = Console.ReadLine();
                if (cmd == "1")
                {
                    RegisterUser();
                }
                else if (cmd == "2")
                {
                    Console.Write("До свидания!");
                    break;
                }
                else if (cmd == "3")
                {
                    var user = UsersService.Get("Сергей Королев");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }

            }
        }


        public static void RegisterUser()
        {
            Console.WriteLine("Введите имя и фамилию через пробел и нажмите Enter:");
            var user = new User { FullName = Console.ReadLine() };
            var result = UsersService.Add(user);
            if (result)
            {
                Console.WriteLine($"Пользователь '{user.FullName}' успешно добавлен.");
            }
            else
            {
                Console.WriteLine("Произошла ошибка, произведен выход на главную страницу");
            }
        }
    }
}
