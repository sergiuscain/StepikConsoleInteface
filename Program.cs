using MySql.Data.MySqlClient;

namespace StepikPetProject
{
    class Program
    {
        static void Main()
        {
            //Строка подключения
            string connectionString = "Server=localhost;Database=stepik;Uid=root;Pwd=root;";

            //Создаем подключение
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            Console.WriteLine("Connection open");

            // Закрываем подключение
            connection.Close();
            Console.WriteLine("Подключение закрыто");
        }
    }
}
