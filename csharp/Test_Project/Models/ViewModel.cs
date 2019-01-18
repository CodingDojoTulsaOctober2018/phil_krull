using System;
using System.Collections.Generic;

namespace Test_Project.Models
{
    public class ViewModel
    {
        // this field must match the parameter of the post(create)
        public Author Author {get; set;}
        public Book Book {get; set;}
        public List<Author> Allauthors {get; set;}
        public List<Book> Allbooks {get; set;}

        // this will be replace by a db
        // public ViewModel() {
        //     Allauthors = new List<Author>();
        //     Allauthors.Add(new Author("Tom Clancey"));
        //     Allauthors.Add(new Author("Robert Hindland"));
        //     Allauthors.Add(new Author("Dr. Suess"));
        //     Allauthors.Add(new Author("JK Rowling"));
        // }
    }
}