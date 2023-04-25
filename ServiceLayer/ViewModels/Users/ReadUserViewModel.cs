using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ViewModels.Users
{
    public class ReadUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(10, 150, ErrorMessage = "Age must be between 10 and 150!")]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }


        public ReadUserViewModel(string id, string username, string name, int age, string email)
        {
            Id = id;
            Username = username;
            Name = name;
            Age = age;
            Email = email;
        }

        

    }
}
