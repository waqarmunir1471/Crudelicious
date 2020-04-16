using System;
using System.ComponentModel.DataAnnotations;

namespace Crudelicious.Models
{
    public class CDelicious
    {
        [Key]
        public int DishId{get;set;}
        [Display(Name="Name of Dish")]
        public string Name{get;set;}
        [Display(Name="Chef's Name")]
        public string ChefName{get;set;}
        [Display(Name="Tastiness")]
        [Range(1,10)]
        public int Tastiness{get;set;}

        [Display(Name="# of Calories")]
        [Range(1,999)]
        public int? Calories {get;set;}

        [Display(Name="Description")]
        public string Description{get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}