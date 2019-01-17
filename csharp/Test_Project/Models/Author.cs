using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Project.Models
{
    [Table("authors")]
    public class Author
    {
        [Key]
        public long AuthorId {get; set;}

        [Required(ErrorMessage="Author must have a name")]
        public string Name {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        public Author() {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        // public Author(string name)
        // {
        //     Name = name;
        // }
    }
}