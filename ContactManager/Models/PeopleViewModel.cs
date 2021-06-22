using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class PeopleViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Married { get; set; }
        [Required]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Salary { get; set; }
    }
}
