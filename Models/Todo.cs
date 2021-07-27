using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace todo_aspnetcore.Models 
{

    public interface ITrackable 
    {
        DateTime CreatedAt { get; set; }
        DateTime LastUpdatedAt { get; set; }

    }

    public enum Category
    {
        Personal, Work
    }

    public class Todo : ITrackable 
    {
        public int ID { get; set; }
        [Column("Todo"), Required, StringLength(200)] // this is the db column name
        public string TodoString { get; set; }
        [Required]
        public Category Category {get; set;}

        // ITrackable Properties
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }


  
}