using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepikPetProject.Models
{
    public class User
    {
        public string FullName;
        public string? Details;
        public DateTime JoinDate = DateTime.Now;
        public string? Avatar;
        public bool IsActive = true;
    }
}
