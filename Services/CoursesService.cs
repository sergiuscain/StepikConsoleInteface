using MySql.Data.MySqlClient;
using StepikPetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepikPetProject.Services
{
    public class CoursesService
    {
        /// <summary>
        /// Получение общего количества курсов
        /// </summary>
        public static int GetTotalCount()
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand("SELECT COUNT(*) FROM courses;", connection);
            var result = command.ExecuteScalar();
            return result == null ? 0 : (int)result;
        }
        /// <summary>
        /// Получение списка курсов пользователя
        /// </summary>
        /// <param name="fullName">Полное имя пользователя</param>
        /// <returns>Список курсов</returns>
        public static List<Course> Get(string fullName)
        {
            using var connection = new MySqlConnection(Constant.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand($"SELECT * FROM course WHERE ", connection);
        }
    }
}
