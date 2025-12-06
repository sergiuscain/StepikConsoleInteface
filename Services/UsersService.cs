using MySql.Data.MySqlClient;
using StepikPetProject.Models;

namespace StepikPetProject.Services
{
    public class UsersService
    {
        /// <summary>
        /// Добавление нового пользователя в таблицу users
        /// </summary>
        /// <param name="user">Новый пользователь</param>
        /// <returns>Удалось ли добавить пользователя</returns>
        public static bool Add(User user)
        {
            try
            {
                //Создаем подключение
                using (MySqlConnection connection = new MySqlConnection(Constant.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection open");

                    // Создание таблицы
                    using (MySqlCommand command = new MySqlCommand(@"
                        CREATE TABLE IF NOT EXISTS users (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            full_name VARCHAR(50) NOT NULL,
                            details VARCHAR(50),
                            join_date DATE NOT NULL,
                            is_active BOOL,
                            avatar TEXT
                        );", connection)) 
                    {
                        Console.WriteLine(command.ExecuteNonQuery());
                    }
                    // Вставка данных
                    using (MySqlCommand command = new MySqlCommand(@"
                        INSERT INTO users (full_name, details, join_date, avatar, is_active) 
                        VALUES (@full_name, @details, @join_date, @avatar, @is_active);", connection)) 
                    {
                        command.Parameters.AddWithValue("@full_name", user.FullName);
                        command.Parameters.AddWithValue("@details", user.Details);
                        command.Parameters.AddWithValue("@join_date", user.JoinDate);
                        command.Parameters.AddWithValue("@avatar", user.Avatar);
                        command.Parameters.AddWithValue("@is_active", user.IsActive);

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Успешно добавлен пользователь...{rowsAffected}");

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось добавить пользователя: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Получение пользователя из таблицы users
        /// </summary>
        /// <param name="fullName">Полное имя пользователя</param>
        /// <returns>User</returns>
        public static User Get(string fullName)
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand($"SELECT * FROM users Where full_name = @full_name AND is_active = true", connection);
            command.Parameters.AddWithValue("@full_name", fullName);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var user = new User
                {
                    FullName = reader.GetString("full_name"),
                    Details = reader.IsDBNull(reader.GetOrdinal("details"))
                         ? null : reader.GetString("details"),
                    JoinDate = reader.GetDateTime("join_date"),
                    IsActive = reader.GetBoolean("is_active"),
                    Avatar = reader.IsDBNull(reader.GetOrdinal("avatar"))
                        ? null : reader.GetString("avatar")
                };
                return user;
            }
            //Пользователь не найден
            return null;
        }
    }
}