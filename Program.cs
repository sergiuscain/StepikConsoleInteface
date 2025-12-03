using MySql.Data.MySqlClient;
using StepikPetProject.Services;

namespace StepikPetProject
{
    class Program
    {
        static void Main()
        {
           UsersService.Add(new Models.User { Avatar="avatarURI", Details = "testDetails", FullName="Anna Anika", IsActive=true } );
        }
    }
}
