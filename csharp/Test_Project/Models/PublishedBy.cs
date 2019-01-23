using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Project.Models
{
    [Table("books_has_publishers")]
    public class PublishedBy
    {
        [Key]
        [Column("books_has_publishersId")]
        public long PublishedById {get; set;}

        [Display(Name="Book Title:")]
        public long BookId {get; set;}
        public Book Book {get; set;}

        [Display(Name="Publisher Name:")]
        public long PublisherId {get; set;}
        public Publisher Publisher {get; set;}

    }
}