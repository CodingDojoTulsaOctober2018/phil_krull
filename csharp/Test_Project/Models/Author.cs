using System;
using System.ComponentModel.DataAnnotations;

namespace Test_Project.Models
{
    public class Author
    {
        [Required(ErrorMessage="Author must have a name")]
        public string Name {get; set;}

        public Author() {}
        public Author(string name)
        {
            Name = name;
        }
    }
}