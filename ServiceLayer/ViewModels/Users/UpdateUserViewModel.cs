using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels.Users
{
    public class UpdateUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(10, 150, ErrorMessage = "Age must be between 10 and 150!")]
        public int Age { get; set; }


        public UpdateUserViewModel()
        {
        }

        public UpdateUserViewModel(string id, string username, string email, string name, int age)
            : this()
        {
            Id = id;
            Username = username;
            Email = email;
            Name = name;
            Age = age;
        }

    }
}
