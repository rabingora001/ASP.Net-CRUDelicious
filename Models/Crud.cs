using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Crud
    {
        [Key]
        public int CrudId {get;set;}
        [Required(ErrorMessage = " Food Name cannot be Empty!!!")]
        [MinLength(2 , ErrorMessage = "Food Name should be greater than 2!!")]
        public string Name {get;set;}

        [Required(ErrorMessage="Chef's Name cannot be Empty!!")]
        [MinLength(2, ErrorMessage="Chef's Name should be greater than 2!!!!")]
    
        public string Chef {get;set;}
        [Range(1,5, ErrorMessage="Select valid number tastiness range!!!")]
        public int Tastiness {get;set;}

        [Range(1,1000, ErrorMessage="Select valid number calories range!!!")]
        public int Calories {get;set;}
        
        [Required(ErrorMessage="Descrition cannot be Empty!!")]
        [MinLength(3, ErrorMessage="Description should be greater than 3!!!!")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }
}