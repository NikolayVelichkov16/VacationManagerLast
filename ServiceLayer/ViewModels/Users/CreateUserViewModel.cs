using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels.Users
{
    public class CreateUserViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(10, 150, ErrorMessage = "Age must be between 10 and 150!")]
        public int Age { get; set; }

        public RoleViewModel Role { get; set; }

        public CreateUserViewModel()
        {

        }

        public CreateUserViewModel(string username, string password, string email, string name, int age, RoleViewModel role)
        {
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Age = age;
            Role = role;
        }

    }
}
