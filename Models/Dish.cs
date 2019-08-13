using System.ComponentModel.DataAnnotations;
using System;


namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId{get;set;}
        [Required(ErrorMessage="You must enter a Chef's name")]
        public string Chef{get;set;}
        
        [Required(ErrorMessage="You must enter a name")]
        public string Name{get;set;}
        [Required(ErrorMessage="You must enter a caloric amount")]
        public int Calories{get;set;}
        [Required(ErrorMessage="You must enter a tastiness value")]
        [Range(1, 5)]
        public int Tastiness{get;set;}
        public string Description{get;set;}
        public DateTime CreatedAt{get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}