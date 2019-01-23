using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Test_Project.Models
{
    [Table("publishers")]
    public class Publisher
    {
        [Key]
        public long PublisherId {get; set;}

        [Display(Name="Publisher:")]
        [Required(ErrorMessage="A publisher must have a title")]
        public string Name {get; set;}

        public DateTime CreatedAt {get; set;}
        public DateTime UdatedAt {get; set;}

        public List<PublishedBy> PublishedBy {get; set;}

        public Publisher() {
            CreatedAt = DateTime.Now;
            UdatedAt = DateTime.Now;
        }
    }
}