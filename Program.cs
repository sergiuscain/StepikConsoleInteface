using MySql.Data.MySqlClient;
using StepikPetProject.Services;

namespace StepikPetProject
{
    class Program
    {
        static void Main()
        {
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
}
