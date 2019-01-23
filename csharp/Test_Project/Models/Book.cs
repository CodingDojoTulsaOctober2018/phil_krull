using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Test_Project.Models
{
    [Table("books")]
    public class Book
    {
        [Key]
        public long BookId {get; set;}

        [Display(Name="Title")]
        [Required(ErrorMessage="A book must have a title")]
        public string Title {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}

        // relationship to an author
        public long AuthorId { get; set;}
        public Author WrittenBy {get; set;}

        public List<PublishedBy> PublishedBy {get; set;}

        public Book() {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}